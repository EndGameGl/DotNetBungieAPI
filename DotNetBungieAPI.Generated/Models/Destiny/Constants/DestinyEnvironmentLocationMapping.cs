namespace DotNetBungieAPI.Generated.Models.Destiny.Constants;

public class DestinyEnvironmentLocationMapping
{
    /// <summary>
    ///     The location that is revealed on the director by this mapping.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyLocationDefinition>("Destiny.Definitions.DestinyLocationDefinition")]
    [JsonPropertyName("locationHash")]
    public uint? LocationHash { get; set; }

    /// <summary>
    ///     A hint that the UI uses to figure out how this location is activated by the player.
    /// </summary>
    [JsonPropertyName("activationSource")]
    public string? ActivationSource { get; set; }

    /// <summary>
    ///     If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     If this is populated, this is an objective related to the location.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; set; }

    /// <summary>
    ///     If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }
}
