
using System;
// Definición clase ChatEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class ChatEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo activo
 */
private bool activo;



/**
 *	Atributo vendedor
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor;



/**
 *	Atributo comprador
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador;



/**
 *	Atributo mensaje
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> mensaje;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual bool Activo {
        get { return activo; } set { activo = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Vendedor {
        get { return vendedor; } set { vendedor = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Comprador {
        get { return comprador; } set { comprador = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}





public ChatEN()
{
        mensaje = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN>();
}



public ChatEN(int id, Nullable<DateTime> fechaInicio, bool activo, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> mensaje
              )
{
        this.init (Id, fechaInicio, activo, vendedor, comprador, mensaje);
}


public ChatEN(ChatEN chat)
{
        this.init (chat.Id, chat.FechaInicio, chat.Activo, chat.Vendedor, chat.Comprador, chat.Mensaje);
}

private void init (int id
                   , Nullable<DateTime> fechaInicio, bool activo, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> mensaje)
{
        this.Id = id;


        this.FechaInicio = fechaInicio;

        this.Activo = activo;

        this.Vendedor = vendedor;

        this.Comprador = comprador;

        this.Mensaje = mensaje;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ChatEN t = obj as ChatEN;
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
