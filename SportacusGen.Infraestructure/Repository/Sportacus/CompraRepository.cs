
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


public int New_ (CompraEN compra)
{
        CompraNH compraNH = new CompraNH (compra);

        try
        {
                SessionInitializeTransaction ();

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
}
}
