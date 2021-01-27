using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ItemCategories
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyItemCategoryDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyItemCategoryDefinition : IDestinyDefinition
    {
        public bool Deprecated { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyBreakerTypes GrantDestinyBreakerType { get; }
        public DestinyClassType GrantDestinyClass { get; }
        public ItemType GrantDestinyItemType { get; }
        public ItemSubType GrantDestinySubType { get; }
        public bool GroupCategoryOnly { get; }
        public List<DefinitionHashPointer<DestinyItemCategoryDefinition>> GroupedCategories { get; }
        public bool IsPlug { get; }
        public string ItemTypeRegex { get; }
        public List<DefinitionHashPointer<DestinyItemCategoryDefinition>> ParentCategories { get; }
        public string ShortTitle { get; }
        public bool Visible { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyItemCategoryDefinition(bool deprecated, DestinyDefinitionDisplayProperties displayProperties, DestinyBreakerTypes grantDestinyBreakerType,
            DestinyClassType grantDestinyClass, ItemType grantDestinyItemType, ItemSubType grantDestinySubType, bool groupCategoryOnly, List<uint> groupedCategoryHashes,
            bool isPlug, string itemTypeRegex, List<uint> parentCategoryHashes, string shortTitle, bool visible,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            Deprecated = deprecated;
            DisplayProperties = displayProperties;
            GrantDestinyBreakerType = grantDestinyBreakerType;
            GrantDestinyClass = grantDestinyClass;
            GrantDestinyItemType = grantDestinyItemType;
            GrantDestinySubType = grantDestinySubType;
            GroupCategoryOnly = groupCategoryOnly;
            GroupedCategories = new List<DefinitionHashPointer<DestinyItemCategoryDefinition>>();
            if (groupedCategoryHashes != null)
            {
                foreach (var groupedCategoryHash in groupedCategoryHashes)
                {
                    GroupedCategories.Add(new DefinitionHashPointer<DestinyItemCategoryDefinition>(groupedCategoryHash, DefinitionsEnum.DestinyItemCategoryDefinition));
                }
            }
            IsPlug = isPlug;
            ItemTypeRegex = itemTypeRegex;
            ParentCategories = new List<DefinitionHashPointer<DestinyItemCategoryDefinition>>();
            if (parentCategoryHashes != null)
            {
                foreach (var parentCategoryHash in parentCategoryHashes)
                {
                    ParentCategories.Add(new DefinitionHashPointer<DestinyItemCategoryDefinition>(parentCategoryHash, DefinitionsEnum.DestinyItemCategoryDefinition));
                }
            }
            ShortTitle = shortTitle;
            Visible = visible;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
