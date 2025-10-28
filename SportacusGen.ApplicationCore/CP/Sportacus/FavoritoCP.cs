
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
public partial class FavoritoCP : GenericBasicCP
{
public FavoritoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public FavoritoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
