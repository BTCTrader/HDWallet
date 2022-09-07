using System.Linq;
using HDWallet.Core;
using NBitcoin;

namespace HDWallet.Flow
{
    public class AddressGenerator : IAddressGenerator
    {
        public string GenerateAddress(byte[] pubKeyBytes)
        {
            var pubKey = new PubKey(pubKeyBytes);
            var uncompPublicKey = pubKey.Decompress();
            var fullPublicKey = uncompPublicKey.ToBytes().Skip(1).ToArray().ToHexString();

            return fullPublicKey;
        }
    }
}