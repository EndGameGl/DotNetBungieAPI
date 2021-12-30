using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorInteractionReplyDefinition
{

    [JsonPropertyName("itemRewardsSelection")]
    public Destiny.DestinyVendorInteractionRewardSelection ItemRewardsSelection { get; init; }

    [JsonPropertyName("reply")]
    public string Reply { get; init; }

    [JsonPropertyName("replyType")]
    public Destiny.DestinyVendorReplyType ReplyType { get; init; }
}
