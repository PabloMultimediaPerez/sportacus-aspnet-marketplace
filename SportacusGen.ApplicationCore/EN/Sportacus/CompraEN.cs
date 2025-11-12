
using System;
// Definición clase CompraEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class CompraEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaCompra
 */
private Nullable<DateTime> fechaCompra;



/**
 *	Atributo precioFinal
 */
private double precioFinal;



/**
 *	Atributo estadoCompra
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum estadoCompra;



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



public virtual Nullable<DateTime> FechaCompra {
        get { return fechaCompra; } set { fechaCompra = value;  }
}



public virtual double PrecioFinal {
        get { return precioFinal; } set { precioFinal = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum EstadoCompra {
        get { return estadoCompra; } set { estadoCompra = value;  }
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





public CompraEN()
{
}



public CompraEN(int id, Nullable<DateTime> fechaCompra, double precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum estadoCompra, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto
                )
{
        this.init (Id, fechaCompra, precioFinal, estadoCompra, vendedor, comprador, producto);
}


public CompraEN(CompraEN compra)
{
        this.init (compra.Id, compra.FechaCompra, compra.PrecioFinal, compra.EstadoCompra, compra.Vendedor, compra.Comprador, compra.Producto);
}

private void init (int id
                   , Nullable<DateTime> fechaCompra, double precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum estadoCompra, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto)
{
        this.Id = id;


        this.FechaCompra = fechaCompra;

        this.PrecioFinal = precioFinal;

        this.EstadoCompra = estadoCompra;

        this.Vendedor = vendedor;

        this.Comprador = comprador;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CompraEN t = obj as CompraEN;
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
