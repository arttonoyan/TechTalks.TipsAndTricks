using System.Diagnostics.CodeAnalysis;

namespace TechTalks.NullState.StaticAnalysis;

public static class ExtensionsStaticAnalysis
{
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source) =>
       source == null || !source.Any();

    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this ICollection<T>? source) =>
        source == null || source.Count == 0;
}
