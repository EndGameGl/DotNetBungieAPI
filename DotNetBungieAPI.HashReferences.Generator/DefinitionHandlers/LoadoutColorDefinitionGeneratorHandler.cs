using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;
using DotNetBungieAPI.Service.Abstractions;
using System.Text;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

internal class LoadoutColorDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinyLoadoutColorDefinition);
    public string ClassName => "LoadoutColors";

    public async Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation)
    {
        var definitionCacheLookup = new Dictionary<string, uint>();

        foreach (var definition in bungieClient.Repository.GetAll<DestinyLoadoutColorDefinition>())
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
