namespace DotNetBungieAPI.Models.Extensions;

public static class ReadOnlyDictionaryExtensions
{
    public static bool DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue<T, P>(
        this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where T : IDeepEquatable<T>
    {
        if (compared.Count != comparedWith.Count)
            return false;

        for (var i = 0; i < compared.Count; i++)
            if (!compared.ElementAt(i).Key.DeepEquals(comparedWith.ElementAt(i).Key) ||
                !compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value))
                return false;
        return true;
    }

    public static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue<T, P>(
        this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where P : IDeepEquatable<P>
    {
        if (compared.Count != comparedWith.Count)
            return false;

        for (var i = 0; i < compared.Count; i++)
            if (!compared.ElementAt(i).Value.DeepEquals(comparedWith.ElementAt(i).Value) ||
                !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                return false;
        return true;
    }

    public static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue<T, P>(
        this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith)
    {
        if (compared.Count != comparedWith.Count)
            return false;

        for (var i = 0; i < compared.Count; i++)
            if (!compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value) ||
                !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                return false;
        return true;
    }
}