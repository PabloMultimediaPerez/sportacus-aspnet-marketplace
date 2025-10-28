
using System;
// Definición clase ProductoEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class ProductoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo estado
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum estado;



/**
 *	Atributo categoria
 */
private SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum categoria;



/**
 *	Atributo fechaPublicacion
 */
private Nullable<DateTime> fechaPublicacion;



/**
 *	Atributo disponible
 */
private bool disponible;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoracion;



/**
 *	Atributo compra
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra;



/**
 *	Atributo favorito
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito;



/**
 *	Atributo imagen
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ImagenEN> imagen;



/**
 *	Atributo vende
 */
private SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vende;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual Nullable<DateTime> FechaPublicacion {
        get { return fechaPublicacion; } set { fechaPublicacion = value;  }
}



public virtual bool Disponible {
        get { return disponible; } set { disponible = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> Compra {
        get { return compra; } set { compra = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ImagenEN> Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN Vende {
        get { return vende; } set { vende = value;  }
}





public ProductoEN()
{
        valoracion = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN>();
        compra = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN>();
        favorito = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN>();
        imagen = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.ImagenEN>();
}



public ProductoEN(int id, string titulo, string descripcion, double precio, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum estado, SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum categoria, Nullable<DateTime> fechaPublicacion, bool disponible, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoracion, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ImagenEN> imagen, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vende
                  )
{
        this.init (Id, titulo, descripcion, precio, estado, categoria, fechaPublicacion, disponible, valoracion, compra, favorito, imagen, vende);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.Id, producto.Titulo, producto.Descripcion, producto.Precio, producto.Estado, producto.Categoria, producto.FechaPublicacion, producto.Disponible, producto.Valoracion, producto.Compra, producto.Favorito, producto.Imagen, producto.Vende);
}

private void init (int id
                   , string titulo, string descripcion, double precio, SportacusGen.ApplicationCore.Enumerated.Sportacus.EstadoProductoEnum estado, SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum categoria, Nullable<DateTime> fechaPublicacion, bool disponible, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ValoracionEN> valoracion, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> compra, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> favorito, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ImagenEN> imagen, SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN vende)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Estado = estado;

        this.Categoria = categoria;

        this.FechaPublicacion = fechaPublicacion;

        this.Disponible = disponible;

        this.Valoracion = valoracion;

        this.Compra = compra;

        this.Favorito = favorito;

        this.Imagen = imagen;

        this.Vende = vende;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
