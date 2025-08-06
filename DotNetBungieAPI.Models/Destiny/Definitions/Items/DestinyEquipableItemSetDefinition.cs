namespace DotNetBungieAPI.Models.Destiny.Definitions.Items;

/// <summary>
///     Perks that are active only when you have a certain number of set items equipped.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyEquipableItemSetDefinition)]
public sealed class DestinyEquipableItemSetDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyEquipableItemSetDefinition;

    /// <summary>
    ///     Display Properties, including name and icon, for this item set
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     The items that confer these perks.
    /// </summary>
    [JsonPropertyName("setItems")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? SetItems { get; init; }

    /// <summary>
    ///     The perks conferred by this set of armor pieces.
    /// </summary>
    [JsonPropertyName("setPerks")]
    public Destiny.Definitions.Items.DestinyItemSetPerkDefinition[]? SetPerks { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
