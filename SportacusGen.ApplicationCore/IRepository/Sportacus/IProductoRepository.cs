
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IProductoRepository
{
void setSessionCP (GenericSessionCP session);

ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id
              );


ProductoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);
}
}
