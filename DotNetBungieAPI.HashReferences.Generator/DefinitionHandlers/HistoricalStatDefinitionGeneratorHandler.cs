using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.HistoricalStats.Definitions;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

public class HistoricalStatDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinyHistoricalStatsDefinition);

    public string ClassName => "HistoricalStats";

    public async Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation
    )
    {
        foreach (
            var statsDefinition in bungieClient
                .Repository.GetAllHistoricalStatsDefinitions(BungieLocales.EN)
                .OrderBy(x => x.StatId)
        )
        {
            var key = char.ToUpper(statsDefinition.StatId.First()) + statsDefinition.StatId[1..];
            if (key.Contains('_'))
            {
                var split = key.Split('_');
                key = string.Empty;
                for (var index = 0; index < split.Length; index++)
                {
                    var entry = split[index];
                    key += char.ToUpper(entry.First()) + entry[1..];
                }
            }

            await WriteCommentaryAsync(textWriter, indentation, statsDefinition.StatDescription);

            await textWriter.WriteLineAsync(
                StringExtensions.GetIndentedString(
                    indentation,
                    $"public const string {key} = \"{statsDefinition.StatId}\";"
                )
            );
        }
    }
}
