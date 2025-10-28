
using System;
// Definición clase UsuarioEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo fechaRegistro
 */
private Nullable<DateTime> fechaRegistro;



/**
 *	Atributo password
 */
private string password;



/**
 *	Atributo esAdministrador
 */
private bool esAdministrador;



/**
 *	Atributo chat_vendedor
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_vendedor;



/**
 *	Atributo chat_comprador
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_comprador;



/**
 *	Atributo emitido
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> emitido;



/**
 *	Atributo recibido
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> recibido;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN> notificacion;



/**
 *	Atributo valoraciones_recibidas
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_recibidas;



/**
 *	Atributo valoraciones_realizadas
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_realizadas;



/**
 *	Atributo venta
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> venta;



/**
 *	Atributo compra
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra;



/**
 *	Atributo en_venta
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> en_venta;



/**
 *	Atributo favorito
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito;



/**
 *	Atributo pass
 */
private String pass;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual Nullable<DateTime> FechaRegistro {
        get { return fechaRegistro; } set { fechaRegistro = value;  }
}



public virtual string Password {
        get { return password; } set { password = value;  }
}



public virtual bool EsAdministrador {
        get { return esAdministrador; } set { esAdministrador = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> Chat_vendedor {
        get { return chat_vendedor; } set { chat_vendedor = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> Chat_comprador {
        get { return chat_comprador; } set { chat_comprador = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> Emitido {
        get { return emitido; } set { emitido = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> Recibido {
        get { return recibido; } set { recibido = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> Valoraciones_recibidas {
        get { return valoraciones_recibidas; } set { valoraciones_recibidas = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> Valoraciones_realizadas {
        get { return valoraciones_realizadas; } set { valoraciones_realizadas = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> Venta {
        get { return venta; } set { venta = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> Compra {
        get { return compra; } set { compra = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> En_venta {
        get { return en_venta; } set { en_venta = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
        chat_vendedor = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN>();
        chat_comprador = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN>();
        emitido = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN>();
        recibido = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN>();
        notificacion = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN>();
        valoraciones_recibidas = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN>();
        valoraciones_realizadas = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN>();
        venta = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN>();
        compra = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN>();
        en_venta = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN>();
        favorito = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN>();
}



public UsuarioEN(int id, string email, string nombre, int telefono, string direccion, Nullable<DateTime> fechaRegistro, string password, bool esAdministrador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_vendedor, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_comprador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> emitido, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> recibido, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN> notificacion, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_recibidas, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_realizadas, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> venta, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> en_venta, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito, String pass
                 )
{
        this.init (Id, email, nombre, telefono, direccion, fechaRegistro, password, esAdministrador, chat_vendedor, chat_comprador, emitido, recibido, notificacion, valoraciones_recibidas, valoraciones_realizadas, venta, compra, en_venta, favorito, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Email, usuario.Nombre, usuario.Telefono, usuario.Direccion, usuario.FechaRegistro, usuario.Password, usuario.EsAdministrador, usuario.Chat_vendedor, usuario.Chat_comprador, usuario.Emitido, usuario.Recibido, usuario.Notificacion, usuario.Valoraciones_recibidas, usuario.Valoraciones_realizadas, usuario.Venta, usuario.Compra, usuario.En_venta, usuario.Favorito, usuario.Pass);
}

private void init (int id
                   , string email, string nombre, int telefono, string direccion, Nullable<DateTime> fechaRegistro, string password, bool esAdministrador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_vendedor, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ChatEN> chat_comprador, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> emitido, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> recibido, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.NotificacionEN> notificacion, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_recibidas, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoraciones_realizadas, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> venta, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> en_venta, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito, String pass)
{
        this.Id = id;


        this.Email = email;

        this.Nombre = nombre;

        this.Telefono = telefono;

        this.Direccion = direccion;

        this.FechaRegistro = fechaRegistro;

        this.Password = password;

        this.EsAdministrador = esAdministrador;

        this.Chat_vendedor = chat_vendedor;

        this.Chat_comprador = chat_comprador;

        this.Emitido = emitido;

        this.Recibido = recibido;

        this.Notificacion = notificacion;

        this.Valoraciones_recibidas = valoraciones_recibidas;

        this.Valoraciones_realizadas = valoraciones_realizadas;

        this.Venta = venta;

        this.Compra = compra;

        this.En_venta = en_venta;

        this.Favorito = favorito;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
