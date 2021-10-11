﻿using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyStringVariablesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyStringVariablesComponent Data { get; init; }
    }
}