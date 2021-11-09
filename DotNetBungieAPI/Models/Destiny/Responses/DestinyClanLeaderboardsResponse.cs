namespace DotNetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyClanLeaderboardsResponse
    {
        [JsonPropertyName("statId")] public string StatId { get; init; }

        [JsonPropertyName("entries")]
        public ReadOnlyCollection<DestinyClanLeaderboardsResponseEntry> Entries { get; init; } =
            ReadOnlyCollections<DestinyClanLeaderboardsResponseEntry>.Empty;
    }
}