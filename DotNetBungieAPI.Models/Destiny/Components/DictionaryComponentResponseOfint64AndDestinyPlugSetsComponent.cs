﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyPlugSetsComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyPlugSetsComponent>.Empty;
}
