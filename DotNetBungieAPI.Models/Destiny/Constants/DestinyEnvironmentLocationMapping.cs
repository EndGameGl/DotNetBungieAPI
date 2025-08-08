namespace DotNetBungieAPI.Models.Destiny.Constants;

public sealed class DestinyEnvironmentLocationMapping
{
    /// <summary>
    ///     The location that is revealed on the director by this mapping.
    /// </summary>
    [JsonPropertyName("locationHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyLocationDefinition> LocationHash { get; init; }

    /// <summary>
    ///     A hint that the UI uses to figure out how this location is activated by the player.
    /// </summary>
    [JsonPropertyName("activationSource")]
    public string ActivationSource { get; init; }

    /// <summary>
    ///     If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> ItemHash { get; init; }

    /// <summary>
    ///     If this is populated, this is an objective related to the location.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition> ObjectiveHash { get; init; }

    /// <summary>
    ///     If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }
}
