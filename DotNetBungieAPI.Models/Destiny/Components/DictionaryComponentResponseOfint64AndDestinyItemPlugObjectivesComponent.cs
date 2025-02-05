﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemPlugObjectivesComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyItemPlugObjectivesComponent>.Empty;
}
