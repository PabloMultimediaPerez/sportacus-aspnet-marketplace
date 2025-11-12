

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class ChatCEN
 *
 */
public partial class ChatCEN
{
private IChatRepository _IChatRepository;

public ChatCEN(IChatRepository _IChatRepository)
{
        this._IChatRepository = _IChatRepository;
}

public IChatRepository get_IChatRepository ()
{
        return this._IChatRepository;
}

public int New_ (Nullable<DateTime> p_fechaInicio, bool p_activo)
{
        ChatEN chatEN = null;
        int oid;

        //Initialized ChatEN
        chatEN = new ChatEN ();
        chatEN.FechaInicio = p_fechaInicio;

        chatEN.Activo = p_activo;



        oid = _IChatRepository.New_ (chatEN);
        return oid;
}

public void Modify (int p_Chat_OID, Nullable<DateTime> p_fechaInicio, bool p_activo)
{
        ChatEN chatEN = null;

        //Initialized ChatEN
        chatEN = new ChatEN ();
        chatEN.Id = p_Chat_OID;
        chatEN.FechaInicio = p_fechaInicio;
        chatEN.Activo = p_activo;
        //Call to ChatRepository

        _IChatRepository.Modify (chatEN);
}

public void Destroy (int id
                     )
{
        _IChatRepository.Destroy (id);
}

public ChatEN ReadOID (int id
                       )
{
        ChatEN chatEN = null;

        chatEN = _IChatRepository.ReadOID (id);
        return chatEN;
}

public System.Collections.Generic.IList<ChatEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ChatEN> list = null;

        list = _IChatRepository.ReadAll (first, size);
        return list;
}
}
}
