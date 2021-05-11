﻿using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyStringVariablesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyVendorCategoriesComponent Data { get; init; }
    }
}