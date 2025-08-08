namespace DotNetBungieAPI.Models.Extensions;

public static class LinqExtensions
{
    public static TValue? GetValueByHashFromDictionary<TKey, TValue>(this IDictionary<DefinitionHashPointer<TKey>, TValue> dictionary, uint hash)
        where TKey : class, IDestinyDefinition
    {
        var searchResult = dictionary.FirstOrDefault(x => x.Key == hash);

        if (searchResult.Key == default)
        {
            return default;
        }

        return searchResult.Value;
    }
}
