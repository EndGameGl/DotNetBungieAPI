namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An individual Destiny Entity returned from the entity search.
/// </summary>
public sealed class DestinyEntitySearchResultItem
{

    /// <summary>
    ///     The hash identifier of the entity. You will use this to look up the DestinyDefinition relevant for the entity found.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The type of entity, returned as a string matching the DestinyDefinition's contract class name. You'll have to have your own mapping from class names to actually looking up those definitions in the manifest databases.
    /// </summary>
    [JsonPropertyName("entityType")]
    public string EntityType { get; init; }

    /// <summary>
    ///     Basic display properties on the entity, so you don't have to look up the definition to show basic results for the item.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The ranking value for sorting that we calculated using our relevance formula. This will hopefully get better with time and iteration.
    /// </summary>
    [JsonPropertyName("weight")]
    public double Weight { get; init; }
}
