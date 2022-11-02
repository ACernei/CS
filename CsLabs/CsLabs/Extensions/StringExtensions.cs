using System.Text;

namespace CsLabs.Extensions;

public static class StringExtensions
{
    public static string Hex2Binary(string hex)
    {
        var binary = Convert.ToString(Convert.ToInt64(hex, 16), 2);

        //  Fill with 0 if needed
        while (binary.Length < hex.Length * 4)
        {
            binary = "0" + binary;
        }

        return binary;
    }

    public static string Binary2Hex(string binary)
    {
        var hex = Convert.ToString(Convert.ToInt64(binary, 2), 16);

        //  Fill with 0 if needed
        while (hex.Length < binary.Length / 4)
        {
            hex = "0" + hex;
        }

        return hex;
    }

    public static string HexXor(string hex1, string hex2)
    {
        hex1 = Hex2Binary(hex1);
        hex2 = Hex2Binary(hex2);
        var newString = new StringBuilder();
        for (var i = 0; i < hex1.Length; i++)
        {
            newString.Append((hex1[i] + hex2[i]) % 2);
        }

        return Binary2Hex(newString.ToString());
    }
}
