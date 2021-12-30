using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSocketEntryPlugItemRandomizedDefinition
{

    [JsonPropertyName("currentlyCanRoll")]
    public bool CurrentlyCanRoll { get; init; }

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }
}
