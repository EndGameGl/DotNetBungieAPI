namespace DotNetBungieAPI.Models.Defaults;

public class ReadOnlyDictionaries<TKey, TValue>
    where TKey : notnull
{
    public static ReadOnlyDictionary<TKey, TValue> Empty { get; } =
        new(new Dictionary<TKey, TValue>(0));
}
