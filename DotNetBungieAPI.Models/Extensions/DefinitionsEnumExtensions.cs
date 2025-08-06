using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Models.Extensions;

/// <summary>
///     Extension class for <see cref="DefinitionsEnum"/>
/// </summary>

public static class DefinitionsEnumExtensions
{
    /// <summary>
    ///     Direct string naming mapping for all enum values
    /// </summary>
    /// <param name="definitionsEnum"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string ToStringFast(this DefinitionsEnum definitionsEnum) =>
        definitionsEnum switch
        {
            DefinitionsEnum.DestinyActivityDefinition => nameof(DefinitionsEnum.DestinyActivityDefinition),
            DefinitionsEnum.DestinyActivityDifficultyTierCollectionDefinition => nameof(DefinitionsEnum.DestinyActivityDifficultyTierCollectionDefinition),
            DefinitionsEnum.DestinyActivityFamilyDefinition => nameof(DefinitionsEnum.DestinyActivityFamilyDefinition),
            DefinitionsEnum.DestinyActivityGraphDefinition => nameof(DefinitionsEnum.DestinyActivityGraphDefinition),
            DefinitionsEnum.DestinyActivityInteractableDefinition => nameof(DefinitionsEnum.DestinyActivityInteractableDefinition),
            DefinitionsEnum.DestinyActivityLoadoutRestrictionDefinition => nameof(DefinitionsEnum.DestinyActivityLoadoutRestrictionDefinition),
            DefinitionsEnum.DestinyActivityModeDefinition => nameof(DefinitionsEnum.DestinyActivityModeDefinition),
            DefinitionsEnum.DestinyActivityModifierDefinition => nameof(DefinitionsEnum.DestinyActivityModifierDefinition),
            DefinitionsEnum.DestinyActivitySelectableSkullCollectionDefinition => nameof(DefinitionsEnum.DestinyActivitySelectableSkullCollectionDefinition),
            DefinitionsEnum.DestinyActivitySelectableSkullExclusionGroupDefinition => nameof(DefinitionsEnum.DestinyActivitySelectableSkullExclusionGroupDefinition),
            DefinitionsEnum.DestinyActivitySkullCategoryDefinition => nameof(DefinitionsEnum.DestinyActivitySkullCategoryDefinition),
            DefinitionsEnum.DestinyActivitySkullSubcategoryDefinition => nameof(DefinitionsEnum.DestinyActivitySkullSubcategoryDefinition),
            DefinitionsEnum.DestinyActivityTypeDefinition => nameof(DefinitionsEnum.DestinyActivityTypeDefinition),
            DefinitionsEnum.DestinyArtifactDefinition => nameof(DefinitionsEnum.DestinyArtifactDefinition),
            DefinitionsEnum.DestinyBreakerTypeDefinition => nameof(DefinitionsEnum.DestinyBreakerTypeDefinition),
            DefinitionsEnum.DestinyChecklistDefinition => nameof(DefinitionsEnum.DestinyChecklistDefinition),
            DefinitionsEnum.DestinyClassDefinition => nameof(DefinitionsEnum.DestinyClassDefinition),
            DefinitionsEnum.DestinyCollectibleDefinition => nameof(DefinitionsEnum.DestinyCollectibleDefinition),
            DefinitionsEnum.DestinyDamageTypeDefinition => nameof(DefinitionsEnum.DestinyDamageTypeDefinition),
            DefinitionsEnum.DestinyDestinationDefinition => nameof(DefinitionsEnum.DestinyDestinationDefinition),
            DefinitionsEnum.DestinyEnergyTypeDefinition => nameof(DefinitionsEnum.DestinyEnergyTypeDefinition),
            DefinitionsEnum.DestinyEquipableItemSetDefinition => nameof(DefinitionsEnum.DestinyEquipableItemSetDefinition),
            DefinitionsEnum.DestinyEquipmentSlotDefinition => nameof(DefinitionsEnum.DestinyEquipmentSlotDefinition),
            DefinitionsEnum.DestinyEventCardDefinition => nameof(DefinitionsEnum.DestinyEventCardDefinition),
            DefinitionsEnum.DestinyFactionDefinition => nameof(DefinitionsEnum.DestinyFactionDefinition),
            DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition),
            DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition),
            DefinitionsEnum.DestinyFireteamFinderConstantsDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderConstantsDefinition),
            DefinitionsEnum.DestinyFireteamFinderLabelDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderLabelDefinition),
            DefinitionsEnum.DestinyFireteamFinderLabelGroupDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderLabelGroupDefinition),
            DefinitionsEnum.DestinyFireteamFinderOptionDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderOptionDefinition),
            DefinitionsEnum.DestinyFireteamFinderOptionGroupDefinition => nameof(DefinitionsEnum.DestinyFireteamFinderOptionGroupDefinition),
            DefinitionsEnum.DestinyGenderDefinition => nameof(DefinitionsEnum.DestinyGenderDefinition),
            DefinitionsEnum.DestinyGuardianRankConstantsDefinition => nameof(DefinitionsEnum.DestinyGuardianRankConstantsDefinition),
            DefinitionsEnum.DestinyGuardianRankDefinition => nameof(DefinitionsEnum.DestinyGuardianRankDefinition),
            DefinitionsEnum.DestinyInventoryBucketDefinition => nameof(DefinitionsEnum.DestinyInventoryBucketDefinition),
            DefinitionsEnum.DestinyInventoryItemConstantsDefinition => nameof(DefinitionsEnum.DestinyInventoryItemConstantsDefinition),
            DefinitionsEnum.DestinyInventoryItemDefinition => nameof(DefinitionsEnum.DestinyInventoryItemDefinition),
            DefinitionsEnum.DestinyItemCategoryDefinition => nameof(DefinitionsEnum.DestinyItemCategoryDefinition),
            DefinitionsEnum.DestinyItemFilterDefinition => nameof(DefinitionsEnum.DestinyItemFilterDefinition),
            DefinitionsEnum.DestinyItemTierTypeDefinition => nameof(DefinitionsEnum.DestinyItemTierTypeDefinition),
            DefinitionsEnum.DestinyLoadoutColorDefinition => nameof(DefinitionsEnum.DestinyLoadoutColorDefinition),
            DefinitionsEnum.DestinyLoadoutConstantsDefinition => nameof(DefinitionsEnum.DestinyLoadoutConstantsDefinition),
            DefinitionsEnum.DestinyLoadoutIconDefinition => nameof(DefinitionsEnum.DestinyLoadoutIconDefinition),
            DefinitionsEnum.DestinyLoadoutNameDefinition => nameof(DefinitionsEnum.DestinyLoadoutNameDefinition),
            DefinitionsEnum.DestinyLocationDefinition => nameof(DefinitionsEnum.DestinyLocationDefinition),
            DefinitionsEnum.DestinyLoreDefinition => nameof(DefinitionsEnum.DestinyLoreDefinition),
            DefinitionsEnum.DestinyMaterialRequirementSetDefinition => nameof(DefinitionsEnum.DestinyMaterialRequirementSetDefinition),
            DefinitionsEnum.DestinyMedalTierDefinition => nameof(DefinitionsEnum.DestinyMedalTierDefinition),
            DefinitionsEnum.DestinyMetricDefinition => nameof(DefinitionsEnum.DestinyMetricDefinition),
            DefinitionsEnum.DestinyMilestoneDefinition => nameof(DefinitionsEnum.DestinyMilestoneDefinition),
            DefinitionsEnum.DestinyObjectiveDefinition => nameof(DefinitionsEnum.DestinyObjectiveDefinition),
            DefinitionsEnum.DestinyPlaceDefinition => nameof(DefinitionsEnum.DestinyPlaceDefinition),
            DefinitionsEnum.DestinyPlugSetDefinition => nameof(DefinitionsEnum.DestinyPlugSetDefinition),
            DefinitionsEnum.DestinyPowerCapDefinition => nameof(DefinitionsEnum.DestinyPowerCapDefinition),
            DefinitionsEnum.DestinyPresentationNodeDefinition => nameof(DefinitionsEnum.DestinyPresentationNodeDefinition),
            DefinitionsEnum.DestinyProgressionDefinition => nameof(DefinitionsEnum.DestinyProgressionDefinition),
            DefinitionsEnum.DestinyProgressionLevelRequirementDefinition => nameof(DefinitionsEnum.DestinyProgressionLevelRequirementDefinition),
            DefinitionsEnum.DestinyProgressionMappingDefinition => nameof(DefinitionsEnum.DestinyProgressionMappingDefinition),
            DefinitionsEnum.DestinyRaceDefinition => nameof(DefinitionsEnum.DestinyRaceDefinition),
            DefinitionsEnum.DestinyRecordDefinition => nameof(DefinitionsEnum.DestinyRecordDefinition),
            DefinitionsEnum.DestinyReportReasonCategoryDefinition => nameof(DefinitionsEnum.DestinyReportReasonCategoryDefinition),
            DefinitionsEnum.DestinyRewardSourceDefinition => nameof(DefinitionsEnum.DestinyRewardSourceDefinition),
            DefinitionsEnum.DestinySandboxPatternDefinition => nameof(DefinitionsEnum.DestinySandboxPatternDefinition),
            DefinitionsEnum.DestinySandboxPerkDefinition => nameof(DefinitionsEnum.DestinySandboxPerkDefinition),
            DefinitionsEnum.DestinySeasonDefinition => nameof(DefinitionsEnum.DestinySeasonDefinition),
            DefinitionsEnum.DestinySeasonPassDefinition => nameof(DefinitionsEnum.DestinySeasonPassDefinition),
            DefinitionsEnum.DestinySocialCommendationDefinition => nameof(DefinitionsEnum.DestinySocialCommendationDefinition),
            DefinitionsEnum.DestinySocialCommendationNodeDefinition => nameof(DefinitionsEnum.DestinySocialCommendationNodeDefinition),
            DefinitionsEnum.DestinySocketCategoryDefinition => nameof(DefinitionsEnum.DestinySocketCategoryDefinition),
            DefinitionsEnum.DestinySocketTypeDefinition => nameof(DefinitionsEnum.DestinySocketTypeDefinition),
            DefinitionsEnum.DestinyStatDefinition => nameof(DefinitionsEnum.DestinyStatDefinition),
            DefinitionsEnum.DestinyStatGroupDefinition => nameof(DefinitionsEnum.DestinyStatGroupDefinition),
            DefinitionsEnum.DestinyTalentGridDefinition => nameof(DefinitionsEnum.DestinyTalentGridDefinition),
            DefinitionsEnum.DestinyTraitDefinition => nameof(DefinitionsEnum.DestinyTraitDefinition),
            DefinitionsEnum.DestinyUnlockDefinition => nameof(DefinitionsEnum.DestinyUnlockDefinition),
            DefinitionsEnum.DestinyUnlockValueDefinition => nameof(DefinitionsEnum.DestinyUnlockValueDefinition),
            DefinitionsEnum.DestinyVendorDefinition => nameof(DefinitionsEnum.DestinyVendorDefinition),
            DefinitionsEnum.DestinyVendorGroupDefinition => nameof(DefinitionsEnum.DestinyVendorGroupDefinition),
            _ => throw new ArgumentOutOfRangeException(nameof(definitionsEnum), definitionsEnum, null)
        };
}
