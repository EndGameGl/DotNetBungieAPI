using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyEquipItemResult
{

    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    [JsonPropertyName("equipStatus")]
    public Exceptions.PlatformErrorCodes EquipStatus { get; init; }
}
