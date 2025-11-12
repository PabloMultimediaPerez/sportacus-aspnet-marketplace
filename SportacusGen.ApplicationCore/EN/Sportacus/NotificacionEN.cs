
using System;
// Definición clase NotificacionEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo leida
 */
private bool leida;



/**
 *	Atributo tipoNotificacion
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum tipoNotificacion;



/**
 *	Atributo mensaje
 */
private SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN mensaje;



/**
 *	Atributo notificado
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN notificado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual bool Leida {
        get { return leida; } set { leida = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum TipoNotificacion {
        get { return tipoNotificacion; } set { tipoNotificacion = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Notificado {
        get { return notificado; } set { notificado = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, string titulo, string contenido, Nullable<DateTime> fechaCreacion, bool leida, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum tipoNotificacion, SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN mensaje, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN notificado
                      )
{
        this.init (Id, titulo, contenido, fechaCreacion, leida, tipoNotificacion, mensaje, notificado);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.Titulo, notificacion.Contenido, notificacion.FechaCreacion, notificacion.Leida, notificacion.TipoNotificacion, notificacion.Mensaje, notificacion.Notificado);
}

private void init (int id
                   , string titulo, string contenido, Nullable<DateTime> fechaCreacion, bool leida, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum tipoNotificacion, SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN mensaje, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN notificado)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Contenido = contenido;

        this.FechaCreacion = fechaCreacion;

        this.Leida = leida;

        this.TipoNotificacion = tipoNotificacion;

        this.Mensaje = mensaje;

        this.Notificado = notificado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
