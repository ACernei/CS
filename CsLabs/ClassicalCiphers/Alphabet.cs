using CsLabs.Extensions;

namespace ClassicalCiphers;

public static class Alphabet
{
    public const string DefaultAlphabet = "abcdefghijklmnopqrstuvwxyz";
    public const string AlphabetWithoutJ = "abcdefghiklmnopqrstuvwxyz";

    public static string CreateSecretAlphabet(string keyword, string alphabet)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return alphabet;

        var keywordLetters = keyword
            .ToLower()
            .Where(alphabet.Contains)
            .Distinct();
        var reducedAlphabet = alphabet.Except(keywordLetters);
        return keywordLetters.ToNiceString() + reducedAlphabet.ToNiceString();
    }
}
