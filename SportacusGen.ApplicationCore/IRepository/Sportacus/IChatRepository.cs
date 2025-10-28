
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IChatRepository
{
void setSessionCP (GenericSessionCP session);

ChatEN ReadOIDDefault (int id
                       );

void ModifyDefault (ChatEN chat);

System.Collections.Generic.IList<ChatEN> ReadAllDefault (int first, int size);



int New_ (ChatEN chat);

void Modify (ChatEN chat);


void Destroy (int id
              );


ChatEN ReadOID (int id
                );


System.Collections.Generic.IList<ChatEN> ReadAll (int first, int size);
}
}
