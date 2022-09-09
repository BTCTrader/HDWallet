using HDWallet.Core;
using NUnit.Framework;

namespace HDWallet.Flow.Tests
{
    public class GenerateHDWallet
    {
        [Test]
        public void ShouldCreateAccount()
        {
            string words = "original kid caught kiss effort apple echo else quantum blanket agree review";
            IHDWallet<FlowWallet> wallet = new FlowHDWallet(words);
            var account0wallet0 = wallet.GetAccount(0).GetExternalWallet(0);

            // m/44'/569'/0'/0/0
            Assert.AreEqual(account0wallet0.GetAddress(), "c555cce2b2f5be357511baa5d7b3bbcd5c2cf87f9dbe60c57f7650463fe46bf2f5a930f36b93e84b3c4c76674f56594588b9c57fcbb0996365384fbee579368a");
        }

        [Test]
        public void ShouldCreateAccount2()
        {
            string words = "original kid caught kiss effort apple echo else quantum blanket agree review";
            IHDWallet<FlowWallet> wallet = new FlowHDWallet(words);
            var account0wallet0 = wallet.GetAccount(0).GetExternalWallet(1);

            // m/44'/569'/0'/0/0
            Assert.AreEqual(account0wallet0.GetAddress(), "8cb99d283c33494003f243e78bfd8519b85b8a9d9058bf9db4043bad9ec66c216ce9f93cfd10bffffb545561f4801543dccc7c54ddc79d7f802a46d192e19177");
        }
    }
}