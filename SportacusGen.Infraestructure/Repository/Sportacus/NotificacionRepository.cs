
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
 * Clase Notificacion:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class NotificacionRepository : BasicRepository, INotificacionRepository
{
public NotificacionRepository() : base ()
{
}


public NotificacionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public NotificacionEN ReadOIDDefault (int id
                                      )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionNH)).List<NotificacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), notificacion.Id);

                notificacionNH.Titulo = notificacion.Titulo;


                notificacionNH.Contenido = notificacion.Contenido;


                notificacionNH.FechaCreacion = notificacion.FechaCreacion;


                notificacionNH.Leida = notificacion.Leida;


                notificacionNH.TipoNotificacion = notificacion.TipoNotificacion;



                session.Update (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEN notificacion)
{
        NotificacionNH notificacionNH = new NotificacionNH (notificacion);

        try
        {
                SessionInitializeTransaction ();

                session.Save (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionNH.Id;
}

public void Modify (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), notificacion.Id);

                notificacionNH.Titulo = notificacion.Titulo;


                notificacionNH.Contenido = notificacion.Contenido;


                notificacionNH.FechaCreacion = notificacion.FechaCreacion;


                notificacionNH.Leida = notificacion.Leida;


                notificacionNH.TipoNotificacion = notificacion.TipoNotificacion;

                session.Update (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
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
                NotificacionNH notificacionNH = (NotificacionNH)session.Load (typeof(NotificacionNH), id);
                session.Delete (notificacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionEN
public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionNH)).List<NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
