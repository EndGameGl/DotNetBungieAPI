namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     These properties are an attempt to categorize talent node steps by certain common properties. See the related enumerations for the type of properties being categorized.
/// </summary>
public class DestinyTalentNodeStepGroups : IDeepEquatable<DestinyTalentNodeStepGroups>
{
    [JsonPropertyName("weaponPerformance")]
    public Destiny.Definitions.DestinyTalentNodeStepWeaponPerformances WeaponPerformance { get; set; }

    [JsonPropertyName("impactEffects")]
    public Destiny.Definitions.DestinyTalentNodeStepImpactEffects ImpactEffects { get; set; }

    [JsonPropertyName("guardianAttributes")]
    public Destiny.Definitions.DestinyTalentNodeStepGuardianAttributes GuardianAttributes { get; set; }

    [JsonPropertyName("lightAbilities")]
    public Destiny.Definitions.DestinyTalentNodeStepLightAbilities LightAbilities { get; set; }

    [JsonPropertyName("damageTypes")]
    public Destiny.Definitions.DestinyTalentNodeStepDamageTypes DamageTypes { get; set; }

    public bool DeepEquals(DestinyTalentNodeStepGroups? other)
    {
        return other is not null &&
               WeaponPerformance == other.WeaponPerformance &&
               ImpactEffects == other.ImpactEffects &&
               GuardianAttributes == other.GuardianAttributes &&
               LightAbilities == other.LightAbilities &&
               DamageTypes == other.DamageTypes;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyTalentNodeStepGroups? other)
    {
        if (other is null) return;
        if (WeaponPerformance != other.WeaponPerformance)
        {
            WeaponPerformance = other.WeaponPerformance;
            OnPropertyChanged(nameof(WeaponPerformance));
        }
        if (ImpactEffects != other.ImpactEffects)
        {
            ImpactEffects = other.ImpactEffects;
            OnPropertyChanged(nameof(ImpactEffects));
        }
        if (GuardianAttributes != other.GuardianAttributes)
        {
            GuardianAttributes = other.GuardianAttributes;
            OnPropertyChanged(nameof(GuardianAttributes));
        }
        if (LightAbilities != other.LightAbilities)
        {
            LightAbilities = other.LightAbilities;
            OnPropertyChanged(nameof(LightAbilities));
        }
        if (DamageTypes != other.DamageTypes)
        {
            DamageTypes = other.DamageTypes;
            OnPropertyChanged(nameof(DamageTypes));
        }
    }
}