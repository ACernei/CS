using CsLabs;
using CsLabs.Extensions;

namespace Lab1;

public class CaesarCipher : ICipher
{
    private readonly int key;
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    
    public CaesarCipher(int key)
    {
        this.key = key;
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
            .Select(x => ProcessChar(x, alphabet.Length - key))
            .ToNiceString();
    }
    
    private char ProcessChar(char letter, int offset)
    {
        if (!char.IsLetter(letter))
            return letter;
        var isLower = char.IsLower(letter);
        letter = char.ToLower(letter);
        
        var letterIndex = alphabet.IndexOf(letter);
        var encryptedIndex = (letterIndex + offset) % alphabet.Length;
        
        var encryptedChar = alphabet[encryptedIndex];
        return isLower ? encryptedChar : char.ToUpper(encryptedChar);
    }
}
