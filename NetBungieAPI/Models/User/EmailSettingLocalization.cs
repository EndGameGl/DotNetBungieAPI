using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    /// <summary>
    /// Localized text relevant to a given Email setting in a given localization.
    /// </summary>
    public sealed record EmailSettingLocalization
    {
        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }
    }
}
