using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;
using DotNetBungieAPI.Service.Abstractions;
using System.Text;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

internal class LoadoutIconDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinyLoadoutIconDefinition);
    public string ClassName => "LoadoutIcons";

    public async Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation)
    {
        var definitionCacheLookup = new Dictionary<string, uint>();

        foreach (var definition in bungieClient.Repository.GetAll<DestinyLoadoutIconDefinition>())
        {
            definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);
        }

        foreach (var (key, value) in definitionCacheLookup)
        {
            await textWriter.WriteLineAsync(StringExtensions.GetIndentedString(
                indentation,
                $"public const uint {key} = {value};"));
        }
    }
}
