namespace CsLabs.Extensions;

public static class EnumerableExtensions
{
    public static string ToNiceString<T>(this IEnumerable<T> enumerable)
    {
        return string.Join("", enumerable);
    }
}
