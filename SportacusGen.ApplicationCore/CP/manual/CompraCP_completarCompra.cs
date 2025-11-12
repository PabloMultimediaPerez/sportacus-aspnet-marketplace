
using System;
using System.Text;

using System.Collections.Generic;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.ApplicationCore.CEN.Sportacus;



/*PROTECTED REGION ID(usingSportacusGen.ApplicationCore.CP.Sportacus_Compra_completarCompra) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace SportacusGen.ApplicationCore.CP.Sportacus
{
public partial class CompraCP : GenericBasicCP
{
public void CompletarCompra (int p_oid)
{
        /*PROTECTED REGION ID(SportacusGen.ApplicationCore.CP.Sportacus_Compra_completarCompra) ENABLED START*/

        CompraCEN compraCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                compraCEN = new  CompraCEN (CPSession.UnitRepo.CompraRepository);
                ProductoCEN productoCEN = new ProductoCEN (CPSession.UnitRepo.ProductoRepository);


                // Write here your custom transaction ...

                CompraEN compraEN = compraCEN.ReadOID (p_oid);
                if (compraEN != null && compraEN.EstadoCompra != Enumerated.Sportacus.EstadoTransaccionEnum.pendiente) {
                        throw new ModelException ("La compra ya ha sido completada o cancelada.");
                }

                compraEN.EstadoCompra = Enumerated.Sportacus.EstadoTransaccionEnum.completada;

                if (compraEN.Producto != null && compraEN.Producto.Disponible != true) {
                        throw new ModelException ("El producto asociado a la compra no existe o no esta disponible.");
                }

                compraEN.Producto.Disponible = false;
                productoCEN.get_IProductoRepository ().Modify (compraEN.Producto);
                compraCEN.Modify (p_oid, compraEN.FechaCompra, compraEN.PrecioFinal, compraEN.EstadoCompra);





                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
