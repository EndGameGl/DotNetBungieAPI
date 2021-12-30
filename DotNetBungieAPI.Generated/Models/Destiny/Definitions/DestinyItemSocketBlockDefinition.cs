using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSocketBlockDefinition
{

    [JsonPropertyName("detail")]
    public string Detail { get; init; }

    [JsonPropertyName("socketEntries")]
    public List<Destiny.Definitions.DestinyItemSocketEntryDefinition> SocketEntries { get; init; }

    [JsonPropertyName("intrinsicSockets")]
    public List<Destiny.Definitions.DestinyItemIntrinsicSocketEntryDefinition> IntrinsicSockets { get; init; }

    [JsonPropertyName("socketCategories")]
    public List<Destiny.Definitions.DestinyItemSocketCategoryDefinition> SocketCategories { get; init; }
}
