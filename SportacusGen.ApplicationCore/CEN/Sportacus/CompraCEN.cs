

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class CompraCEN
 *
 */
public partial class CompraCEN
{
private ICompraRepository _ICompraRepository;

public CompraCEN(ICompraRepository _ICompraRepository)
{
        this._ICompraRepository = _ICompraRepository;
}

public ICompraRepository get_ICompraRepository ()
{
        return this._ICompraRepository;
}

public int New_ (Nullable<DateTime> p_fechaCompra, double p_precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum p_estadoCompra)
{
        CompraEN compraEN = null;
        int oid;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.FechaCompra = p_fechaCompra;

        compraEN.PrecioFinal = p_precioFinal;

        compraEN.EstadoCompra = p_estadoCompra;



        oid = _ICompraRepository.New_ (compraEN);
        return oid;
}

public void Modify (int p_Compra_OID, Nullable<DateTime> p_fechaCompra, double p_precioFinal, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoTransaccionEnum p_estadoCompra)
{
        CompraEN compraEN = null;

        //Initialized CompraEN
        compraEN = new CompraEN ();
        compraEN.Id = p_Compra_OID;
        compraEN.FechaCompra = p_fechaCompra;
        compraEN.PrecioFinal = p_precioFinal;
        compraEN.EstadoCompra = p_estadoCompra;
        //Call to CompraRepository

        _ICompraRepository.Modify (compraEN);
}

public void Destroy (int id
                     )
{
        _ICompraRepository.Destroy (id);
}

public CompraEN ReadOID (int id
                         )
{
        CompraEN compraEN = null;

        compraEN = _ICompraRepository.ReadOID (id);
        return compraEN;
}

public System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraEN> list = null;

        list = _ICompraRepository.ReadAll (first, size);
        return list;
}
}
}
