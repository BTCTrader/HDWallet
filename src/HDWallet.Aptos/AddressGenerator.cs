using System;
using HDWallet.Core;
using SharpHash.Interfaces;

namespace HDWallet.Aptos
{
    public class AddressGenerator : IAddressGenerator
    {
        public string GenerateAddress(byte[] pubKeyBytes)
        {
            if(pubKeyBytes.Length != 32) 
            {
                throw new ArgumentException("PublicKey should be 32 bytes");
            }

            byte[] zeroAppendedPubKeyBytes = new byte[33];
            System.Buffer.BlockCopy(pubKeyBytes, 0, zeroAppendedPubKeyBytes, 0, 32);
            zeroAppendedPubKeyBytes[32] = 0x00;

            IHash hashFnAptos = SharpHash.Base.HashFactory.Crypto.CreateSHA3_256();
            byte[] sha3256 = hashFnAptos.ComputeBytes(zeroAppendedPubKeyBytes).GetBytes();
            string computedSha3256Bytes = sha3256.ToHexString();

            return computedSha3256Bytes;
        }
    }
}