using CsLabs;
using CsLabs.Extensions;

namespace ClassicalCiphers;

public class PolybiusCipher : ICipher
{
    private readonly string secretAlphabet;

    public PolybiusCipher(string keyword)
    {
        this.secretAlphabet = Alphabet.CreateSecretAlphabet(keyword, Alphabet.AlphabetWithoutJ);
    }

    public string Encrypt(string message)
    {
        return message.Select(EncryptChar).ToNiceString();
    }

    public string Decrypt(string message)
    {
        var pairs = message.Chunk(2);
        return pairs
            .Select(x => DecryptChar(x[0].ToLiteralInt(), x[1].ToLiteralInt()))
            .ToNiceString();
    }

    private char DecryptChar(int x, int y)
    {
        var letterIndex = 5 * (x - 1) + y - 1;
        return secretAlphabet[letterIndex];
    }

    private string EncryptChar(char letter)
    {
        if (letter == 'j') letter = 'i';

        var letterIndex = secretAlphabet.IndexOf(letter);

        return $"{(letterIndex / 5) + 1}{(letterIndex % 5) + 1}";
    }
}
