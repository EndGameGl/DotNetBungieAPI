using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Reporting;

public sealed class DestinyReportReasonDefinition
{

    [JsonPropertyName("reasonHash")]
    public uint ReasonHash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
}
