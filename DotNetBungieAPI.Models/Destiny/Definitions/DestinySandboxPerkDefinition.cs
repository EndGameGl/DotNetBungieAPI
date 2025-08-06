namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Perks are modifiers to a character or item that can be applied situationally.
/// <para />
///     - Perks determine a weapon's damage type.
/// <para />
///     - Perks put the Mods in Modifiers (they are literally the entity that bestows the Sandbox benefit for whatever fluff text about the modifier in the Socket, Plug or Talent Node)
/// <para />
///     - Perks are applied for unique alterations of state in Objectives
/// <para />
///     Anyways, I'm sure you can see why perks are so interesting.
/// <para />
///     What Perks often don't have is human readable information, so we attempt to reverse engineer that by pulling that data from places that uniquely refer to these perks: namely, Talent Nodes and Plugs. That only gives us a subset of perks that are human readable, but those perks are the ones people generally care about anyways. The others are left as a mystery, their true purpose mostly unknown and undocumented.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinySandboxPerkDefinition)]
public sealed class DestinySandboxPerkDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySandboxPerkDefinition;

    /// <summary>
    ///     These display properties are by no means guaranteed to be populated. Usually when it is, it's only because we back-filled them with the displayProperties of some Talent Node or Plug item that happened to be uniquely providing that perk.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     The string identifier for the perk.
    /// </summary>
    [JsonPropertyName("perkIdentifier")]
    public string PerkIdentifier { get; init; }

    /// <summary>
    ///     If true, you can actually show the perk in the UI. Otherwise, it doesn't have useful player-facing information.
    /// </summary>
    [JsonPropertyName("isDisplayable")]
    public bool IsDisplayable { get; init; }

    /// <summary>
    ///     If this perk grants a damage type to a weapon, the damage type will be defined here.
    /// <para />
    ///     Unless you have a compelling reason to use this enum value, use the damageTypeHash instead to look up the actual DestinyDamageTypeDefinition.
    /// </summary>
    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; init; }

    /// <summary>
    ///     The hash identifier for looking up the DestinyDamageTypeDefinition, if this perk has a damage type.
    /// <para />
    ///     This is preferred over using the damageType enumeration value, which has been left purely because it is occasionally convenient.
    /// </summary>
    [JsonPropertyName("damageTypeHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyDamageTypeDefinition>? DamageTypeHash { get; init; }

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
