using DotNetBungieAPI.Models.Streaming;

namespace DotNetBungieAPI.Models.Tokens;

public sealed record TwitchDropHistoryResponse
{
    [JsonPropertyName("Title")]
    public string Title { get; init; }

    [JsonPropertyName("Description")]
    public string Description { get; init; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; init; }

    [JsonPropertyName("ClaimState")]
    public DropStateEnum? ClaimState { get; init; }
}