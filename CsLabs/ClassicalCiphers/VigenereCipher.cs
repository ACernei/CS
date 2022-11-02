using CsLabs;
using CsLabs.Extensions;

namespace ClassicalCiphers;

public class VigenereCipher : ICipher
{
    private readonly string keyword;

    public VigenereCipher(string keyword)
    {
        this.keyword = keyword;
    }

    public string Encrypt(string message)
    {
        return ProcessMessage(message, (a, b) => a + b);
    }

    public string Decrypt(string message)
    {
        return ProcessMessage(message, (a, b) => a - b);
    }

    private string ProcessMessage(string message, Func<int, int, int> action)
    {
        return message.Select((x, i) =>
            {
                var letterIndex = Alphabet.DefaultAlphabet.IndexOf(x);
                var keyIndex = Alphabet.DefaultAlphabet.IndexOf(keyword[i % keyword.Length]);
                var processedIndex = action(letterIndex, keyIndex).Mod(Alphabet.DefaultAlphabet.Length);
                return Alphabet.DefaultAlphabet[processedIndex];
            })
            .ToNiceString();
    }
}
