namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     The definition for information related to a key/value pair that is relevant for a particular Milestone or component within the Milestone. 
/// <para />
///     This lets us more flexibly pass up information that's useful to someone, even if it's not necessarily us.
/// </summary>
public class DestinyMilestoneValueDefinition
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }
}
