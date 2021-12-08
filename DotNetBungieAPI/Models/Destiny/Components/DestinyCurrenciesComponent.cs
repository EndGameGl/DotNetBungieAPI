using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This component provides a quick lookup of every item the requested character has and how much of that item they
///     have.
///     <para />
///     Requesting this component will allow you to circumvent manually putting together the list of which currencies you
///     have for the purpose of testing currency requirements on an item being purchased, or operations that have costs.
///     <para />
///     You *could* figure this out yourself by doing a GetCharacter or GetProfile request and forming your own lookup
///     table, but that is inconvenient enough that this feels like a worthwhile (and optional) redundency. Don't bother
///     requesting it if you have already created your own lookup from prior GetCharacter/GetProfile calls.
/// </summary>
public sealed record DestinyCurrenciesComponent
{
    /// <summary>
    ///     A dictionary - keyed by the item's hash identifier (DestinyInventoryItemDefinition), and whose value is the amount
    ///     of that item you have across all available inventory buckets for purchasing.
    ///     <para />
    ///     This allows you to see whether the requesting character can afford any given purchase/action without having to
    ///     re-create this list itself.
    /// </summary>
    [JsonPropertyName("itemQuantities")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, object>
        ItemQuantities { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>, object>.Empty;
}