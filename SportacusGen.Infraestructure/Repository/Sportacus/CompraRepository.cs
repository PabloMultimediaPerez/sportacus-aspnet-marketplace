
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
 * Clase Compra:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class CompraRepository : BasicRepository, ICompraRepository
{
public CompraRepository() : base ()
{
}


public CompraRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CompraEN ReadOIDDefault (int id
                                )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CompraNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                        else
                                result = session.CreateCriteria (typeof(CompraNH)).List<CompraEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraNH compraNH = (CompraNH)session.Load (typeof(CompraNH), compra.Id);

                compraNH.FechaCompra = compra.FechaCompra;


                compraNH.PrecioFinal = compra.PrecioFinal;


                compraNH.EstadoCompra = compra.EstadoCompra;




                session.Update (compraNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (CompraEN compra)
{
        try
        {
                SessionInitializeTransaction ();
                CompraNH compraNH = (CompraNH)session.Load (typeof(CompraNH), compra.Id);

                compraNH.FechaCompra = compra.FechaCompra;


                compraNH.PrecioFinal = compra.PrecioFinal;


                compraNH.EstadoCompra = compra.EstadoCompra;

                session.Update (compraNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
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
                CompraNH compraNH = (CompraNH)session.Load (typeof(CompraNH), id);
                session.Delete (compraNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CompraEN
public CompraEN ReadOID (int id
                         )
{
        CompraEN compraEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraEN = (CompraEN)session.Get (typeof(CompraNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CompraNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CompraEN>();
                else
                        result = session.CreateCriteria (typeof(CompraNH)).List<CompraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> ObtenerComprasPorUsuario (string p_UsuarioOID)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CompraNH self where select c from CompraNH c left join fetch c.Comprador comp where comp.Email = :p_UsuarioOID order by c.FechaCompra desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CompraNHobtenerComprasPorUsuarioHQL");
                query.SetParameter ("p_UsuarioOID", p_UsuarioOID);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> ObtenerVentasPorUsuario (string p_UsuarioOID)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CompraNH self where select c from CompraNH c left join fetch c.Vendedor vend where vend.Email = :p_UsuarioOID order by c.FechaCompra desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CompraNHobtenerVentasPorUsuarioHQL");
                query.SetParameter ("p_UsuarioOID", p_UsuarioOID);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int New_ (CompraEN compra)
{
        CompraNH compraNH = new CompraNH (compra);

        try
        {
                SessionInitializeTransaction ();
                if (compra.Producto != null) {
                        // Argumento OID y no colección.
                        compraNH
                        .Producto = (SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN), compra.Producto.Id);

                        compraNH.Producto.Compra
                        .Add (compraNH);
                }

                session.Save (compraNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in CompraRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraNH.Id;
}
}
}
