﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyVendorComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyVendorComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyVendorComponent>();
    }
}