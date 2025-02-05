﻿namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyPublicVendorComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyPublicVendorComponent>.Empty;
}
