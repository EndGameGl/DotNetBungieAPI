using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions
{
    /// <summary>
    ///     These properties are an attempt to categorize talent node steps by certain common properties. See the related
    ///     enumerations for the type of properties being categorized.
    /// </summary>
    public sealed record DestinyTalentNodeStepGroups : IDeepEquatable<DestinyTalentNodeStepGroups>
    {
        [JsonPropertyName("weaponPerformance")]
        public DestinyTalentNodeStepWeaponPerformances WeaponPerformance { get; init; }

        [JsonPropertyName("impactEffects")] public DestinyTalentNodeStepImpactEffects ImpactEffects { get; init; }

        [JsonPropertyName("guardianAttributes")]
        public DestinyTalentNodeStepGuardianAttributes GuardianAttributes { get; init; }

        [JsonPropertyName("lightAbilities")] public DestinyTalentNodeStepLightAbilities LightAbilities { get; init; }
        [JsonPropertyName("damageTypes")] public DestinyTalentNodeStepDamageTypes DamageTypes { get; init; }

        public bool DeepEquals(DestinyTalentNodeStepGroups other)
        {
            return other != null &&
                   WeaponPerformance == other.WeaponPerformance &&
                   ImpactEffects == other.ImpactEffects &&
                   GuardianAttributes == other.GuardianAttributes &&
                   LightAbilities == other.LightAbilities &&
                   DamageTypes == other.DamageTypes;
        }
    }
}