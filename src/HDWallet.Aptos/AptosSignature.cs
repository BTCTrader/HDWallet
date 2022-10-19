using HDWallet.Core;

namespace HDWallet.Aptos
{
    public class AptosSignature : Signature
    {
        public byte[] SignatureBytes => Helper.Concat(this.R, this.S);
        public string SignatureHex => Helper.ToHexString(this.SignatureBytes);

        public AptosSignature(Signature signature)
        {
            this.R = signature.R;
            this.S = signature.S;
            this.RecId= signature.RecId;
        }
    }
}