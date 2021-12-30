using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemInventoryBlockDefinition
{

    [JsonPropertyName("stackUniqueLabel")]
    public string StackUniqueLabel { get; init; }

    [JsonPropertyName("maxStackSize")]
    public int MaxStackSize { get; init; }

    [JsonPropertyName("bucketTypeHash")]
    public uint BucketTypeHash { get; init; }

    [JsonPropertyName("recoveryBucketTypeHash")]
    public uint RecoveryBucketTypeHash { get; init; }

    [JsonPropertyName("tierTypeHash")]
    public uint TierTypeHash { get; init; }

    [JsonPropertyName("isInstanceItem")]
    public bool IsInstanceItem { get; init; }

    [JsonPropertyName("tierTypeName")]
    public string TierTypeName { get; init; }

    [JsonPropertyName("tierType")]
    public Destiny.TierType TierType { get; init; }

    [JsonPropertyName("expirationTooltip")]
    public string ExpirationTooltip { get; init; }

    [JsonPropertyName("expiredInActivityMessage")]
    public string ExpiredInActivityMessage { get; init; }

    [JsonPropertyName("expiredInOrbitMessage")]
    public string ExpiredInOrbitMessage { get; init; }

    [JsonPropertyName("suppressExpirationWhenObjectivesComplete")]
    public bool SuppressExpirationWhenObjectivesComplete { get; init; }
}
