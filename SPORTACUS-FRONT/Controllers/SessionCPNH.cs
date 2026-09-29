using SportacusGen.ApplicationCore.CP.Sportacus;

namespace SPORTACUS_FRONT.Controllers
{
    internal class SessionCPNH : GenericSessionCP
    {
        public override void Commit()
        {
            throw new NotImplementedException();
        }

        public override void RollBack()
        {
            throw new NotImplementedException();
        }

        public override void SessionClose()
        {
            throw new NotImplementedException();
        }

        public override void SessionInitializeTransaction()
        {
            throw new NotImplementedException();
        }

        public override void SessionInitializeWithoutTransaction()
        {
            throw new NotImplementedException();
        }
    }
}