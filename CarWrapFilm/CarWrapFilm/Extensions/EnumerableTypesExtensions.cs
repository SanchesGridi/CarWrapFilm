namespace CarWrapFilm.Extensions;

public static class EnumerableTypesExtensions
{
    public static bool IsEmpty<TAny>(this IEnumerable<TAny> @this)
    {
        return @this == null || !@this.Any();
    }
}
