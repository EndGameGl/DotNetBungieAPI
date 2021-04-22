﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyVendorCategoriesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyVendorCategoriesComponent>();
    }
}