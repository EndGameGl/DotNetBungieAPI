namespace DotNetBungieAPI.Defaults
{
    internal class ReadOnlyDictionaries<TKey, TValue>
    {
        internal static ReadOnlyDictionary<TKey, TValue> Empty { get; } = new(new Dictionary<TKey, TValue>(0));
    }
}