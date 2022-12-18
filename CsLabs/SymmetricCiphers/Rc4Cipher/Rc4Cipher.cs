using System.Text;

namespace SymmetricCiphers.Rc4Cipher;

public class Rc4Cipher

{
    private readonly string key;

    public Rc4Cipher(string key)
    {
        this.key = key;
    }

    private string Process(List<byte> message)
    {
        var s = new int[256];
        for (var _ = 0; _ < 256; _++)
        {
            s[_] = _;
        }

        var t = new int[256];

        //  Repeat key for as many times as necessary to fill T
        for (var _ = 0; _ < 256; _++)
        {
            t[_] = key[_ % key.Length];
        }

        //  Produce the initial permutation
        var j = 0;
        for (var i = 0; i < 256; i++)
        {
            j = (j + s[i] + t[i]) % 256;

            //  Swap the values of S[i] and S[j]
            (s[i], s[j]) = (s[j], s[i]);
        }

        //  Pseudo random generation algorithm

        var result = "";
        var x = 0;
        var y = 0;

        foreach (var number in message)
        {
            x = (x + 1) % 256;

            y = (y + s[x]) % 256;

            //  Swap the values of S[i] and S[j]
            (s[x], s[y]) = (s[y], s[x]);

            var k = s[(s[x] + s[y]) % 256];

            result += Convert.ToByte(number ^ k) + " ";
        }

        return result.Trim();
    }

    public string Encrypt(string message)
    {
        var bytes = Encoding.ASCII.GetBytes(message).ToList();
        return Process(bytes);
    }

    public string Decrypt(string message)
    {
        var bytes = message.Split(' ').ToList().Select(byte.Parse).ToList();
        var bytesResult = Process(bytes).Split(' ').ToList().Select(byte.Parse).ToList();
        return Encoding.UTF8.GetString(bytesResult.ToArray(), 0, bytesResult.Count);
    }
}
