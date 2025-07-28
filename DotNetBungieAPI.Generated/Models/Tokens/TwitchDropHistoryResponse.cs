namespace DotNetBungieAPI.Generated.Models.Tokens;

public class TwitchDropHistoryResponse
{
    [JsonPropertyName("Title")]
    public string Title { get; set; }

    [JsonPropertyName("Description")]
    public string Description { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("ClaimState")]
    public Streaming.DropStateEnum? ClaimState { get; set; }
}
