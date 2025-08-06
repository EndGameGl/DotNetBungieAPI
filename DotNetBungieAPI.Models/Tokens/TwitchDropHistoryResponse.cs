namespace DotNetBungieAPI.Models.Tokens;

public sealed class TwitchDropHistoryResponse
{
    [JsonPropertyName("Title")]
    public string Title { get; init; }

    [JsonPropertyName("Description")]
    public string Description { get; init; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; init; }

    [JsonPropertyName("ClaimState")]
    public Streaming.DropStateEnum? ClaimState { get; init; }
}
