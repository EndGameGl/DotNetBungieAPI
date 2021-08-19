using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.ItemCategories
{
    /// <summary>
    ///     In an attempt to categorize items by type, usage, and other interesting properties, we created
    ///     DestinyItemCategoryDefinition: information about types that is assembled using a set of heuristics that examine the
    ///     properties of an item such as what inventory bucket it's in, its item type name, and whether it has or is missing
    ///     certain blocks of data.
    ///     <para />
    ///     This heuristic is imperfect, however. If you find an item miscategorized, let us know on the Bungie API forums!
    ///     <para />
    ///     We then populate all of the categories that we think an item belongs to in its
    ///     DestinyInventoryItemDefinition.itemCategoryHashes property. You can use that to provide your own custom item
    ///     filtering, sorting, aggregating... go nuts on it! And let us know if you see more categories that you wish would be
    ///     added!
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyItemCategoryDefinition)]
    public sealed record DestinyItemCategoryDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyItemCategoryDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     If True, this category should be visible in UI. Sometimes we make categories that we don't think are interesting
        ///     externally. It's up to you if you want to skip on showing them.
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; init; }

        /// <summary>
        ///     If True, this category has been deprecated: it may have no items left, or there may be only legacy items that
        ///     remain in it which are no longer relevant to the game.
        /// </summary>
        [JsonPropertyName("deprecated")]
        public bool Deprecated { get; init; }

        /// <summary>
        ///     A shortened version of the title. The reason why we have this is because the Armory in German had titles that were
        ///     too long to display in our UI, so these were localized abbreviated versions of those categories. The property still
        ///     exists today, even though the Armory doesn't exist for D2... yet.
        /// </summary>
        [JsonPropertyName("shortTitle")]
        public string ShortTitle { get; init; }

        /// <summary>
        ///     The janky regular expression we used against the item type to try and discern whether the item belongs to this
        ///     category.
        /// </summary>
        [JsonPropertyName("itemTypeRegex")]
        public string ItemTypeRegex { get; init; }

        /// <summary>
        ///     If the item in question has this category, it also should have this breaker type.
        /// </summary>
        [JsonPropertyName("grantDestinyBreakerType")]
        public DestinyBreakerType GrantDestinyBreakerType { get; init; }

        /// <summary>
        ///     If the item is a plug, this is the identifier we expect to find associated with it if it is in this category.
        /// </summary>
        [JsonPropertyName("plugCategoryIdentifier")]
        public string PlugCategoryIdentifier { get; init; }

        /// <summary>
        ///     If the item type matches this janky regex, it does *not* belong to this category.
        /// </summary>
        [JsonPropertyName("itemTypeRegexNot")]
        public string ItemTypeRegexNot { get; init; }

        /// <summary>
        ///     If the item belongs to this bucket, it does belong to this category.
        /// </summary>
        [JsonPropertyName("originBucketIdentifier")]
        public string OriginBucketIdentifier { get; init; }

        /// <summary>
        ///     If an item belongs to this category, it will also receive this item type. This is now how DestinyItemType is
        ///     populated for items: it used to be an even jankier process, but that's a story that requires more alcohol.
        /// </summary>
        [JsonPropertyName("grantDestinyItemType")]
        public DestinyItemType GrantDestinyItemType { get; init; }

        /// <summary>
        ///     If an item belongs to this category, it will also receive this subtype enum value.
        /// </summary>
        [JsonPropertyName("grantDestinySubType")]
        public DestinyItemSubType GrantDestinySubType { get; init; }

        /// <summary>
        ///     If an item belongs to this category, it will also get this class restriction enum value.
        /// </summary>
        [JsonPropertyName("grantDestinyClass")]
        public DestinyClass GrantDestinyClass { get; init; }

        [JsonPropertyName("traitId")] public string TraitId { get; init; }

        /// <summary>
        ///     If this category is a "parent" category of other categories, those children will have their hashes listed in
        ///     rendering order here, and can be looked up using these hashes against DestinyItemCategoryDefinition.
        /// </summary>
        [JsonPropertyName("groupedCategoryHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>>
            GroupedCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>>();

        /// <summary>
        ///     All item category hashes of "parent" categories: categories that contain this as a child through the hierarchy of
        ///     groupedCategoryHashes. It's a bit redundant, but having this child-centric list speeds up some calculations.
        /// </summary>
        [JsonPropertyName("parentCategoryHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>>
            ParentCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>>();

        /// <summary>
        ///     If true, this category is only used for grouping, and should not be evaluated with its own checks. Rather, the item
        ///     only has this category if it has one of its child categories.
        /// </summary>
        [JsonPropertyName("groupCategoryOnly")]
        public bool GroupCategoryOnly { get; init; }

        [JsonPropertyName("isPlug")] public bool IsPlug { get; init; }

        public bool DeepEquals(DestinyItemCategoryDefinition other)
        {
            return other != null &&
                   Deprecated == other.Deprecated &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   GrantDestinyBreakerType == other.GrantDestinyBreakerType &&
                   GrantDestinyClass == other.GrantDestinyClass &&
                   GrantDestinyItemType == other.GrantDestinyItemType &&
                   GrantDestinySubType == other.GrantDestinySubType &&
                   GroupCategoryOnly == other.GroupCategoryOnly &&
                   GroupedCategories.DeepEqualsReadOnlyCollections(other.GroupedCategories) &&
                   IsPlug == other.IsPlug &&
                   ItemTypeRegex == other.ItemTypeRegex &&
                   ParentCategories.DeepEqualsReadOnlyCollections(other.ParentCategories) &&
                   ShortTitle == other.ShortTitle &&
                   Visible == other.Visible &&
                   PlugCategoryIdentifier == other.PlugCategoryIdentifier &&
                   ItemTypeRegexNot == other.ItemTypeRegexNot &&
                   OriginBucketIdentifier == other.OriginBucketIdentifier &&
                   TraitId == other.TraitId &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyItemCategoryDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var childCategories in GroupedCategories) childCategories.TryMapValue();

            foreach (var parentCategory in ParentCategories) parentCategory.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            foreach (var childCategories in GroupedCategories) childCategories.SetLocale(locale);

            foreach (var parentCategory in ParentCategories) parentCategory.SetLocale(locale);
        }

        public override string ToString()
        {
            return
                $"{Hash} {DisplayProperties.Name} {(GroupCategoryOnly ? "(Group category only)" : string.Empty)}";
        }
    }
}