
using System;
// Definición clase ValoracionEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo fechaValoracion
 */
private Nullable<DateTime> fechaValoracion;



/**
 *	Atributo vendedor
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor;



/**
 *	Atributo comprador
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador;



/**
 *	Atributo producto
 */
private SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Nullable<DateTime> FechaValoracion {
        get { return fechaValoracion; } set { fechaValoracion = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Vendedor {
        get { return vendedor; } set { vendedor = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Comprador {
        get { return comprador; } set { comprador = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int puntuacion, string comentario, Nullable<DateTime> fechaValoracion, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto
                    )
{
        this.init (Id, puntuacion, comentario, fechaValoracion, vendedor, comprador, producto);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.Id, valoracion.Puntuacion, valoracion.Comentario, valoracion.FechaValoracion, valoracion.Vendedor, valoracion.Comprador, valoracion.Producto);
}

private void init (int id
                   , int puntuacion, string comentario, Nullable<DateTime> fechaValoracion, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Comentario = comentario;

        this.FechaValoracion = fechaValoracion;

        this.Vendedor = vendedor;

        this.Comprador = comprador;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
