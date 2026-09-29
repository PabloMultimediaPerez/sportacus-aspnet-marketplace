
using System;
using System.Text;
using System.Collections.Generic;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


/*PROTECTED REGION ID(usingSportacusGen.ApplicationCore.CEN.Sportacus_Compra_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
public partial class CompraCEN
{
public int New_ (Nullable<DateTime> p_fechaInicio, double p_precioFinal, int p_producto, string p_comprador, string p_vendedor, SportacusGen.ApplicationCore.Enumerated.Sportacus.MetodoPagoEnum p_metodoPago)
{
        /*PROTECTED REGION ID(SportacusGen.ApplicationCore.CEN.Sportacus_Compra_new__customized) ENABLED START*/

        CompraEN compraEN = null;

        int oid;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.FechaInicio = p_fechaInicio;

        compraEN.PrecioFinal = p_precioFinal;

        compraEN.EstadoCompra = Enumerated.Sportacus.EstadoTransaccionEnum.pendiente;

        compraEN.MetodoPago = p_metodoPago;

        // compraEN.FechaVenta = DateTime.Today;


        if (p_producto != -1) {
                compraEN.Producto = new SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN ();
                compraEN.Producto.Id = p_producto;
        }
        else {
                throw new ModelException ("El producto es obligatorio en la compra");
        }

        if (p_comprador != null) {
                compraEN.Comprador = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                compraEN.Comprador.Email = p_comprador;
        }
        else {
                throw new ModelException ("El comprador es obligatorio en la compra");
        }

        if (p_vendedor != null) {
                compraEN.Vendedor = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                compraEN.Vendedor.Email = p_vendedor;
        }
        else {
                throw new ModelException ("El vendedor es obligatorio en la compra");
        }

        //Call to CompraRepository

        oid = _ICompraRepository.New_ (compraEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
