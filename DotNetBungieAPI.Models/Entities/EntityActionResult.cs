﻿namespace DotNetBungieAPI.Models.Entities;

public sealed record EntityActionResult
{
    [JsonPropertyName("entityId")]
    public long EntityId { get; init; }

    [JsonPropertyName("result")]
    public int Result { get; init; }
}
