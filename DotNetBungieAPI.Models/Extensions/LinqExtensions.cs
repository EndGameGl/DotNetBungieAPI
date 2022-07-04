using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Models.Extensions;

public static class LinqExtensions
{
    public static TValue GetValueByHashFromDictionary<TKey, TValue>(
        this IDictionary<DefinitionHashPointer<TKey>, TValue> dictionary, uint hash) where TKey : IDestinyDefinition
    {
        KeyValuePair<DefinitionHashPointer<TKey>, TValue>? searchResult = dictionary.FirstOrDefault(x => x.Key == hash);
        return searchResult.HasValue ? searchResult.Value.Value : default;
    }
}