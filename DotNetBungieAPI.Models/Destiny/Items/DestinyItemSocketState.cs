﻿using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Items;

/// <summary>
///     The status of a given item's socket. (which plug is inserted, if any: whether it is enabled, what "reusable" plugs
///     can be inserted, etc...)
///     <para />
///     If I had it to do over, this would probably have a DestinyItemPlug representing the inserted item instead of most
///     of these properties.
/// </summary>
public sealed record DestinyItemSocketState
{
    /// <summary>
    ///     The currently active plug, if any.
    ///     <para />
    ///     Note that, because all plugs are statically defined, its effect on stats and perks can be statically determined
    ///     using the plug item's definition. The stats and perks can be taken at face value on the plug item as the stats and
    ///     perks it will provide to the user/item.
    /// </summary>
    [JsonPropertyName("plugHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Plug { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     Even if a plug is inserted, it doesn't mean it's enabled.
    ///     <para />
    ///     This flag indicates whether the plug is active and providing its benefits.
    /// </summary>
    [JsonPropertyName("isEnabled")]
    public bool IsEnabled { get; init; }

    /// <summary>
    ///     A plug may theoretically provide benefits but not be visible - for instance, some older items use a plug's damage
    ///     type perk to modify their own damage type. These, though they are not visible, still affect the item. This field
    ///     indicates that state.
    ///     <para />
    ///     An invisible plug, while it provides benefits if it is Enabled, cannot be directly modified by the user.
    /// </summary>
    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; init; }

    /// <summary>
    ///     If a plug is inserted but not enabled, this will be populated with indexes into the plug item definition's
    ///     plug.enabledRules property, so that you can show the reasons why it is not enabled.
    /// </summary>
    [JsonPropertyName("enableFailIndexes")]
    public ReadOnlyCollection<int> EnableFailIndexes { get; init; } =
        ReadOnlyCollection<int>.Empty;
}
