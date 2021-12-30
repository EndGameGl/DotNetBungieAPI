using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentNodeStepGroups
{

    [JsonPropertyName("weaponPerformance")]
    public Destiny.Definitions.DestinyTalentNodeStepWeaponPerformances WeaponPerformance { get; init; }

    [JsonPropertyName("impactEffects")]
    public Destiny.Definitions.DestinyTalentNodeStepImpactEffects ImpactEffects { get; init; }

    [JsonPropertyName("guardianAttributes")]
    public Destiny.Definitions.DestinyTalentNodeStepGuardianAttributes GuardianAttributes { get; init; }

    [JsonPropertyName("lightAbilities")]
    public Destiny.Definitions.DestinyTalentNodeStepLightAbilities LightAbilities { get; init; }

    [JsonPropertyName("damageTypes")]
    public Destiny.Definitions.DestinyTalentNodeStepDamageTypes DamageTypes { get; init; }
}
