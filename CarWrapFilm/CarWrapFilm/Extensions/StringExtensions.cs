namespace CarWrapFilm.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string @this)
    {
        return string.IsNullOrWhiteSpace(@this);
    }
}
