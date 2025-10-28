

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public int New_ (string p_titulo, string p_contenido, Nullable<DateTime> p_fechaCreacion, bool p_leida, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum p_tipoNotificacion)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Titulo = p_titulo;

        notificacionEN.Contenido = p_contenido;

        notificacionEN.FechaCreacion = p_fechaCreacion;

        notificacionEN.Leida = p_leida;

        notificacionEN.TipoNotificacion = p_tipoNotificacion;



        oid = _INotificacionRepository.New_ (notificacionEN);
        return oid;
}

public void Modify (int p_Notificacion_OID, string p_titulo, string p_contenido, Nullable<DateTime> p_fechaCreacion, bool p_leida, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum p_tipoNotificacion)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Titulo = p_titulo;
        notificacionEN.Contenido = p_contenido;
        notificacionEN.FechaCreacion = p_fechaCreacion;
        notificacionEN.Leida = p_leida;
        notificacionEN.TipoNotificacion = p_tipoNotificacion;
        //Call to NotificacionRepository

        _INotificacionRepository.Modify (notificacionEN);
}

public void Destroy (int id
                     )
{
        _INotificacionRepository.Destroy (id);
}

public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.ReadOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.ReadAll (first, size);
        return list;
}
}
}
