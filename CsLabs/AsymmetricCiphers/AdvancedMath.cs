using System.Numerics;

namespace AsymmetricCiphers;

public static class AdvancedMath
{
    public static BigInteger ModularInverse(BigInteger a, BigInteger b)
    {
        var i = b;
        BigInteger v = 0;
        BigInteger d = 1;

        while (a > 0)
        {
            var t = i / a;
            var x = a;
            a = i % x;
            i = x;
            x = d;
            d = v - t * x;
            v = x;
        }

        v %= b;
        if (v < 0)
            v = (v + b) % b;

        return v;
    }
}
