﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemInstanceComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemInstanceComponent>.Empty;
}
