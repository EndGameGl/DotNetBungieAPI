using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSourceBlockDefinition
{

    [JsonPropertyName("sourceHashes")]
    public List<uint> SourceHashes { get; init; }

    [JsonPropertyName("sources")]
    public List<Destiny.Definitions.Sources.DestinyItemSourceDefinition> Sources { get; init; }

    [JsonPropertyName("exclusive")]
    public BungieMembershipType Exclusive { get; init; }

    [JsonPropertyName("vendorSources")]
    public List<Destiny.Definitions.DestinyItemVendorSourceReference> VendorSources { get; init; }
}
