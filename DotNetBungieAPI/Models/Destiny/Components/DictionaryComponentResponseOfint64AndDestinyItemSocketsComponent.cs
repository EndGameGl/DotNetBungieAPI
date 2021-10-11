﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemSocketsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemSocketsComponent>();
    }
}