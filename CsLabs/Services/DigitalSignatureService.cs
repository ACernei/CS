using System.Numerics;
using AsymmetricCiphers;

namespace Services;

public class DigitalSignatureService
{
    private readonly RsaCipher rsaCipher;
    private readonly Hash hash;

    public DigitalSignatureService()
    {
        this.rsaCipher = new RsaCipher(179, 181);
        this.hash = new Hash();
    }
    public (List<BigInteger>, List<BigInteger>) Sign(string message)
    {
        var signature = hash.CreateHash(message);
        var encryptedSignature = rsaCipher.SignEncrypt(signature);
        var encryptedMessage = rsaCipher.SignEncrypt(message);

        return (encryptedMessage, encryptedSignature);
    }

    public bool IsValid(List<BigInteger> encryptedMessage,List<BigInteger> encryptedSignature)
    {
        var receivedMessage = rsaCipher.SignDecrypt(encryptedMessage);
        var receivedSignature = rsaCipher.SignDecrypt(encryptedSignature);

        return receivedSignature == hash.CreateHash(receivedMessage);
    }
}
