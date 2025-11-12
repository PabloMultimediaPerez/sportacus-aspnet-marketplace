

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class ImagenCEN
 *
 */
public partial class ImagenCEN
{
private IImagenRepository _IImagenRepository;

public ImagenCEN(IImagenRepository _IImagenRepository)
{
        this._IImagenRepository = _IImagenRepository;
}

public IImagenRepository get_IImagenRepository ()
{
        return this._IImagenRepository;
}

public int New_ (string p_url, string p_descripcion, Nullable<DateTime> p_fechaSubida, int p_producto)
{
        ImagenEN imagenEN = null;
        int oid;

        //Initialized ImagenEN
        imagenEN = new ImagenEN ();
        imagenEN.Url = p_url;

        imagenEN.Descripcion = p_descripcion;

        imagenEN.FechaSubida = p_fechaSubida;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                imagenEN.Producto = new SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN ();
                imagenEN.Producto.Id = p_producto;
        }



        oid = _IImagenRepository.New_ (imagenEN);
        return oid;
}

public void Modify (int p_Imagen_OID, string p_url, string p_descripcion, Nullable<DateTime> p_fechaSubida)
{
        ImagenEN imagenEN = null;

        //Initialized ImagenEN
        imagenEN = new ImagenEN ();
        imagenEN.Id = p_Imagen_OID;
        imagenEN.Url = p_url;
        imagenEN.Descripcion = p_descripcion;
        imagenEN.FechaSubida = p_fechaSubida;
        //Call to ImagenRepository

        _IImagenRepository.Modify (imagenEN);
}

public void Destroy (int id
                     )
{
        _IImagenRepository.Destroy (id);
}

public ImagenEN ReadOID (int id
                         )
{
        ImagenEN imagenEN = null;

        imagenEN = _IImagenRepository.ReadOID (id);
        return imagenEN;
}

public System.Collections.Generic.IList<ImagenEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ImagenEN> list = null;

        list = _IImagenRepository.ReadAll (first, size);
        return list;
}
}
}
