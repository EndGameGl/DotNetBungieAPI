using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;
using DotNetBungieAPI.Models.Destiny.Definitions.SeasonPasses;
using DotNetBungieAPI.Models.Destiny.Definitions.Unlocks;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons
{
    /// <summary>
    ///     Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges,
    ///     provides new loot, has new Clan-related rewards and celebrates various seasonal events.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinySeasonDefinition)]
    public sealed record DestinySeasonDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("backgroundImagePath")]
        public BungieNetResource BackgroundImagePath { get; init; }

        [JsonPropertyName("seasonNumber")] public int SeasonNumber { get; init; }
        [JsonPropertyName("startDate")] public DateTime? StartDate { get; init; }
        [JsonPropertyName("endDate")] public DateTime? EndDate { get; init; }

        [JsonPropertyName("seasonPassHash")]
        public DefinitionHashPointer<DestinySeasonPassDefinition> SeasonPass { get; init; } =
            DefinitionHashPointer<DestinySeasonPassDefinition>.Empty;

        [JsonPropertyName("seasonPassProgressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> SeasonPassProgression { get; init; } =
            DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

        [JsonPropertyName("artifactItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ArtifactItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("sealPresentationNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SeasonalChallengesPresentationNode
        {
            get;
            init;
        } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("seasonPassUnlockHash")]
        public DefinitionHashPointer<DestinyUnlockDefinition> SeasonPassUnlock { get; init; } =
            DefinitionHashPointer<DestinyUnlockDefinition>.Empty;

        [JsonPropertyName("startTimeInSeconds")]
        public string StartTimeInSeconds { get; init; }

        /// <summary>
        ///     Optional - Defines the promotional text, images, and links to preview this season.
        /// </summary>
        [JsonPropertyName("preview")]
        public DestinySeasonPreviewDefinition Preview { get; init; }

        public bool DeepEquals(DestinySeasonDefinition other)
        {
            return other != null &&
                   ArtifactItem.DeepEquals(other.ArtifactItem) &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   SeasonNumber == other.SeasonNumber &&
                   SealPresentationNode.DeepEquals(other.SealPresentationNode) &&
                   SeasonalChallengesPresentationNode.DeepEquals(other.SeasonalChallengesPresentationNode) &&
                   SeasonPass.DeepEquals(other.SeasonPass) &&
                   SeasonPassProgression.DeepEquals(other.SeasonPassProgression) &&
                   SeasonPassUnlock.DeepEquals(other.SeasonPassUnlock) &&
                   StartTimeInSeconds == other.StartTimeInSeconds &&
                   StartDate == other.StartDate &&
                   EndDate == other.EndDate &&
                   Preview.DeepEquals(other.Preview) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySeasonDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            ArtifactItem.TryMapValue();
            SealPresentationNode.TryMapValue();
            SeasonalChallengesPresentationNode.TryMapValue();
            SeasonPass.TryMapValue();
            SeasonPassProgression.TryMapValue();
            SeasonPassUnlock.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            ArtifactItem.SetLocale(locale);
            SealPresentationNode.SetLocale(locale);
            SeasonalChallengesPresentationNode.SetLocale(locale);
            SeasonPass.SetLocale(locale);
            SeasonPassProgression.SetLocale(locale);
            SeasonPassUnlock.SetLocale(locale);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }
    }
}