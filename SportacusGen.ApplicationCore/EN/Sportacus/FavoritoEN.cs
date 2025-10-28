
using System;
// Definición clase FavoritoEN
namespace SportacusGen.ApplicationCore.EN.Sportacus
{
public partial class FavoritoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaMarcado
 */
private Nullable<DateTime> fechaMarcado;



/**
 *	Atributo producto
 */
private SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto;



/**
 *	Atributo guarda
 */
private System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN> guarda;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaMarcado {
        get { return fechaMarcado; } set { fechaMarcado = value;  }
}



public virtual SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN> Guarda {
        get { return guarda; } set { guarda = value;  }
}





public FavoritoEN()
{
        guarda = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN>();
}



public FavoritoEN(int id, Nullable<DateTime> fechaMarcado, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN> guarda
                  )
{
        this.init (Id, fechaMarcado, producto, guarda);
}


public FavoritoEN(FavoritoEN favorito)
{
        this.init (favorito.Id, favorito.FechaMarcado, favorito.Producto, favorito.Guarda);
}

private void init (int id
                   , Nullable<DateTime> fechaMarcado, SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN producto, System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN> guarda)
{
        this.Id = id;


        this.FechaMarcado = fechaMarcado;

        this.Producto = producto;

        this.Guarda = guarda;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoEN t = obj as FavoritoEN;
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
