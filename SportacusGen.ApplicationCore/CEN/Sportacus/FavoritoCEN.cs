

using System;
using System.Text;
using System.Collections.Generic;

using SportacusGen.ApplicationCore.Exceptions;

using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;


namespace SportacusGen.ApplicationCore.CEN.Sportacus
{
/*
 *      Definition of the class FavoritoCEN
 *
 */
public partial class FavoritoCEN
{
private IFavoritoRepository _IFavoritoRepository;

public FavoritoCEN(IFavoritoRepository _IFavoritoRepository)
{
        this._IFavoritoRepository = _IFavoritoRepository;
}

public IFavoritoRepository get_IFavoritoRepository ()
{
        return this._IFavoritoRepository;
}

public int New_ (Nullable<DateTime> p_fechaMarcado, int p_producto, System.Collections.Generic.IList<string> p_guarda)
{
        FavoritoEN favoritoEN = null;
        int oid;

        //Initialized FavoritoEN
        favoritoEN = new FavoritoEN ();
        favoritoEN.FechaMarcado = p_fechaMarcado;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                favoritoEN.Producto = new SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN ();
                favoritoEN.Producto.Id = p_producto;
        }


        favoritoEN.Guarda = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN>();
        if (p_guarda != null) {
                foreach (string item in p_guarda) {
                        SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN en = new SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN ();
                        en.Email = item;
                        favoritoEN.Guarda.Add (en);
                }
        }

        else{
                favoritoEN.Guarda = new System.Collections.Generic.List<SportacusGen.ApplicationCore.EN.Sportacus.UsuarioEN>();
        }



        oid = _IFavoritoRepository.New_ (favoritoEN);
        return oid;
}

public void Modify (int p_Favorito_OID, Nullable<DateTime> p_fechaMarcado)
{
        FavoritoEN favoritoEN = null;

        //Initialized FavoritoEN
        favoritoEN = new FavoritoEN ();
        favoritoEN.Id = p_Favorito_OID;
        favoritoEN.FechaMarcado = p_fechaMarcado;
        //Call to FavoritoRepository

        _IFavoritoRepository.Modify (favoritoEN);
}

public void Destroy (int id
                     )
{
        _IFavoritoRepository.Destroy (id);
}

public FavoritoEN ReadOID (int id
                           )
{
        FavoritoEN favoritoEN = null;

        favoritoEN = _IFavoritoRepository.ReadOID (id);
        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> list = null;

        list = _IFavoritoRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> ObtenerFavoritosPorUsuario (string p_UsuarioOID)
{
        return _IFavoritoRepository.ObtenerFavoritosPorUsuario (p_UsuarioOID);
}
}
}
