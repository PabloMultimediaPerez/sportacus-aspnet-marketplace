
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
 * Clase Chat:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class ChatRepository : BasicRepository, IChatRepository
{
public ChatRepository() : base ()
{
}


public ChatRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ChatEN ReadOIDDefault (int id
                              )
{
        ChatEN chatEN = null;

        try
        {
                SessionInitializeTransaction ();
                chatEN = (ChatEN)session.Get (typeof(ChatNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return chatEN;
}

public System.Collections.Generic.IList<ChatEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ChatEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ChatNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ChatEN>();
                        else
                                result = session.CreateCriteria (typeof(ChatNH)).List<ChatEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ChatEN chat)
{
        try
        {
                SessionInitializeTransaction ();
                ChatNH chatNH = (ChatNH)session.Load (typeof(ChatNH), chat.Id);

                chatNH.FechaInicio = chat.FechaInicio;


                chatNH.Activo = chat.Activo;




                session.Update (chatNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ChatEN chat)
{
        ChatNH chatNH = new ChatNH (chat);

        try
        {
                SessionInitializeTransaction ();

                session.Save (chatNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return chatNH.Id;
}

public void Modify (ChatEN chat)
{
        try
        {
                SessionInitializeTransaction ();
                ChatNH chatNH = (ChatNH)session.Load (typeof(ChatNH), chat.Id);

                chatNH.FechaInicio = chat.FechaInicio;


                chatNH.Activo = chat.Activo;

                session.Update (chatNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
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
                ChatNH chatNH = (ChatNH)session.Load (typeof(ChatNH), id);
                session.Delete (chatNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ChatEN
public ChatEN ReadOID (int id
                       )
{
        ChatEN chatEN = null;

        try
        {
                SessionInitializeTransaction ();
                chatEN = (ChatEN)session.Get (typeof(ChatNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return chatEN;
}

public System.Collections.Generic.IList<ChatEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ChatEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ChatNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ChatEN>();
                else
                        result = session.CreateCriteria (typeof(ChatNH)).List<ChatEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ChatRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
