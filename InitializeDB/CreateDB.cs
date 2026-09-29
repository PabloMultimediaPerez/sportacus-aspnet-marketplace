
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using NHibernate.Criterion;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                ProductoRepository productorepository = new ProductoRepository ();
                ProductoCEN productocen = new ProductoCEN (productorepository);
                MensajeRepository mensajerepository = new MensajeRepository ();
                MensajeCEN mensajecen = new MensajeCEN (mensajerepository);
                ImagenRepository imagenrepository = new ImagenRepository ();
                ImagenCEN imagencen = new ImagenCEN (imagenrepository);
                FavoritoRepository favoritorepository = new FavoritoRepository ();
                FavoritoCEN favoritocen = new FavoritoCEN (favoritorepository);
                CompraRepository comprarepository = new CompraRepository ();
                CompraCEN compracen = new CompraCEN (comprarepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                NotificacionRepository notificacionrepository = new NotificacionRepository ();
                NotificacionCEN notificacioncen = new NotificacionCEN (notificacionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                // 1) Crear 5 usuarios
                string u1 = usuariocen.New_ ("pablo@correo.com", "Pablo Perez", 600111222, "C/ La Paz 1", DateTime.Now, false, "pass1");
                string u2 = usuariocen.New_ ("laura@correo.com", "Laura Martinez", 600222333, "Av. Alicante 2", DateTime.Now, false, "pass2");
                string u3 = usuariocen.New_ ("carlos@correo.com", "Carlos Ruiz", 600333444, "C/ Mayor 3", DateTime.Now, false, "pass3");
                string u4 = usuariocen.New_ ("ana@correo.com", "Ana Lopez", 600444555, "Av. Madrid 4", DateTime.Now, false, "pass4");
                string u5 = usuariocen.New_ ("sofia@correo.com", "Sofia Gomez", 600555666, "Plaza España 5", DateTime.Now, false, "pass5");
                Console.WriteLine ($"Usuarios creados: {u1}, {u2}, {u3}, {u4}, {u5}");

                // 2) Comprobar login y lectura
                var loginPablo = usuariocen.Login ("pablo@correo.com", "pass1");
                Console.WriteLine ($"Login Pablo: {(loginPablo != null ? "OK " : "FALLA ")}");
                var readPablo = usuariocen.ReadOID (u1);
                Console.WriteLine ($"ReadOID Pablo: {readPablo?.Nombre}");

                // 3) Crear 5 productos
                int p1 = productocen.New_ ("Bicicleta", "Bici montaña", 299.99, EstadoProductoEnum.comoNuevo, CategoriaEnum.equipamiento, DateTime.Now, true, u1);
                int p2 = productocen.New_ ("Zapatillas", "Running", 89.99, EstadoProductoEnum.nuevo, CategoriaEnum.calzado, DateTime.Now, true, u2);
                int p3 = productocen.New_ ("Camiseta", "Deportiva", 19.99, EstadoProductoEnum.nuevo, CategoriaEnum.ropa, DateTime.Now, true, u3);
                int p4 = productocen.New_ ("Mancuernas", "Set 10kg", 49.99, EstadoProductoEnum.aceptable, CategoriaEnum.gimnasio, DateTime.Now, true, u4);
                int p5 = productocen.New_ ("Balón", "Fútbol", 25.00, EstadoProductoEnum.nuevo, CategoriaEnum.equipamiento, DateTime.Now, true, u5);
                Console.WriteLine ($"Productos creados: {p1}, {p2}, {p3}, {p4}, {p5}");

                // 4) Favoritos (uno por usuario)
                int f1 = favoritocen.New_ (DateTime.Now, p1, u1);
                int f2 = favoritocen.New_ (DateTime.Now, p2, u2);
                int f3 = favoritocen.New_ (DateTime.Now, p3, u3);
                int f4 = favoritocen.New_ (DateTime.Now, p4, u4);
                int f5 = favoritocen.New_ (DateTime.Now, p5, u5);
                Console.WriteLine ("Favoritos creados.");

                // 5) Valoraciones (asociadas a productos; si tu New_ requiere usuario, ajusta según firma)
                int val1 = valoracioncen.New_ (5, "Excelente", DateTime.Now, u1, u2, p1);
                int val2 = valoracioncen.New_ (4, "Muy buena", DateTime.Now, u2, u3, p2);
                int val3 = valoracioncen.New_ (3, "Normal", DateTime.Now, u3, u4, p3);
                int val4 = valoracioncen.New_ (2, "Regular", DateTime.Now, u4, u5, p4);
                int val5 = valoracioncen.New_ (1, "Mala", DateTime.Now, u5, u1, p5);
                Console.WriteLine ("Valoraciones creadas.");

                // 6) Notificaciones
                int n1 = notificacioncen.New_ ("Nuevo Mensaje", "Tienes un mensaje", DateTime.Now, false, TipoNotificacionEnum.mensaje, u1);
                int n2 = notificacioncen.New_ ("Compra completada", "Tu compra se completó", DateTime.Now, false, TipoNotificacionEnum.compra, u2);
                int n3 = notificacioncen.New_ ("Producto vendido", "Has vendido un producto", DateTime.Now, false, TipoNotificacionEnum.compra, u3);
                int n4 = notificacioncen.New_ ("Favorito", "Producto añadido a favoritos", DateTime.Now, false, TipoNotificacionEnum.mensaje, u4);
                int n5 = notificacioncen.New_ ("Valoración", "Has recibido una valoración", DateTime.Now, false, TipoNotificacionEnum.bajadaPrecio, u5);
                Console.WriteLine ("Notificaciones creadas.");

                // 7) Mensajes entre usuarios
                int m1 = mensajecen.New_ ("Hola Laura!", DateTime.Now, TipoMensajeEnum.texto, "", u1, u2, true);
                int m2 = mensajecen.New_ ("Hola Pablo!", DateTime.Now, TipoMensajeEnum.texto, "", u2, u1, false);
                int m3 = mensajecen.New_ ("Entrenamos?", DateTime.Now, TipoMensajeEnum.texto, "", u3, u4, true);
                int m4 = mensajecen.New_ ("Sí, a las 18h", DateTime.Now, TipoMensajeEnum.texto, "", u4, u3, false);
                int m5 = mensajecen.New_ ("Partido el sábado", DateTime.Now, TipoMensajeEnum.texto, "", u5, u1, false);
                Console.WriteLine ("Mensajes creados.");

                // 8) Comprobar obtención de mensajes y conversaciones
                var msgsPabloLaura = mensajecen.ObtenerMensajesEntreUsuarios (u1, u2);
                Console.WriteLine ($"Mensajes entre Pablo y Laura: {msgsPabloLaura.Count}");
                var chatsPablo = mensajecen.ObtenerConversacionesPorUsuario (u1);
                Console.WriteLine ($"Conversaciones de Pablo: {chatsPablo.Count}");

                // 9) Imágenes (una por producto)
                int img1 = imagencen.New_ ("url1.jpg", "Imagen bici", DateTime.Now, p1);
                int img2 = imagencen.New_ ("url2.jpg", "Imagen zapatillas", DateTime.Now, p2);
                int img3 = imagencen.New_ ("url3.jpg", "Imagen camiseta", DateTime.Now, p3);
                int img4 = imagencen.New_ ("url4.jpg", "Imagen mancuernas", DateTime.Now, p4);
                int img5 = imagencen.New_ ("url5.jpg", "Imagen balón", DateTime.Now, p5);
                Console.WriteLine ("Imágenes creadas.");

                // Verificar imágenes en BD
                var todasImgs = imagencen.ReadAll (0, -1);
                Console.WriteLine ($"Total imágenes en BD: {todasImgs.Count}");

                // 10) Compras (crear 5 compras pendientes)
                int c1 = compracen.New_ (DateTime.Now, 299.99, p1, u1, u2, MetodoPagoEnum.efectivo);
                int c2 = compracen.New_ (DateTime.Now, 89.99, p2, u2, u3, MetodoPagoEnum.bizum);
                int c3 = compracen.New_ (DateTime.Now, 19.99, p3, u3, u4, MetodoPagoEnum.payPal);
                int c4 = compracen.New_ (DateTime.Now, 49.99, p4, u4, u5, MetodoPagoEnum.tarjeta);
                int c5 = compracen.New_ (DateTime.Now, 25.00, p5, u5, u1, MetodoPagoEnum.bizum);
                Console.WriteLine ($"Compras creadas: {c1}, {c2}, {c3}, {c4}, {c5}");

                // 11) Consultas sobre productos
                var buscados = productocen.BuscarPorTexto ("bici");
                Console.WriteLine ($"Buscar 'bici' -> {buscados.Count} resultados");
                var porCategoria = productocen.FiltrarPorCategoria (CategoriaEnum.equipamiento);
                Console.WriteLine ($"Productos en equipamiento: {porCategoria.Count}");
                var porPrecio = productocen.FiltrarPorPrecio (0, 100);
                Console.WriteLine ($"Productos entre 0 y 100: {porPrecio.Count}");

                // 12) Compras/ventas por usuario
                var comprasDePablo = compracen.ObtenerComprasPorUsuario (u1);
                Console.WriteLine ($"Compras de Pablo: {comprasDePablo.Count}");
                var ventasDePablo = compracen.ObtenerVentasPorUsuario (u1);
                Console.WriteLine ($"Ventas de Pablo: {ventasDePablo.Count}");

                // 13) Obtener favoritos, notificaciones y valoraciones por usuario (los métodos que faltaban)
                var favsPablo = favoritocen.ObtenerFavoritosPorUsuario (u1);
                Console.WriteLine ($"Favoritos de Pablo: {favsPablo.Count}");
                var favsProd1 = favoritocen.ObtenerFavoritosPorProducto (p1);
                Console.WriteLine ($"Favoritos de Bicicleta: {favsProd1.Count}");

                var notifsPablo = notificacioncen.ObtenerNotificacionesPorUsuario (u1);
                Console.WriteLine ($"Notificaciones de Pablo: {notifsPablo.Count}");

                var valsPablo = valoracioncen.ObtenerValoracionesPorUsuario (u1);
                Console.WriteLine ($"Valoraciones de Pablo: {valsPablo.Count}");

                // 14) Completar una compra y verificar cambios (usa CompraCP)
                CompraCP compraCP = new CompraCP (new SessionCPNHibernate ());
                Console.WriteLine ($"Completando compra {c1}...");
                compraCP.CompletarCompra (c1);
                var compraCompletada = compracen.ReadOID (c1);
                Console.WriteLine ($"Compra {c1} estado: {compraCompletada.EstadoCompra}, FechaVenta: {compraCompletada.FechaVenta}");

                // 15) Lecturas finales y conteos
                var allUsuarios = usuariocen.ReadAll (0, -1);
                var allProductos = productocen.ReadAll (0, -1);
                var allCompras = compracen.ReadAll (0, -1);
                Console.WriteLine ($"Totales -> Usuarios: {allUsuarios.Count}, Productos: {allProductos.Count}, Compras: {allCompras.Count}");

                // 16) Comprobaciones adicionales (listas por usuario)
                var favoritosDeLaura = favoritocen.ObtenerFavoritosPorUsuario (u2);
                Console.WriteLine ($"Favoritos de Laura: {favoritosDeLaura.Count}");
                var notifsDeLaura = notificacioncen.ObtenerNotificacionesPorUsuario (u2);
                Console.WriteLine ($"Notificaciones de Laura: {notifsDeLaura.Count}");
                var valsDeLaura = valoracioncen.ObtenerValoracionesPorUsuario (u2);
                Console.WriteLine ($"Valoraciones de Laura: {valsDeLaura.Count}");

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
