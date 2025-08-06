namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition)]
public sealed class DestinyFireteamFinderActivitySetDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition;

    [JsonPropertyName("maximumPartySize")]
    public int MaximumPartySize { get; init; }

    [JsonPropertyName("optionHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionDefinition>[]? OptionHashes { get; init; }

    [JsonPropertyName("labelHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderLabelDefinition>[]? LabelHashes { get; init; }

    [JsonPropertyName("activityGraphHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>[]? ActivityGraphHashes { get; init; }

    [JsonPropertyName("activityHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition>[]? ActivityHashes { get; init; }

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
