

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeRepository _IMensajeRepository;

public MensajeCEN(IMensajeRepository _IMensajeRepository)
{
        this._IMensajeRepository = _IMensajeRepository;
}

public IMensajeRepository get_IMensajeRepository ()
{
        return this._IMensajeRepository;
}

public int New_ (string p_contenido, Nullable<DateTime> p_fechaEnvio, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum p_tipoMensaje, string p_urlMultimedia, string p_emisor, string p_receptor, bool p_leido)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;

        mensajeEN.FechaEnvio = p_fechaEnvio;

        mensajeEN.TipoMensaje = p_tipoMensaje;

        mensajeEN.UrlMultimedia = p_urlMultimedia;


        if (p_emisor != null) {
                // El argumento p_emisor -> Property emisor es oid = false
                // Lista de oids id
                mensajeEN.Emisor = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                mensajeEN.Emisor.Email = p_emisor;
        }


        if (p_receptor != null) {
                // El argumento p_receptor -> Property receptor es oid = false
                // Lista de oids id
                mensajeEN.Receptor = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                mensajeEN.Receptor.Email = p_receptor;
        }

        mensajeEN.Leido = p_leido;



        oid = _IMensajeRepository.New_ (mensajeEN);
        return oid;
}

public void Modify (int p_Mensaje_OID, string p_contenido, Nullable<DateTime> p_fechaEnvio, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum p_tipoMensaje, string p_urlMultimedia, bool p_leido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.FechaEnvio = p_fechaEnvio;
        mensajeEN.TipoMensaje = p_tipoMensaje;
        mensajeEN.UrlMultimedia = p_urlMultimedia;
        mensajeEN.Leido = p_leido;
        //Call to MensajeRepository

        _IMensajeRepository.Modify (mensajeEN);
}

public void Destroy (int id
                     )
{
        _IMensajeRepository.Destroy (id);
}

public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeRepository.ReadOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerMensajesEntreUsuarios (string email1, string email2)
{
        return _IMensajeRepository.ObtenerMensajesEntreUsuarios (email1, email2);
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerConversacionesPorUsuario (string email)
{
        return _IMensajeRepository.ObtenerConversacionesPorUsuario (email);
}
}
}
