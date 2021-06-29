using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Common
{
    public sealed record CoreSetting
    {
        [JsonPropertyName("identifier")] public string Identifier { get; init; }

        [JsonPropertyName("isDefault")] public bool IsDefault { get; init; }

        [JsonPropertyName("displayName")] public string DisplayName { get; init; }

        [JsonPropertyName("summary")] public string Summary { get; init; }

        [JsonPropertyName("imagePath")] public DestinyResource ImagePath { get; init; }

        [JsonPropertyName("childSettings")]
        public ReadOnlyCollection<CoreSetting> ChildSettings { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        public override string ToString()
        {
            return $"{Identifier} : {DisplayName} | {Summary}";
        }
    }
}