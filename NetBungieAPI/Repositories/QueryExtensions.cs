using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.ItemCategories;
using System.Collections.Generic;
using System.Linq;
using NetBungieAPI.Models.Destiny.Definitions.Lores;
using NetBungieAPI.Models.Destiny.Definitions.Seasons;

namespace NetBungieAPI.Repositories
{
    public static class QueryExtensions
    {
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsUsable(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Action is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsQuest(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.SetData is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithStats(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Stats is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsEquippable(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.EquippingBlock is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithPreview(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Preview is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithObjectives(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Objectives is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsPlug(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Plug is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsGearSet(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Gearset is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> IsSack(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Sack is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithSockets(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Sockets is not null);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithPerks(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Perks.Count > 0);
        }
        
        public static IEnumerable<DestinyInventoryItemDefinition> WithLore(
            this IEnumerable<DestinyInventoryItemDefinition> query)
        {
            return query.Where(x => x.Lore != DefinitionHashPointer<DestinyLoreDefinition>.Empty);
        }

        public static Dictionary<DestinyItemCategoryDefinition, List<DestinyInventoryItemDefinition>>
            GetItemsCategorized(this ILocalisedDestinyDefinitionRepositories repo, BungieLocales locale)
        {
            var result = new Dictionary<DestinyItemCategoryDefinition, List<DestinyInventoryItemDefinition>>();
            foreach (var category in repo.GetAll<DestinyItemCategoryDefinition>(locale))
            {
                List<DestinyInventoryItemDefinition> categorizedItems = new List<DestinyInventoryItemDefinition>();
                result.Add(category, categorizedItems);
            }

            foreach (var item in repo.GetAll<DestinyInventoryItemDefinition>(locale))
            {
                foreach (var category in item.ItemCategories)
                {
                    if (category.TryGetDefinition(out var value))
                    {
                        result[value].Add(item);
                    }
                }
            }

            return result;
        }
        
        public static Dictionary<DestinySeasonDefinition, List<DestinyInventoryItemDefinition>>
            GetGroupItemsBySeason(this ILocalisedDestinyDefinitionRepositories repo, BungieLocales locale)
        {
            var result = new Dictionary<DestinySeasonDefinition, List<DestinyInventoryItemDefinition>>();
            foreach (var season in repo.GetAll<DestinySeasonDefinition>(locale))
            {
                result.Add(season, new List<DestinyInventoryItemDefinition>());
            }

            foreach (var item in repo.GetAll<DestinyInventoryItemDefinition>(locale))
            {
                if (item.Season.TryGetDefinition(out var seasonDefinition))
                {
                    result[seasonDefinition].Add(item);
                }

            }

            return result;
        }
    }
}