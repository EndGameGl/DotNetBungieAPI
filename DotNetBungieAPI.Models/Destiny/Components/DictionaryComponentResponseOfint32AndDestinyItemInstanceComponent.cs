﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemInstanceComponent> Data { get; init; } =
        ReadOnlyDictionary<int, DestinyItemInstanceComponent>.Empty;
}
