namespace TechTalks.NullState.Standard;

public static class ExtensionsStandard
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) =>
        source == null || !source.Any();

    public static bool IsNullOrEmpty<T>(this ICollection<T> source) =>
        source == null || source.Count == 0;
}
