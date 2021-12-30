using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     These properties are an attempt to categorize talent node steps by certain common properties. See the related enumerations for the type of properties being categorized.
/// </summary>
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
