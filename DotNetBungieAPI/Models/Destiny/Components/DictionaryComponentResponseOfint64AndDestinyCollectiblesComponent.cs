﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCollectiblesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCollectiblesComponent>();
    }
}