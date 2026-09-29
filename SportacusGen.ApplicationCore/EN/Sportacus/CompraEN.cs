
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
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



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



/**
 *	Atributo fechaVenta
 */
private Nullable<DateTime> fechaVenta;



/**
 *	Atributo metodoPago
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.MetodoPagoEnum metodoPago;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
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



public virtual Nullable<DateTime> FechaVenta {
        get { return fechaVenta; } set { fechaVenta = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.MetodoPagoEnum MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}





public CompraEN()
{
}



public CompraEN(int id, Nullable<DateTime> fechaInicio, double precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum estadoCompra, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto, Nullable<DateTime> fechaVenta, SportacusGen.ApplicationCore.Enumerated.Sportacus.MetodoPagoEnum metodoPago
                )
{
        this.init (Id, fechaInicio, precioFinal, estadoCompra, vendedor, comprador, producto, fechaVenta, metodoPago);
}


public CompraEN(CompraEN compra)
{
        this.init (compra.Id, compra.FechaInicio, compra.PrecioFinal, compra.EstadoCompra, compra.Vendedor, compra.Comprador, compra.Producto, compra.FechaVenta, compra.MetodoPago);
}

private void init (int id
                   , Nullable<DateTime> fechaInicio, double precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum estadoCompra, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vendedor, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN comprador, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto, Nullable<DateTime> fechaVenta, SportacusGen.ApplicationCore.Enumerated.Sportacus.MetodoPagoEnum metodoPago)
{
        this.Id = id;


        this.FechaInicio = fechaInicio;

        this.PrecioFinal = precioFinal;

        this.EstadoCompra = estadoCompra;

        this.Vendedor = vendedor;

        this.Comprador = comprador;

        this.Producto = producto;

        this.FechaVenta = fechaVenta;

        this.MetodoPago = metodoPago;
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
