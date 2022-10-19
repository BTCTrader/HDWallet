using HDWallet.Core;
using HDWallet.Ed25519;

namespace HDWallet.Aptos
{
    
    public class AptosWallet : Wallet, IWallet
    {
        public AptosWallet(){}

        public AptosWallet(string privateKey) : base(privateKey) {}

        protected override IAddressGenerator GetAddressGenerator()
        {
            return new AddressGenerator();
        }

        public new AptosSignature Sign(byte[] message)
        {
            return new AptosSignature(base.Sign(message));
        }
    }
}