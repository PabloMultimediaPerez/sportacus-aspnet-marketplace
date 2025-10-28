
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
 * Clase Mensaje:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class MensajeRepository : BasicRepository, IMensajeRepository
{
public MensajeRepository() : base ()
{
}


public MensajeRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MensajeEN ReadOIDDefault (int id
                                 )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;


                mensajeNH.FechaEnvio = mensaje.FechaEnvio;


                mensajeNH.TipoMensaje = mensaje.TipoMensaje;


                mensajeNH.UrlMultimedia = mensaje.UrlMultimedia;





                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MensajeEN mensaje)
{
        MensajeNH mensajeNH = new MensajeNH (mensaje);

        try
        {
                SessionInitializeTransaction ();

                session.Save (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeNH.Id;
}

public void Modify (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;


                mensajeNH.FechaEnvio = mensaje.FechaEnvio;


                mensajeNH.TipoMensaje = mensaje.TipoMensaje;


                mensajeNH.UrlMultimedia = mensaje.UrlMultimedia;

                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
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
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), id);
                session.Delete (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MensajeEN
public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MensajeNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                else
                        result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
