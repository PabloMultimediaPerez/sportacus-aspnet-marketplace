
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





                mensajeNH.Leido = mensaje.Leido;

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
                if (mensaje.Emisor != null) {
                        // Argumento OID y no colección.
                        mensajeNH
                        .Emisor = (SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN), mensaje.Emisor.Email);

                        mensajeNH.Emisor.Emitido
                        .Add (mensajeNH);
                }
                if (mensaje.Receptor != null) {
                        // Argumento OID y no colección.
                        mensajeNH
                        .Receptor = (SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN)session.Load (typeof(SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN), mensaje.Receptor.Email);

                        mensajeNH.Receptor.Recibido
                        .Add (mensajeNH);
                }

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


                mensajeNH.Leido = mensaje.Leido;

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

public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerMensajesEntreUsuarios (string email1, string email2)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeNH self where select m from MensajeNH m where(m.Emisor.Email = :email1 and m.Receptor.Email = :email2) or (m.Emisor.Email = :email2 and m.Receptor.Email = :email1) order by m.FechaEnvio asc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeNHobtenerMensajesEntreUsuariosHQL");
                query.SetParameter ("email1", email1);
                query.SetParameter ("email2", email2);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN>();

                // Inicializamos Emisor y Receptor para evitar LazyInitializationException
                if (result != null)
                {
                        foreach (var msg in result)
                        {
                                NHibernateUtil.Initialize(msg.Emisor);
                                NHibernateUtil.Initialize(msg.Receptor);
                        }
                }

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
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerConversacionesPorUsuario (string email)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeNH self where from MensajeNH m where m.Id in (select max(m2.Id) from MensajeNH m2 where m2.Emisor.Email = :email or m2.Receptor.Email = :email group by (case when m2.Emisor.Email = :email then m2.Receptor.Email else m2.Emisor.Email end)) order by m.FechaEnvio desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeNHobtenerConversacionesPorUsuarioHQL");
                query.SetParameter ("email", email);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN>();

                // Inicializamos Emisor y Receptor para evitar LazyInitializationException
                if (result != null)
                {
                        foreach (var msg in result)
                        {
                                NHibernateUtil.Initialize(msg.Emisor);
                                NHibernateUtil.Initialize(msg.Receptor);
                        }
                }

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
