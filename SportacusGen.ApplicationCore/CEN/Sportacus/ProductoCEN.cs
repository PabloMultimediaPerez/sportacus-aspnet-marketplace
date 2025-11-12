

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoRepository _IProductoRepository;

public ProductoCEN(IProductoRepository _IProductoRepository)
{
        this._IProductoRepository = _IProductoRepository;
}

public IProductoRepository get_IProductoRepository ()
{
        return this._IProductoRepository;
}

public int New_ (string p_titulo, string p_descripcion, double p_precio, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum p_estado, SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum p_categoria, Nullable<DateTime> p_fechaPublicacion, bool p_disponible)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Titulo = p_titulo;

        productoEN.Descripcion = p_descripcion;

        productoEN.Precio = p_precio;

        productoEN.Estado = p_estado;

        productoEN.Categoria = p_categoria;

        productoEN.FechaPublicacion = p_fechaPublicacion;

        productoEN.Disponible = p_disponible;



        oid = _IProductoRepository.New_ (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, string p_titulo, string p_descripcion, double p_precio, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum p_estado, SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum p_categoria, Nullable<DateTime> p_fechaPublicacion, bool p_disponible)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Titulo = p_titulo;
        productoEN.Descripcion = p_descripcion;
        productoEN.Precio = p_precio;
        productoEN.Estado = p_estado;
        productoEN.Categoria = p_categoria;
        productoEN.FechaPublicacion = p_fechaPublicacion;
        productoEN.Disponible = p_disponible;
        //Call to ProductoRepository

        _IProductoRepository.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoRepository.Destroy (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoRepository.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> BuscarPorTexto (string texto)
{
        return _IProductoRepository.BuscarPorTexto (texto);
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> FiltrarPorCategoria (SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum ? categoria)
{
        return _IProductoRepository.FiltrarPorCategoria (categoria);
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> FiltrarPorPrecio (double? minPrecio, double ? maxPrecio)
{
        return _IProductoRepository.FiltrarPorPrecio (minPrecio, maxPrecio);
}
}
}
