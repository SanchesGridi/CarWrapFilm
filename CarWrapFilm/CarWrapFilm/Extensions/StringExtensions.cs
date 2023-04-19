namespace CarWrapFilm.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string @this)
    {
        return string.IsNullOrWhiteSpace(@this);
    }

    public static long ToLong(this string @this)
    {
        return long.Parse(@this);
    }

    public static uint ToUint(this string @this)
    {
        return uint.Parse(@this);
    }
}
