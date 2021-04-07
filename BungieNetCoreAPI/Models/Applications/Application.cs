using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Applications
{
    public sealed record Application
    {
        [JsonPropertyName("applicationId")]
        public int ApplicationId { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; init; }

        [JsonPropertyName("link")]
        public string Link { get; init; }

        [JsonPropertyName("scope")]
        public ApplicationScopes Scope { get; init; }

        [JsonPropertyName("origin")]
        public string Origin { get; init; }

        [JsonPropertyName("status")]
        public ApplicationStatus Status { get; init; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; init; }

        [JsonPropertyName("statusChanged")]
        public DateTime StatusChanged { get; init; }

        [JsonPropertyName("firstPublished")]
        public DateTime FirstPublished { get; init; }

        [JsonPropertyName("team")]
        public ReadOnlyCollection<ApplicationDeveloper> Team { get; init; } = Defaults.EmptyReadOnlyCollection<ApplicationDeveloper>();
    }
}
