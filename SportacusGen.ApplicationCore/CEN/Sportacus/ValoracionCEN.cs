

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int New_ (int p_puntuacion, string p_comentario, Nullable<DateTime> p_fechaValoracion, string p_vendedor, string p_comprador, int p_producto)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Puntuacion = p_puntuacion;

        valoracionEN.Comentario = p_comentario;

        valoracionEN.FechaValoracion = p_fechaValoracion;


        if (p_vendedor != null) {
                // El argumento p_vendedor -> Property vendedor es oid = false
                // Lista de oids id
                valoracionEN.Vendedor = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                valoracionEN.Vendedor.Email = p_vendedor;
        }


        if (p_comprador != null) {
                // El argumento p_comprador -> Property comprador es oid = false
                // Lista de oids id
                valoracionEN.Comprador = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                valoracionEN.Comprador.Email = p_comprador;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                valoracionEN.Producto = new SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN ();
                valoracionEN.Producto.Id = p_producto;
        }



        oid = _IValoracionRepository.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, int p_puntuacion, string p_comentario, Nullable<DateTime> p_fechaValoracion)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Puntuacion = p_puntuacion;
        valoracionEN.Comentario = p_comentario;
        valoracionEN.FechaValoracion = p_fechaValoracion;
        //Call to ValoracionRepository

        _IValoracionRepository.Modify (valoracionEN);
}

public void Destroy (int id
                     )
{
        _IValoracionRepository.Destroy (id);
}

public ValoracionEN ReadOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.ReadOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> ObtenerValoracionesPorUsuario (string p_UsuarioOID)
{
        return _IValoracionRepository.ObtenerValoracionesPorUsuario (p_UsuarioOID);
}
}
}
