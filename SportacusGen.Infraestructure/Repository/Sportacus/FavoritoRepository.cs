
using System;
using System.Text;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.Infraestructure.EN.Sportacus;


/*
 * Clase Favorito:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class FavoritoRepository : BasicRepository, IFavoritoRepository
{
public FavoritoRepository() : base ()
{
}


public FavoritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoEN ReadOIDDefault (int id
                                  )
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoNH)).List<FavoritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoEN favorito)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), favorito.Id);

                favoritoNH.FechaMarcado = favorito.FechaMarcado;



                session.Update (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FavoritoEN favorito)
{
        FavoritoNH favoritoNH = new FavoritoNH (favorito);

        try
        {
                SessionInitializeTransaction ();
                if (favorito.Producto != null) {
                        // Argumento OID y no colección.
                        favoritoNH
                        .Producto = (SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN), favorito.Producto.Id);

                        favoritoNH.Producto.Favorito
                        .Add (favoritoNH);
                }
                if (favorito.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoNH
                        .Usuario = (SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN), favorito.Usuario.Email);

                        favoritoNH.Usuario.Favorito
                        .Add (favoritoNH);
                }

                session.Save (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoNH.Id;
}

public void Modify (FavoritoEN favorito)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), favorito.Id);

                favoritoNH.FechaMarcado = favorito.FechaMarcado;

                session.Update (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), id);
                session.Delete (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: FavoritoEN
public FavoritoEN ReadOID (int id
                           )
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoNH)).List<FavoritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> ObtenerFavoritosPorUsuario (string email)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FavoritoNH self where select distinct f from FavoritoNH f left join fetch f.Usuario g where g.Email = :email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FavoritoNHobtenerFavoritosPorUsuarioHQL");
                query.SetParameter ("email", email);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN>();

                // Inicializamos Usuario, Producto e Imágenes para evitar LazyInitializationException
                if (result != null)
                {
                        foreach (var fav in result)
                        {
                                NHibernateUtil.Initialize(fav.Usuario);
                                NHibernateUtil.Initialize(fav.Producto);
                                if (fav.Producto != null)
                                {
                                        NHibernateUtil.Initialize(fav.Producto.Imagen);
                                }
                        }
                }

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> ObtenerFavoritosPorProducto (int ? productoID)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FavoritoNH self where select f from FavoritoNH f left join fetch f.Producto p where p.Id = :productoID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FavoritoNHobtenerFavoritosPorProductoHQL");
                query.SetParameter ("productoID", productoID);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN>();

                // Inicializamos Usuario, Producto e Imágenes para evitar LazyInitializationException
                if (result != null)
                {
                        foreach (var fav in result)
                        {
                                NHibernateUtil.Initialize(fav.Usuario);
                                NHibernateUtil.Initialize(fav.Producto);
                                if (fav.Producto != null)
                                {
                                        NHibernateUtil.Initialize(fav.Producto.Imagen);
                                }
                        }
                }

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
