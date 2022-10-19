using NUnit.Framework;
using HDWallet.Core;
using HDWallet.BIP32.Ed25519;
using HDWallet.Ed25519;

namespace HDWallet.Aptos.Tests
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ShouldGeneratedFromMnemonic()
        {
            var mnemonic = "top fortune swim flag evil easy glory conduct depth opera radio heart";
            IHDWallet<AptosWallet> hdWallet = new AptosHDWallet(mnemonic, "");

            var wallet = hdWallet.GetAccount(0).GetExternalWallet(1);
            TestContext.Out.WriteLine("Address: {0}", wallet.Address);
            TestContext.Out.WriteLine("PublicKey: {0}", wallet.PublicKeyBytes.ToHexString());
            TestContext.Out.WriteLine("PrivateKey: {0}", wallet.PrivateKeyBytes.ToHexString());

            Assert.AreEqual(expected: "2a692bd8275bf63683b54a69a103ba07086bfc69ad82486ed432704bde363942", wallet.Address);
            Assert.AreEqual(expected: "be8b1f4e71c8886b63c8e1fa63a7d57170dfdcf6cf7a9922b98fbb217791636b", wallet.PublicKeyBytes.ToHexString());
            Assert.AreEqual(expected: "dea10d9e27387f66e3d271bdb92fe861c20c9427e09e3692c2aae2f73480b7c2", wallet.PrivateKeyBytes.ToHexString());
            
            var helloBytes = System.Text.Encoding.ASCII.GetBytes("Hello Dear World!");
            var sig = wallet.Sign(helloBytes);
            var sighex = sig.R.ToHexString() + sig.S.ToHexString();
            TestContext.Out.WriteLine("Signature: {0}", sighex);
            Assert.AreEqual(expected: "b55d4fb7c0c3437ea43c9ad5ceb9644be2dda7fd16c21c359dabfcfaeaf9c93a0ceaf99e8741200e8e1bf0080f838c6b55ecb0d3dae0aadafb6cf85e2d841608", sighex);
        }

        [Test]
        public void ShouldGeneratedFromXprv()
        {
            var mnemonic = "top fortune swim flag evil easy glory conduct depth opera radio heart";
            IHDWallet<AptosWallet> hdWallet = new AptosHDWallet(mnemonic, "");
            
            var account0 = hdWallet.GetAccount(0);
            Assert.AreEqual("xprv9s21ZrQH143K4E3XC8LB5AZe82VydyfN779qMSV8syL5tEaPgCT3PBu98Fs6sqhYZMpCUf8WZ5Zpt647X9PLoEvFYeFzd43zxE5EoTPgjQJ", account0.GetWif());

            var wallet = account0.GetExternalWallet(1);
            Assert.AreEqual(expected: "2a692bd8275bf63683b54a69a103ba07086bfc69ad82486ed432704bde363942", wallet.Address);

            string xprv = "xprv9s21ZrQH143K4E3XC8LB5AZe82VydyfN779qMSV8syL5tEaPgCT3PBu98Fs6sqhYZMpCUf8WZ5Zpt647X9PLoEvFYeFzd43zxE5EoTPgjQJ";
            ExtKey masterKey = ExtKey.CreateFromWif(xprv);
            IAccount<AptosWallet> account0FromXprv = new Account<AptosWallet>(masterKey);
            var actualWallet = account0FromXprv.GetExternalWallet(1);

            Assert.AreEqual(wallet.PublicKeyBytes, actualWallet.PublicKeyBytes);
            Assert.AreEqual(expected: "2a692bd8275bf63683b54a69a103ba07086bfc69ad82486ed432704bde363942", actualWallet.Address);

            account0FromXprv = new Account<AptosWallet>(xprv);
            actualWallet = account0FromXprv.GetExternalWallet(1);
            Assert.AreEqual(expected: "2a692bd8275bf63683b54a69a103ba07086bfc69ad82486ed432704bde363942", actualWallet.Address);
        }
    }
}