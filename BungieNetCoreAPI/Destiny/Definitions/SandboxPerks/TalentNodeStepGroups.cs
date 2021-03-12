using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPerks
{
    public class TalentNodeStepGroups : IDeepEquatable<TalentNodeStepGroups>
    {
        public TalentNodeStepWeaponPerformances WeaponPerformance { get; }
        public TalentNodeStepImpactEffects ImpactEffects { get; }
        public TalentNodeStepGuardianAttributes GuardianAttributes { get; }
        public TalentNodeStepLightAbilities LightAbilities { get; }
        public TalentNodeStepDamageTypes DamageTypes { get; }

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
