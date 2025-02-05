﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemObjectivesComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyItemObjectivesComponent>.Empty;
}
