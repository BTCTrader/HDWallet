using HDWallet.Core;
using HDWallet.Secp256k1;

namespace HDWallet.Flow
{
    public class FlowHDWallet : HDWallet<FlowWallet>
    {
        private static readonly HDWallet.Core.CoinPath _path = M.BIP44.CreateCoinPath(CoinType.Flow);

        public FlowHDWallet(string mnemonic, string passphrase = "") : base(mnemonic, passphrase, _path) {}
    }
}