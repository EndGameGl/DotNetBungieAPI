namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

public class DestinySeasonPassDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     This is the progression definition related to the progression for the initial levels 1-100 that provide item rewards for the Season pass. Further experience after you reach the limit is provided in the "Prestige" progression referred to by prestigeProgressionHash.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyProgressionDefinition>("Destiny.Definitions.DestinyProgressionDefinition")]
    [JsonPropertyName("rewardProgressionHash")]
    public uint? RewardProgressionHash { get; set; }

    /// <summary>
    ///     I know what you're thinking, but I promise we're not going to duplicate and drown you. Instead, we're giving you sweet, sweet power bonuses.
    /// <para />
    ///      Prestige progression is further progression that you can make on the Season pass after you gain max ranks, that will ultimately increase your power/light level over the theoretical limit.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyProgressionDefinition>("Destiny.Definitions.DestinyProgressionDefinition")]
    [JsonPropertyName("prestigeProgressionHash")]
    public uint? PrestigeProgressionHash { get; set; }

    [JsonPropertyName("linkRedirectPath")]
    public string? LinkRedirectPath { get; set; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; set; }

    [JsonPropertyName("images")]
    public Destiny.Definitions.Seasons.DestinySeasonPassImages? Images { get; set; }

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
