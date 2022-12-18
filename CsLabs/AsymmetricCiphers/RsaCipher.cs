using System.Numerics;

namespace AsymmetricCiphers;

public class RsaCipher
{
    private readonly BigInteger publicKey;
    private readonly BigInteger privateKey;
    private readonly BigInteger n;

    public RsaCipher(BigInteger p, BigInteger q)
    {
        (this.publicKey, this.privateKey, this.n) = GenerateKeyPair(p, q);
    }

    private static (BigInteger, BigInteger, BigInteger) GenerateKeyPair(BigInteger p, BigInteger q)
    {
        var n = p * q;
        var phi = (p - 1) * (q - 1);
        var e = 2;
        for (; e < phi; e++)
        {
            if (BigInteger.GreatestCommonDivisor(e, phi) == 1)
                break;
        }

        var d = AdvancedMath.ModularInverse(e, phi);
        return (e, d, n);
    }

    public string Encrypt(string message)
    {
        var encryptedMessage = "";
        foreach (var letter in message)
        {
            var asciiValue = (int)letter;
            var encryptedLetter = (BigInteger)Math.Pow(asciiValue, (double)this.publicKey) % this.n;
            encryptedMessage += encryptedLetter + " ";
        }

        return encryptedMessage.Trim();
    }

    public string Decrypt(string encryptedMessage)
    {
        var bigIntegers = encryptedMessage.Split(' ').ToList().Select(BigInteger.Parse).ToList();

        var decryptedMessage = new List<char>();
        foreach (var encryptedLetter in bigIntegers)
        {
            var asciiValue = BigInteger.Pow(encryptedLetter, (int)this.privateKey) % this.n;
            var decryptedLetter = (char)asciiValue;
            decryptedMessage.Add(decryptedLetter);
        }

        return string.Join("", decryptedMessage);
    }

    public List<BigInteger> SignEncrypt(string message)
    {
        var encryptedMessage = new List<BigInteger>();
        foreach (var letter in message)
        {
            var asciiValue = (int)letter;
            var encryptedLetter = BigInteger.Pow(asciiValue, (int)this.privateKey) % this.n;
            encryptedMessage.Add(encryptedLetter);
        }

        return encryptedMessage;
    }

    public string SignDecrypt(List<BigInteger> encryptedMessage)
    {
        var decryptedMessage = new List<char>();
        foreach (var encryptedLetter in encryptedMessage)
        {
            var asciiValue = BigInteger.Pow(encryptedLetter, (int)this.publicKey) % this.n;
            var decryptedLetter = (char)asciiValue;
            decryptedMessage.Add(decryptedLetter);
        }

        return string.Join("", decryptedMessage);
    }
}
