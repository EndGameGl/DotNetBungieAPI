using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyUnlockStatus
{

    [JsonPropertyName("unlockHash")]
    public uint UnlockHash { get; init; }

    [JsonPropertyName("isSet")]
    public bool IsSet { get; init; }
}
