﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemStatsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemStatsComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyItemStatsComponent>.Empty;
}