using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Perks
{
    public sealed record DestinyPerkReference
    {
        [JsonPropertyName("perkHash")]
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; init; } = DefinitionHashPointer<DestinySandboxPerkDefinition>.Empty;
        [JsonPropertyName("iconPath")]
        public string IconPath { get; init; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; init; }
        [JsonPropertyName("visible")]
        public bool IsVisible { get; init; }
    }
}
