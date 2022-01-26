namespace DotNetBungieAPI.Generated;

internal static class DeepEqualityExtensions
{
    internal static bool DeepEqualsList<T>(
        this List<T> first, 
        List<T> second) where T : IDeepEquatable<T>
    {
        if (first is null && second is null)
            return true;
        if (first is null && second is not null)
            return false;
        if (first is not null && second is null)
            return false;
        if (first.Count != second.Count)
            return false;
        for (var i = 0; i < first.Count; i++)
        {
            if (first[i].DeepEquals(second[i]) == false)
                return false;
        }

        return true;
    }

    internal static bool DeepEqualsListNaive<T>(
        this List<T> first, 
        List<T> second)
    {
        if (first is null && second is null)
            return true;
        if (first is null && second is not null)
            return false;
        if (first is not null && second is null)
            return false;
        if (first.Count != second.Count)
            return false;
        for (var i = 0; i < first.Count; i++)
        {
            if (!first[i].Equals(second[i]))
                return false;
        }

        return true;
    }

    internal static bool DeepEqualsDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second) where TValue : IDeepEquatable<TValue>
    {
        if (first is null && second is null)
            return true;
        if (first is null && second is not null)
            return false;
        if (first is not null && second is null)
            return false;
        if (first.Count != second.Count)
            return false;

        foreach (var (firstDictKey, firstDictValue) in first)
        {
            if (second.TryGetValue(firstDictKey, out var secondDictValue))
            {
                if (!firstDictValue.DeepEquals(secondDictValue))
                    return false;
            }
            else
                return false;
        }

        return true;
    }

    internal static bool DeepEqualsDictionaryNaive<TKey, TValue>(
        this Dictionary<TKey, TValue>? first,
        Dictionary<TKey, TValue>? second)
    {
        if (first is null && second is null)
            return true;
        if (first is null && second is not null)
            return false;
        if (first is not null && second is null)
            return false;
        if (first.Count != second.Count)
            return false;

        foreach (var (firstDictKey, firstDictValue) in first)
        {
            if (second.TryGetValue(firstDictKey, out var secondDictValue))
            {
                if (!firstDictValue.Equals(secondDictValue))
                    return false;
            }
            else
                return false;
        }

        return true;
    }
}