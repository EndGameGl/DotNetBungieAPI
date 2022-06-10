namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     These properties are an attempt to categorize talent node steps by certain common properties. See the related enumerations for the type of properties being categorized.
/// </summary>
public class DestinyTalentNodeStepGroups
{
    [JsonPropertyName("weaponPerformance")]
    public Destiny.Definitions.DestinyTalentNodeStepWeaponPerformances? WeaponPerformance { get; set; }

    [JsonPropertyName("impactEffects")]
    public Destiny.Definitions.DestinyTalentNodeStepImpactEffects? ImpactEffects { get; set; }

    [JsonPropertyName("guardianAttributes")]
    public Destiny.Definitions.DestinyTalentNodeStepGuardianAttributes? GuardianAttributes { get; set; }

    [JsonPropertyName("lightAbilities")]
    public Destiny.Definitions.DestinyTalentNodeStepLightAbilities? LightAbilities { get; set; }

    [JsonPropertyName("damageTypes")]
    public Destiny.Definitions.DestinyTalentNodeStepDamageTypes? DamageTypes { get; set; }
}
