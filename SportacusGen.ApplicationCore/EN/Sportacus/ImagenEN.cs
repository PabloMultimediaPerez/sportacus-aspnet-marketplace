
using System;
// Definición clase ImagenEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class ImagenEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo url
 */
private string url;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fechaSubida
 */
private Nullable<DateTime> fechaSubida;



/**
 *	Atributo producto
 */
private SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Url {
        get { return url; } set { url = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> FechaSubida {
        get { return fechaSubida; } set { fechaSubida = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public ImagenEN()
{
}



public ImagenEN(int id, string url, string descripcion, Nullable<DateTime> fechaSubida, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto
                )
{
        this.init (Id, url, descripcion, fechaSubida, producto);
}


public ImagenEN(ImagenEN imagen)
{
        this.init (imagen.Id, imagen.Url, imagen.Descripcion, imagen.FechaSubida, imagen.Producto);
}

private void init (int id
                   , string url, string descripcion, Nullable<DateTime> fechaSubida, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto)
{
        this.Id = id;


        this.Url = url;

        this.Descripcion = descripcion;

        this.FechaSubida = fechaSubida;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ImagenEN t = obj as ImagenEN;
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
