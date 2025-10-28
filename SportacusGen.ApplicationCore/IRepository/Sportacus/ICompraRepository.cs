
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



int New_ (CompraEN compra);

void Modify (CompraEN compra);


void Destroy (int id
              );


CompraEN ReadOID (int id
                  );


System.Collections.Generic.IList<CompraEN> ReadAll (int first, int size);
}
}
