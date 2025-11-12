
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.Repository;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

                string idPablo = usuariocen.New_("ppo8@alu.ua.es", "Pablo Perez", 123456789, "Calle La Paz", new DateTime(2025, 5, 1), false, "password123");
                Console.WriteLine("Usuario 'Pablo Perez' creado.");

                if (usuariocen.Login("ppo8@alu.ua.es", "password123") != null)
                    Console.WriteLine("Login exitoso para 'Pablo Perez'.");

                // Crear usuarios
                string idLaura = usuariocen.New_("laura.martinez@correo.com", "Laura Martinez", 987654321, "Av. Alicante", new DateTime(2025, 5, 2), false, "securepass456");

                Console.WriteLine("Usuarios creados: Pablo y Laura");

                // Leer los objetos UsuarioEN
                UsuarioEN usuarioPablo = usuariocen.ReadOID(idPablo);
                UsuarioEN usuarioLaura = usuariocen.ReadOID(idLaura);

                // Crear producto para que pueda ser favorito
                int productoId = productocen.New_("Bicicleta", "Bici de monta�a", 299.99, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum.comoNuevo, SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum.equipamiento, new DateTime(2025, 11, 6), true);

                // Crear favorito donde Pablo guarda el producto
                int favoritoId = favoritocen.New_(DateTime.Now, productoId, new List<string> { idPablo });

                // Probar las funciones readFilter
                IList<FavoritoEN> favoritosDePablo = favoritocen.ObtenerFavoritosPorUsuario(idPablo);
                Console.WriteLine($"Favoritos encontrados para Pablo: {favoritosDePablo.Count}");

                IList<FavoritoEN> favoritosDeLaura = favoritocen.ObtenerFavoritosPorUsuario(idLaura);
                Console.WriteLine($"Favoritos encontrados para Laura: {favoritosDeLaura.Count}");

                // Crear valoracion donde Pablo valora un producto de Laura
                int valoracionId = valoracioncen.New_(5, "Excelente producto", DateTime.Now);

                IList<ValoracionEN> valoracionesDePablo = valoracioncen.ObtenerValoracionesPorUsuario(idPablo);
                Console.WriteLine($"Valoraciones encontradas para Pablo: {valoracionesDePablo.Count}");

                // Crear notificacion para Pablo
                int notificacionId = notificacioncen.New_("Nuevo Mensaje", "Laura te escribe: Hola", DateTime.Now, false, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum.mensaje);

                IList<NotificacionEN> notificacionesDePablo = notificacioncen.ObtenerNotificacionesPorUsuario(idPablo);
                Console.WriteLine($"Notificaciones encontradas para Pablo: {notificacionesDePablo.Count}");

                // Crear mensaje en el chat entre Pablo y Laura
                int mensajeId1 = mensajecen.New_("Hola Laura, como estas?", DateTime.Now, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum.texto, "Sin URL por el momento", idPablo, idLaura);

                var mensajes = mensajecen.ObtenerMensajesEntreUsuarios(idPablo, idLaura);
                Console.WriteLine($"Mensajes entre Pablo y Laura: {mensajes.Count}");

                var chats = mensajecen.ObtenerConversacionesPorUsuario("pablo@correo.com");
                Console.WriteLine($"Chats de Pablo: {chats.Count}");

                // Crear compra
                int compraId = compracen.New_(DateTime.Now, 299.99, productoId);

                IList<CompraEN> comprasPablo = compracen.ObtenerComprasPorUsuario(idPablo);
                Console.WriteLine($"Compras realizadas por Pablo: {comprasPablo.Count}");

                IList<CompraEN> ventasPablo = compracen.ObtenerVentasPorUsuario(idPablo);
                Console.WriteLine($"Ventas realizadas por Pablo: {ventasPablo.Count}");

                IList<ProductoEN> resultados = productocen.BuscarPorTexto("bicicleta");
                Console.WriteLine($"Productos encontrados: {resultados.Count}");

                var productosRopa = productocen.FiltrarPorCategoria(CategoriaEnum.equipamiento);
                Console.WriteLine($"Productos en la categoria ropa: {productosRopa.Count}");

                var productosBaratos = productocen.FiltrarPorPrecio(0, 300);
                Console.WriteLine($"Productos entre 0 y 50e: {productosBaratos.Count}");

                CompraCP compraCP = new CompraCP(new SessionCPNHibernate());
                compraCP.CompletarCompra(compraId);

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
