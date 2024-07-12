namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderConstantsDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("fireteamFinderActivityGraphRootCategoryHashes")]
    public List<uint> FireteamFinderActivityGraphRootCategoryHashes { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("allFireteamFinderActivityHashes")]
    public List<uint> AllFireteamFinderActivityHashes { get; set; }

    [JsonPropertyName("guardianOathDisplayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? GuardianOathDisplayProperties { get; set; }

    [JsonPropertyName("guardianOathTenets")]
    public List<Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition> GuardianOathTenets { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
