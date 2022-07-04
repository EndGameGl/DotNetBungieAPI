using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace DotNetBungieAPI.Extensions;

public static class HistoricalStatDefinitionPointerExtensions
{
    public static bool TryGetDefinition(
        out DestinyHistoricalStatsDefinition definition, 
        BungieLocales locale = BungieLocales.EN)
    {
        definition = default;
        return BungieClient.Instance.TryGetHistoricalStatDefinition(definition!.StatId, locale, out definition);
    }
}