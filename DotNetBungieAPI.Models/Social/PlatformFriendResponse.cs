﻿namespace DotNetBungieAPI.Models.Social;

public sealed record PlatformFriendResponse
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; init; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("platformFriends")]
    public ReadOnlyCollection<PlatformFriend> PlatformFriends { get; init; } =
        ReadOnlyCollection<PlatformFriend>.Empty;
}
