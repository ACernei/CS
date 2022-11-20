namespace CsLabs.Extensions;

public static class IntExtensions
{
    public static int Mod(this int a, int b)
    {
        return (a % b + b) % b;
    }
}
