using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Extensions;

public static class LinqExtensions
{
    public static TValue GetValueByHashFromDictionary<TKey, TValue>(
        this IDictionary<DefinitionHashPointer<TKey>, TValue> dictionary, uint hash) where TKey : IDestinyDefinition
    {
        KeyValuePair<DefinitionHashPointer<TKey>, TValue>? searchResult = null;
        searchResult = dictionary.FirstOrDefault(x => x.Key == hash);
        return searchResult.HasValue ? searchResult.Value.Value : default;
    }
}