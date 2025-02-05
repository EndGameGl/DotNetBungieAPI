﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemTalentGridComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyItemTalentGridComponent>.Empty;
}
