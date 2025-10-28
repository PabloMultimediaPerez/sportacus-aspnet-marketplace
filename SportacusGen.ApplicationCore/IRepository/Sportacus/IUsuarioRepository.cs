
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
