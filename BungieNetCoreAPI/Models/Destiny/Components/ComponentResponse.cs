using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public record ComponentResponse
    {
        [JsonPropertyName("privacy")]
        public ComponentPrivacySetting Privacy { get; init; }
        /// <summary>
        /// If true, this component is disabled.
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool? IsDisabled { get; init; }
    }
}
