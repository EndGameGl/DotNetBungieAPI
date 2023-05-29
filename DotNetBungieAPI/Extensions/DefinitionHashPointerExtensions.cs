using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Extensions;

/// <summary>
///     Extension class 
/// </summary>
public static class DefinitionHashPointerExtensions
{
    /// <summary>
    ///     Tries to get definition from local cache/given provider
    /// </summary>
    /// <param name="pointer"></param>
    /// <param name="definition"></param>
    /// <param name="locale"></param>
    /// <typeparam name="TDefinition"></typeparam>
    /// <returns></returns>
    public static bool TryGetDefinition<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        out TDefinition? definition,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        return BungieClient.Instance.TryGetDefinition(pointer.Hash.GetValueOrDefault(), out definition, locale);
    }

    public static async ValueTask<bool> TryGetDefinitionAsync<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        Action<TDefinition?> onSuccess,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        return await BungieClient.Instance.TryGetDefinitionAsync(
            pointer.Hash.GetValueOrDefault(),
            onSuccess,
            locale);
    }

    public static TDefinition? GetValueOrNull<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        return pointer.TryGetDefinition(out var definition, locale) ? definition : default;
    }

    public static async ValueTask<TDefinition?> GetValueOrNullAsync<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        TDefinition? definition = default;

        if (await pointer.TryGetDefinitionAsync(def => definition = def, locale))
        {
            return definition;
        }

        return definition;
    }

    public static bool Is<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition?, bool> predicate,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        return pointer.TryGetDefinition(out var definition, locale) && predicate(definition);
    }

    public static async ValueTask<bool> IsAsync<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, bool> predicate,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        var value = await pointer.GetValueOrNullAsync(locale);
        return value is not null && predicate(value);
    }

    public static TValue Select<TDefinition, TValue>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, TValue> func,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        return pointer.TryGetDefinition(out var definition, locale) ? func(definition) : default;
    }

    public static async ValueTask<TValue> SelectAsync<TDefinition, TValue>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, TValue> func,
        BungieLocales locale = BungieLocales.EN) where TDefinition : IDestinyDefinition
    {
        var definition = await pointer.GetValueOrNullAsync(locale);
        return definition is not null ? func(definition) : default;
    }
}