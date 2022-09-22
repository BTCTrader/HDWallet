using System.Linq;
using HDWallet.Core;
using NBitcoin;

namespace HDWallet.Flow
{
    public class AddressGenerator : IAddressGenerator
    {
        /// <summary>
        /// Exceptionally, this method returns public key for FLOW instead of address. Address should be generated on chain with this public key.
        /// </summary>
        /// <param name="pubKeyBytes"></param>
        /// <returns></returns>
        public string GenerateAddress(byte[] pubKeyBytes)
        {
            var pubKey = new PubKey(pubKeyBytes);
            var uncompPublicKey = pubKey.Decompress();
            var fullPublicKey = uncompPublicKey.ToBytes().Skip(1).ToArray().ToHexString();

            return fullPublicKey;
        }
    }
}