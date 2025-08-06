namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Stat Groups (DestinyStatGroupDefinition) has the ability to override the localized text associated with stats that are to be shown on the items with which they are associated.
/// <para />
///     This defines a specific overridden stat. You could theoretically check these before rendering your stat UI, and for each stat that has an override show these displayProperties instead of those on the DestinyStatDefinition.
/// <para />
///     Or you could be like us, and skip that for now because the game has yet to actually use this feature. But know that it's here, waiting for a resilliant young designer to take up the mantle and make us all look foolish by showing the wrong name for stats.
/// <para />
///     Note that, if this gets used, the override will apply only to items using the overriding Stat Group. Other items will still show the default stat's name/description.
/// </summary>
public sealed class DestinyStatOverrideDefinition
{
    /// <summary>
    ///     The hash identifier of the stat whose display properties are being overridden.
    /// </summary>
    [JsonPropertyName("statHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyStatDefinition> StatHash { get; init; }

    /// <summary>
    ///     The display properties to show instead of the base DestinyStatDefinition display properties.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }
}
