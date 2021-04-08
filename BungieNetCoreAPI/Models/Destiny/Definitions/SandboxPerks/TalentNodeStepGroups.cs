using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.SandboxPerks
{
    public class TalentNodeStepGroups : IDeepEquatable<TalentNodeStepGroups>
    {
        public TalentNodeStepWeaponPerformances WeaponPerformance { get; init; }
        public TalentNodeStepImpactEffects ImpactEffects { get; init; }
        public TalentNodeStepGuardianAttributes GuardianAttributes { get; init; }
        public TalentNodeStepLightAbilities LightAbilities { get; init; }
        public TalentNodeStepDamageTypes DamageTypes { get; init; }

        [JsonConstructor]
        internal TalentNodeStepGroups(TalentNodeStepWeaponPerformances weaponPerformance, TalentNodeStepImpactEffects impactEffects,
            TalentNodeStepGuardianAttributes guardianAttributes, TalentNodeStepLightAbilities lightAbilities, TalentNodeStepDamageTypes damageTypes)
        {
            WeaponPerformance = weaponPerformance;
            ImpactEffects = impactEffects;
            GuardianAttributes = guardianAttributes;
            LightAbilities = lightAbilities;
            DamageTypes = damageTypes;
        }

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
