
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface ICompraRepository
{
void setSessionCP (GenericSessionCP session);

CompraEN ReadOIDDefault (int id
                         );

void ModifyDefault (CompraEN compra);

System.Collections.Generic.IList<CompraEN> ReadAllDefault (int first, int size);



void Modify (CompraEN compra);


void Destroy (int id
              );


CompraEN ReadOID (int id
                  );


System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> ObtenerComprasPorUsuario (string p_UsuarioOID);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.CompraEN> ObtenerVentasPorUsuario (string p_UsuarioOID);



int New_ (CompraEN compra);
}
}
