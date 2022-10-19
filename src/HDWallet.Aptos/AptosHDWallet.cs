using HDWallet.Core;
using HDWallet.Ed25519;

namespace HDWallet.Aptos
{
    public class AptosHDWallet : HdWalletEd25519<AptosWallet>, IHDWallet<AptosWallet>
    {
        private static readonly HDWallet.Core.CoinPath _path = M.BIP44.CreateCoinPath(CoinType.Aptos);

        public AptosHDWallet(string seed) : base(seed, _path) {}
        public AptosHDWallet(string mnemonic, string passphrase) : base(mnemonic, passphrase, _path) {}
    }
}