using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

public class VendorGroupDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinyVendorGroupDefinition);

    public string ClassName => "VendorGroups";

    public async Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation
    )
    {
        var definitionCacheLookup = new Dictionary<string, uint>();

        foreach (var definition in bungieClient.Repository.GetAll<DestinyVendorGroupDefinition>())
            ValidateAndAddValue(definitionCacheLookup, definition.CategoryName, definition.Hash);

        foreach (var (key, value) in definitionCacheLookup)
            if (
                definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1
                && !key.Contains(value.ToString())
            )
                await textWriter.WriteLineAsync(
                    StringExtensions.GetIndentedString(
                        indentation,
                        $"public const uint {key}_{value} = {value};"
                    )
                );
            else
                await textWriter.WriteLineAsync(
                    StringExtensions.GetIndentedString(
                        indentation,
                        $"public const uint {key} = {value};"
                    )
                );
    }
}
