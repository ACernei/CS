using System.Numerics;
using AsymmetricCiphers;

namespace Services;

public class DigitalSignatureService
{
    private readonly Rsa rsa;
    private readonly Hash hash;

    public DigitalSignatureService()
    {
        this.rsa = new Rsa(179, 181);
        this.hash = new Hash();
    }
    public (List<BigInteger>, List<BigInteger>) Sign(string message)
    {
        var signature = hash.CreateHash(message);
        var encryptedSignature = rsa.Encrypt(signature);
        var encryptedMessage = rsa.Encrypt(message);

        return (encryptedMessage, encryptedSignature);
    }

    public bool IsValid(List<BigInteger> encryptedMessage,List<BigInteger> encryptedSignature)
    {
        var receivedMessage = rsa.Decrypt(encryptedMessage);
        var receivedSignature = rsa.Decrypt(encryptedSignature);

        return receivedSignature == hash.CreateHash(receivedMessage);
    }
}
