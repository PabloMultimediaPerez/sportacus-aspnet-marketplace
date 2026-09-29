
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
 * Clase Valoracion:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class ValoracionRepository : BasicRepository, IValoracionRepository
{
public ValoracionRepository() : base ()
{
}


public ValoracionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ValoracionEN ReadOIDDefault (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionNH)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), valoracion.Id);

                valoracionNH.Puntuacion = valoracion.Puntuacion;


                valoracionNH.Comentario = valoracion.Comentario;


                valoracionNH.FechaValoracion = valoracion.FechaValoracion;




                session.Update (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionEN valoracion)
{
        ValoracionNH valoracionNH = new ValoracionNH (valoracion);

        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Vendedor != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Vendedor = (SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN), valoracion.Vendedor.Email);

                        valoracionNH.Vendedor.Valoraciones_recibidas
                        .Add (valoracionNH);
                }
                if (valoracion.Comprador != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Comprador = (SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN), valoracion.Comprador.Email);

                        valoracionNH.Comprador.Valoraciones_realizadas
                        .Add (valoracionNH);
                }
                if (valoracion.Producto != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Producto = (SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN), valoracion.Producto.Id);

                        valoracionNH.Producto.Valoracion
                        .Add (valoracionNH);
                }

                session.Save (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionNH.Id;
}

public void Modify (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), valoracion.Id);

                valoracionNH.Puntuacion = valoracion.Puntuacion;


                valoracionNH.Comentario = valoracion.Comentario;


                valoracionNH.FechaValoracion = valoracion.FechaValoracion;

                session.Update (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
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
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), id);
                session.Delete (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ValoracionEN
public ValoracionEN ReadOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionNH)).List<ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> ObtenerValoracionesPorUsuario (string p_UsuarioOID)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionNH self where select distinct v from ValoracionNH v left join fetch v.Vendedor vend left join fetch v.Comprador comp where vend.Email = :p_UsuarioOID or comp.Email = :p_UsuarioOID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionNHobtenerValoracionesPorUsuarioHQL");
                query.SetParameter ("p_UsuarioOID", p_UsuarioOID);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
