namespace CsLabs.Extensions;

public static class CharExtensions
{
    public static int ToLiteralInt(this char character) => character - '0';
}
