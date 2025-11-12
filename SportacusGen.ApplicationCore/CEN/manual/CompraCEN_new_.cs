
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
public int New_ (Nullable<DateTime> p_fechaCompra, double p_precioFinal, int p_producto)
{
        /*PROTECTED REGION ID(SportacusGen.ApplicationCore.CEN.Sportacus_Compra_new__customized) START*/

        CompraEN compraEN = null;

        int oid;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.FechaCompra = p_fechaCompra;

        compraEN.PrecioFinal = p_precioFinal;

        // NS SI ESTA ES LA ASIGNACION CORRECTA PARA EL PRODUCTO DE COMPRA
        compraEN.Producto = new ProductoEN { Id = p_producto };

        if (p_producto != -1) {
                compraEN.Producto = new SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN ();
                compraEN.Producto.Id = p_producto;
        }

        //Call to CompraRepository

        oid = _ICompraRepository.New_ (compraEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
