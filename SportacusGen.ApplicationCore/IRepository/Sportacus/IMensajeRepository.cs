
using System;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SportacusGen.ApplicationCore.IRepository.Sportacus
{
public partial interface IMensajeRepository
{
void setSessionCP (GenericSessionCP session);

MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int New_ (MensajeEN mensaje);

void Modify (MensajeEN mensaje);


void Destroy (int id
              );


MensajeEN ReadOID (int id
                   );


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerMensajesEntreUsuarios (string email1, string email2);


System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.MensajeEN> ObtenerConversacionesPorUsuario (string email);
}
}
