
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IImagenRepository
{
void setSessionCP (GenericSessionCP session);

ImagenEN ReadOIDDefault (int id
                         );

void ModifyDefault (ImagenEN imagen);

System.Collections.Generic.IList<ImagenEN> ReadAllDefault (int first, int size);



int New_ (ImagenEN imagen);

void Modify (ImagenEN imagen);


void Destroy (int id
              );


ImagenEN ReadOID (int id
                  );


System.Collections.Generic.IList<ImagenEN> ReadAll (int first, int size);
}
}
