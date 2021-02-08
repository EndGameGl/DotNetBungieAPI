using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.ItemCategories;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Repositories
{
    public static class QueryExtensions
    {
        public static Dictionary<DestinyItemCategoryDefinition, List<DestinyInventoryItemDefinition>> GetItemsCategorized(this ILocalisedManifestDefinitionRepositories repo, DestinyLocales locale)
        {
            var result = new Dictionary<DestinyItemCategoryDefinition, List<DestinyInventoryItemDefinition>>();
            foreach (var category in repo.GetAll<DestinyItemCategoryDefinition>())
            {
                List<DestinyInventoryItemDefinition> categorizedItems = new List<DestinyInventoryItemDefinition>();
                result.Add(category, categorizedItems);
            }
            foreach (var item in repo.GetAll<DestinyInventoryItemDefinition>())
            {
                foreach (var category in item.ItemCategories)
                {
                    result[category.Value].Add(item);
                }
            }
            return result;
        }

    }
}
