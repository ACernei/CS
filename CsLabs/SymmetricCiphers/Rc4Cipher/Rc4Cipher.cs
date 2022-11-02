namespace SymmetricCiphers.Rc4Cipher;

public class Rc4Cipher

{
    private readonly List<byte> key;

    public Rc4Cipher(List<byte> key)
    {
        this.key = key;
    }

    private List<byte> Process(List<byte> message)
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
            t[_] = key[_ % key.Count];
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

        var result = new List<byte>();
        var x = 0;
        var y = 0;

        foreach (var number in message)
        {
            x = (x + 1) % 256;

            y = (y + s[x]) % 256;

            //  Swap the values of S[i] and S[j]
            (s[x], s[y]) = (s[y], s[x]);

            var k = s[(s[x] + s[y]) % 256];

            result.Add(Convert.ToByte(number ^ k));
        }

        return result;
    }

    public List<byte> Encrypt(List<byte> message)
    {
        return Process(message);
    }

    public List<byte> Decrypt(List<byte> message)
    {
        return Encrypt(message);
    }
}
