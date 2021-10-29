using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Content
{
    public sealed record ContentItemPublicContract
    {
        [JsonPropertyName("contentId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long ContentId { get; init; }

        [JsonPropertyName("cType")] public string ContentType { get; init; }

        [JsonPropertyName("cmsPath")] public string CmsPath { get; init; }

        [JsonPropertyName("creationDate")] public DateTime CreationDate { get; init; }

        [JsonPropertyName("modifyDate")] public DateTime ModifyDate { get; init; }

        [JsonPropertyName("allowComments")] public bool AllowComments { get; init; }

        [JsonPropertyName("hasAgeGate")] public bool HasAgeGate { get; init; }

        [JsonPropertyName("minimumAge")] public int MinimumAge { get; init; }

        [JsonPropertyName("ratingImagePath")] public string RatingImagePath { get; init; }

        [JsonPropertyName("author")] public GeneralUser Author { get; init; }

        [JsonPropertyName("autoEnglishPropertyFallback")]
        public bool AutoEnglishPropertyFallback { get; init; }

        [JsonPropertyName("properties")]
        public ReadOnlyDictionary<string, object> Properties { get; init; } =
            ReadOnlyDictionaries<string, object>.Empty;

        [JsonPropertyName("representations")]
        public ReadOnlyCollection<ContentRepresentation> Representations { get; init; } =
            ReadOnlyCollections<ContentRepresentation>.Empty;

        [JsonPropertyName("tags")]
        public ReadOnlyCollection<string> Tags { get; init; } = ReadOnlyCollections<string>.Empty;

        [JsonPropertyName("commentSummary")] public CommentSummary CommentSummary { get; init; }
    }
}