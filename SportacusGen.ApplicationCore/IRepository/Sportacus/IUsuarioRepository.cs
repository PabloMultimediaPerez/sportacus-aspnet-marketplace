
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );


UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
