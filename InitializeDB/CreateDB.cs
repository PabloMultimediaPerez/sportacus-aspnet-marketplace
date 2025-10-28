
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.Infraestructure.Repository;

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
                ChatRepository chatrepository = new ChatRepository ();
                ChatCEN chatcen = new ChatCEN (chatrepository);
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

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

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
