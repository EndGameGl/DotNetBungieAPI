﻿namespace DotNetBungieAPI.Models.Requests;

public sealed class ExactSearchRequest
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("displayNameCode")]
    public short DisplayNameCode { get; init; }
}
