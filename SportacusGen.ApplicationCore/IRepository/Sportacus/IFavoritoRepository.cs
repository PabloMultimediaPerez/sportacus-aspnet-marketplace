
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IFavoritoRepository
{
void setSessionCP (GenericSessionCP session);

FavoritoEN ReadOIDDefault (int id
                           );

void ModifyDefault (FavoritoEN favorito);

System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size);



int New_ (FavoritoEN favorito);

void Modify (FavoritoEN favorito);


void Destroy (int id
              );


FavoritoEN ReadOID (int id
                    );


System.Collections.Generic.IList<FavoritoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> ObtenerFavoritosPorUsuario (string email);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.FavoritoEN> ObtenerFavoritosPorProducto (int ? productoID);
}
}
