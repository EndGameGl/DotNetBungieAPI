﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemPerksComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemPerksComponent> Data { get; init; } =
        ReadOnlyDictionary<int, DestinyItemPerksComponent>.Empty;
}
