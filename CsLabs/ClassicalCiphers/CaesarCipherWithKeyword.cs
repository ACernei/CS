using CsLabs;
using CsLabs.Extensions;

namespace ClassicalCiphers;

public class CaesarCipherWithKeyword : ICipher
{
    private readonly int key;
    private readonly string secretAlphabet;

    public CaesarCipherWithKeyword(int key, string keyword)
    {
        this.key = key;
        this.secretAlphabet = Alphabet.CreateSecretAlphabet(keyword, Alphabet.DefaultAlphabet);
    }

    public string Encrypt(string message)
    {
        return message
            .Select(x => ProcessChar(x, key))
            .ToNiceString();
    }

    public string Decrypt(string message)
    {
        return message
            .Select(x => ProcessChar(x, secretAlphabet.Length - key))
            .ToNiceString();
    }

    private char ProcessChar(char letter, int offset)
    {
        if (!char.IsLetter(letter))
            return letter;
        var isLower = char.IsLower(letter);
        letter = char.ToLower(letter);

        var letterIndex = secretAlphabet.IndexOf(letter);
        var encryptedIndex = (letterIndex + offset) % secretAlphabet.Length;

        var encryptedChar = secretAlphabet[encryptedIndex];
        return isLower ? encryptedChar : char.ToUpper(encryptedChar);
    }
}
