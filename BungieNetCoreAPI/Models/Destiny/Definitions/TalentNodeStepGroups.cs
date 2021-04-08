using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    public sealed record TalentNodeStepGroups : IDeepEquatable<TalentNodeStepGroups>
    {
        [JsonPropertyName("weaponPerformance")]
        public DestinyTalentNodeStepWeaponPerformances WeaponPerformance { get; init; }
        [JsonPropertyName("impactEffects")]
        public DestinyTalentNodeStepImpactEffects ImpactEffects { get; init; }
        [JsonPropertyName("guardianAttributes")]
        public DestinyTalentNodeStepGuardianAttributes GuardianAttributes { get; init; }
        [JsonPropertyName("lightAbilities")]
        public DestinyTalentNodeStepLightAbilities LightAbilities { get; init; }
        [JsonPropertyName("damageTypes")]
        public DestinyTalentNodeStepDamageTypes DamageTypes { get; init; }

        public bool DeepEquals(TalentNodeStepGroups other)
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
