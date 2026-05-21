using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Extensions;
using DotNetBungieAPI.Models;

[assembly: DebuggerDisplay(@"{DotNetBungieAPI.Extensions.DefinitionHashPointerExtensions.GetDebuggerDisplayString(this)}", Target = typeof(DefinitionHashPointer<>))]
[assembly: DebuggerTypeProxy(typeof(DefinitionHashPointerDebugView<>), Target = typeof(DefinitionHashPointer<>))]

namespace DotNetBungieAPI.Extensions;

internal class DefinitionHashPointerDebugView<TDefinition>
    where TDefinition : class, IDestinyDefinition
{
    private readonly DefinitionHashPointer<TDefinition> _definition;

    public DefinitionHashPointerDebugView(DefinitionHashPointer<TDefinition> definition)
    {
        _definition = definition;
    }

    public TDefinition? Definition => _definition.GetValueOrNull();
    public uint? Hash => _definition.Hash;
}

/// <summary>
///     Extension class
/// </summary>
public static class DefinitionHashPointerExtensions
{
    /// <summary>
    ///     Tries to get definition
    /// </summary>
    /// <param name="pointer"></param>
    /// <param name="definition"></param>
    /// <param name="locale"></param>
    /// <typeparam name="TDefinition"></typeparam>
    /// <returns></returns>
    public static bool TryGetDefinition<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        [NotNullWhen(true)] out TDefinition? definition,
        BungieLocales locale = BungieLocales.EN
    )
        where TDefinition : class, IDestinyDefinition
    {
        return TryGetDefinition(pointer.Hash.GetValueOrDefault(), out definition, locale);
    }

    public static bool TryGetDefinition<TDefinition>(this uint pointer, [NotNullWhen(true)] out TDefinition? definition, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return BungieClient.Instance.TryGetDefinition(pointer, out definition, locale);
    }

    public static async ValueTask<bool> TryGetDefinitionAsync<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        Action<TDefinition> onSuccess,
        BungieLocales locale = BungieLocales.EN
    )
        where TDefinition : class, IDestinyDefinition
    {
        return await TryGetDefinitionAsync(pointer.Hash.GetValueOrDefault(), onSuccess, locale);
    }

    public static async ValueTask<bool> TryGetDefinitionAsync<TDefinition>(this uint pointer, Action<TDefinition> onSuccess, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return await BungieClient.Instance.TryGetDefinitionAsync(pointer, onSuccess, locale);
    }

    public static TDefinition? GetValueOrNull<TDefinition>(this DefinitionHashPointer<TDefinition> pointer, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return GetValueOrNull<TDefinition>(pointer.Hash.GetValueOrDefault(), locale);
    }

    public static TDefinition? GetValueOrNull<TDefinition>(this uint pointer, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return pointer.TryGetDefinition<TDefinition>(out var definition, locale) ? definition : null;
    }

    public static async ValueTask<TDefinition?> GetValueOrNullAsync<TDefinition>(this DefinitionHashPointer<TDefinition> pointer, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return await GetValueOrNullAsync<TDefinition>(pointer.Hash.GetValueOrDefault(), locale);
    }

    public static async ValueTask<TDefinition?> GetValueOrNullAsync<TDefinition>(this uint pointer, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        TDefinition? definition = null;
        await pointer.TryGetDefinitionAsync<TDefinition>(def => definition = def, locale);
        return definition;
    }

    public static bool Is<TDefinition>(this DefinitionHashPointer<TDefinition> pointer, Func<TDefinition?, bool> predicate, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return Is(pointer.Hash.GetValueOrDefault(), predicate, locale);
    }

    public static bool Is<TDefinition>(this uint pointer, Func<TDefinition?, bool> predicate, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return pointer.TryGetDefinition<TDefinition>(out var definition, locale) && predicate(definition);
    }

    public static async ValueTask<bool> IsAsync<TDefinition>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, bool> predicate,
        BungieLocales locale = BungieLocales.EN
    )
        where TDefinition : class, IDestinyDefinition
    {
        return await IsAsync(pointer.Hash.GetValueOrDefault(), predicate, locale);
    }

    public static async ValueTask<bool> IsAsync<TDefinition>(this uint pointer, Func<TDefinition, bool> predicate, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        var value = await pointer.GetValueOrNullAsync<TDefinition>(locale);
        return value is not null && predicate(value);
    }

    public static TValue? Select<TDefinition, TValue>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, TValue> selector,
        BungieLocales locale = BungieLocales.EN
    )
        where TDefinition : class, IDestinyDefinition
    {
        return Select(pointer.Hash.GetValueOrDefault(), selector, locale);
    }

    public static TValue? Select<TDefinition, TValue>(this uint pointer, Func<TDefinition, TValue> selector, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        return pointer.TryGetDefinition<TDefinition>(out var definition, locale) ? selector(definition) : default;
    }

    public static async ValueTask<TValue?> SelectAsync<TDefinition, TValue>(
        this DefinitionHashPointer<TDefinition> pointer,
        Func<TDefinition, TValue> selector,
        BungieLocales locale = BungieLocales.EN
    )
        where TDefinition : class, IDestinyDefinition
    {
        return await SelectAsync(pointer.Hash.GetValueOrDefault(), selector, locale);
    }

    public static async ValueTask<TValue?> SelectAsync<TDefinition, TValue>(this uint pointer, Func<TDefinition, TValue> selector, BungieLocales locale = BungieLocales.EN)
        where TDefinition : class, IDestinyDefinition
    {
        var definition = await pointer.GetValueOrNullAsync<TDefinition>(locale);
        return definition is not null ? selector(definition) : default;
    }

    private static string GetDebuggerDisplayString<TDefinition>(DefinitionHashPointer<TDefinition> pointer)
        where TDefinition : class, IDestinyDefinition
    {
        if (pointer.TryGetDefinition(out var definition) && definition is IDisplayProperties displayProperties)
        {
            return $"{pointer.Hash} {displayProperties.DisplayProperties.Name}";
        }

        return $"{pointer.Hash} {typeof(TDefinition).Name}";
    }
}
