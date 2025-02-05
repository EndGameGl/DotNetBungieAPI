﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCharacterRenderComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyCharacterRenderComponent>.Empty;
}
