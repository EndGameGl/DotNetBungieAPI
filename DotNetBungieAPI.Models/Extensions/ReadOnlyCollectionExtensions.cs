namespace DotNetBungieAPI.Models.Extensions;

public static class ReadOnlyCollectionExtensions
{
    public static bool DeepEqualsReadOnlySimpleCollection<T>(
        this ReadOnlyCollection<T> compared,
        ReadOnlyCollection<T> comparedWith)
    {
        if (compared.Count != comparedWith.Count)
            return false;
        for (var i = 0; i < compared.Count; i++)
            if (!compared[i].Equals(comparedWith[i]))
                return false;

        return true;
    }

    public static bool DeepEqualsReadOnlyCollections<T>(
        this ReadOnlyCollection<T> compared,
        ReadOnlyCollection<T> comparedWith) where T : IDeepEquatable<T>
    {
        if (compared.Count != comparedWith.Count)
            return false;

        for (var i = 0; i < compared.Count; i++)
            if (!compared[i].DeepEquals(comparedWith[i]))
                return false;

        return true;
    }
}