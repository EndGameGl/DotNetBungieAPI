using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ItemCategories
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyItemCategoryDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyItemCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyItemCategoryDefinition>
    {
        /// <summary>
        /// If True, this category has been deprecated: it may have no items left, or there may be only legacy items that remain in it which are no longer relevant to the game.
        /// </summary>
        public bool Deprecated { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// If the item in question has this category, it also should have this breaker type.
        /// </summary>
        public DestinyBreakerTypes GrantDestinyBreakerType { get; }
        /// <summary>
        /// If an item belongs to this category, it will also get this class restriction enum value.
        /// </summary>
        public DestinyClassType GrantDestinyClass { get; }
        /// <summary>
        /// If an item belongs to this category, it will also receive this item type. This is now how DestinyItemType is populated for items: it used to be an even jankier process, but that's a story that requires more alcohol.
        /// </summary>
        public ItemType GrantDestinyItemType { get; }
        /// <summary>
        /// If an item belongs to this category, it will also receive this subtype enum value.
        /// </summary>
        public ItemSubType GrantDestinySubType { get; }
        /// <summary>
        /// If true, this category is only used for grouping, and should not be evaluated with its own checks. Rather, the item only has this category if it has one of its child categories.
        /// </summary>
        public bool GroupCategoryOnly { get; }
        /// <summary>
        /// If this category is a "parent" category of other categories, those children will have their hashes listed in rendering order here, and can be looked up using these hashes against DestinyItemCategoryDefinition.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>> GroupedCategories { get; }
        public bool IsPlug { get; }
        /// <summary>
        /// The janky regular expression we used against the item type to try and discern whether the item belongs to this category.
        /// </summary>
        public string ItemTypeRegex { get; }
        /// <summary>
        /// All item category hashes of "parent" categories: categories that contain this as a child through the hierarchy of groupedCategoryHashes. It's a bit redundant, but having this child-centric list speeds up some calculations.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>> ParentCategories { get; }
        /// <summary>
        /// A shortened version of the title. The reason why we have this is because the Armory in German had titles that were too long to display in our UI, so these were localized abbreviated versions of those categories. The property still exists today, even though the Armory doesn't exist for D2... yet.
        /// </summary>
        public string ShortTitle { get; }
        /// <summary>
        /// If True, this category should be visible in UI. Sometimes we make categories that we don't think are interesting externally. It's up to you if you want to skip on showing them.
        /// </summary>
        public bool Visible { get; }
        /// <summary>
        /// If the item is a plug, this is the identifier we expect to find associated with it if it is in this category.
        /// </summary>
        public string PlugCategoryIdentifier { get; }
        /// <summary>
        /// If the item type matches this janky regex, it does *not* belong to this category.
        /// </summary>
        public string ItemTypeRegexNot { get; }
        /// <summary>
        /// If the item belongs to this bucket, it does belong to this category.
        /// </summary>
        public string OriginBucketIdentifier { get; }
        public string TraitId { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyItemCategoryDefinition(bool deprecated, DestinyDefinitionDisplayProperties displayProperties, DestinyBreakerTypes grantDestinyBreakerType,
            DestinyClassType grantDestinyClass, ItemType grantDestinyItemType, ItemSubType grantDestinySubType, bool groupCategoryOnly, uint[] groupedCategoryHashes,
            bool isPlug, string itemTypeRegex, uint[] parentCategoryHashes, string shortTitle, bool visible, string plugCategoryIdentifier, string itemTypeRegexNot,
            string originBucketIdentifier, string traitId,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            Deprecated = deprecated;
            DisplayProperties = displayProperties;
            GrantDestinyBreakerType = grantDestinyBreakerType;
            GrantDestinyClass = grantDestinyClass;
            GrantDestinyItemType = grantDestinyItemType;
            GrantDestinySubType = grantDestinySubType;
            GroupCategoryOnly = groupCategoryOnly;
            GroupedCategories = groupedCategoryHashes.DefinitionsAsReadOnlyOrEmpty<DestinyItemCategoryDefinition>(DefinitionsEnum.DestinyItemCategoryDefinition);
            IsPlug = isPlug;
            ItemTypeRegex = itemTypeRegex;
            ParentCategories = parentCategoryHashes.DefinitionsAsReadOnlyOrEmpty<DestinyItemCategoryDefinition>(DefinitionsEnum.DestinyItemCategoryDefinition);
            ShortTitle = shortTitle;
            Visible = visible;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            PlugCategoryIdentifier = plugCategoryIdentifier;
            ItemTypeRegexNot = itemTypeRegexNot;
            OriginBucketIdentifier = originBucketIdentifier;
            TraitId = traitId;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name} {(GroupCategoryOnly == true ? "(Group category only)" : string.Empty)}";
        }
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
        public void MapValues()
        {
            foreach (var childCategories in GroupedCategories)
            {
                childCategories.TryMapValue();
            }
            foreach (var parentCategory in ParentCategories)
            {
                parentCategory.TryMapValue();
            }
        }
    }
}
