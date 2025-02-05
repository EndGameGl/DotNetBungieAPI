﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemSocketsComponent> Data { get; init; } =
        ReadOnlyDictionary<int, DestinyItemSocketsComponent>.Empty;
}
