using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace DotNetBungieAPI.Extensions;

public static class HistoricalStatDefinitionPointerExtensions
{
    public static bool TryGetDefinition(
        [NotNullWhen(true)] out DestinyHistoricalStatsDefinition? definition,
        BungieLocales locale = BungieLocales.EN
    )
    {
        definition = null;
        return BungieClient.Instance.TryGetHistoricalStatDefinition(
            definition!.StatId,
            out definition,
            locale
        );
    }
}
