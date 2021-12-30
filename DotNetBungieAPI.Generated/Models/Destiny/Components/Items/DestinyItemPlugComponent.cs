using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Items;

public sealed class DestinyItemPlugComponent
{

    [JsonPropertyName("plugObjectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> PlugObjectives { get; init; }

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }

    [JsonPropertyName("canInsert")]
    public bool CanInsert { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("insertFailIndexes")]
    public List<int> InsertFailIndexes { get; init; }

    [JsonPropertyName("enableFailIndexes")]
    public List<int> EnableFailIndexes { get; init; }
}
