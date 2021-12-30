using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemObjectiveBlockDefinition
{

    [JsonPropertyName("objectiveHashes")]
    public List<uint> ObjectiveHashes { get; init; }

    [JsonPropertyName("displayActivityHashes")]
    public List<uint> DisplayActivityHashes { get; init; }

    [JsonPropertyName("requireFullObjectiveCompletion")]
    public bool RequireFullObjectiveCompletion { get; init; }

    [JsonPropertyName("questlineItemHash")]
    public uint QuestlineItemHash { get; init; }

    [JsonPropertyName("narrative")]
    public string Narrative { get; init; }

    [JsonPropertyName("objectiveVerbName")]
    public string ObjectiveVerbName { get; init; }

    [JsonPropertyName("questTypeIdentifier")]
    public string QuestTypeIdentifier { get; init; }

    [JsonPropertyName("questTypeHash")]
    public uint QuestTypeHash { get; init; }

    [JsonPropertyName("perObjectiveDisplayProperties")]
    public List<Destiny.Definitions.DestinyObjectiveDisplayProperties> PerObjectiveDisplayProperties { get; init; }

    [JsonPropertyName("displayAsStatTracker")]
    public bool DisplayAsStatTracker { get; init; }
}
