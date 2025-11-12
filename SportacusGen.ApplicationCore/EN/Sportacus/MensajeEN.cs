
using System;
// Definición clase MensajeEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo fechaEnvio
 */
private Nullable<DateTime> fechaEnvio;



/**
 *	Atributo tipoMensaje
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum tipoMensaje;



/**
 *	Atributo urlMultimedia
 */
private string urlMultimedia;



/**
 *	Atributo emisor
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN emisor;



/**
 *	Atributo remitente
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN remitente;



/**
 *	Atributo generar
 */
private SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN generar;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual Nullable<DateTime> FechaEnvio {
        get { return fechaEnvio; } set { fechaEnvio = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum TipoMensaje {
        get { return tipoMensaje; } set { tipoMensaje = value;  }
}



public virtual string UrlMultimedia {
        get { return urlMultimedia; } set { urlMultimedia = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Emisor {
        get { return emisor; } set { emisor = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Remitente {
        get { return remitente; } set { remitente = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN Generar {
        get { return generar; } set { generar = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string contenido, Nullable<DateTime> fechaEnvio, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum tipoMensaje, string urlMultimedia, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN emisor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN remitente, SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN generar
                 )
{
        this.init (Id, contenido, fechaEnvio, tipoMensaje, urlMultimedia, emisor, remitente, generar);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (mensaje.Id, mensaje.Contenido, mensaje.FechaEnvio, mensaje.TipoMensaje, mensaje.UrlMultimedia, mensaje.Emisor, mensaje.Remitente, mensaje.Generar);
}

private void init (int id
                   , string contenido, Nullable<DateTime> fechaEnvio, SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum tipoMensaje, string urlMultimedia, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN emisor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN remitente, SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN generar)
{
        this.Id = id;


        this.Contenido = contenido;

        this.FechaEnvio = fechaEnvio;

        this.TipoMensaje = tipoMensaje;

        this.UrlMultimedia = urlMultimedia;

        this.Emisor = emisor;

        this.Remitente = remitente;

        this.Generar = generar;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
