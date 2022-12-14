using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions.MedalTiers;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

public class MedalTierDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinyMedalTierDefinition);

    public string ClassName => "MedalTiers";

    public async Task Generate(IBungieClient bungieClient, TextWriter textWriter, StringBuilder stringBuilder, int indentation)
    {
        foreach (var definition in bungieClient.Repository.GetAll<DestinyMedalTierDefinition>())
            await textWriter.WriteLineAsync(StringExtensions.GetIndentedString(
                indentation,
                $"public const uint {definition.TierName.Replace(" ", "")} = {definition.Hash};"));
    }
}