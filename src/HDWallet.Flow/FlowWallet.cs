using HDWallet.Core;
using HDWallet.Secp256k1;

namespace HDWallet.Flow
{
    public class FlowWallet : Wallet, IWallet
    {
        public FlowWallet(){}

        public FlowWallet(string privateKey) : base(privateKey) {}

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new AddressGenerator();
        }

        public string GetAddress()
        {
            return new AddressGenerator().GenerateAddress(base.PublicKey.ToBytes());
        }
    }
}