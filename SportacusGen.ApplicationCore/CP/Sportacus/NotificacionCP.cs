
using System;
using System.Text;
using System.Collections.Generic;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.Utils;



namespace SportacusGen.ApplicationCore.CP.Sportacus
{
public partial class NotificacionCP : GenericBasicCP
{
public NotificacionCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public NotificacionCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
