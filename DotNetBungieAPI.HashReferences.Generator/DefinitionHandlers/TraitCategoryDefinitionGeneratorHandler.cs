using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions.TraitCategories;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

//public class TraitCategoryDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
//{
//    public string FileSubName => nameof(DestinyTraitCategoryDefinition);

//    public string ClassName => "TraitCategories";

//    public async Task Generate(IBungieClient bungieClient, TextWriter textWriter, StringBuilder stringBuilder,
//        int indentation)
//    {
//        foreach (var definition in bungieClient.Repository.GetAll<DestinyTraitCategoryDefinition>())
//        {
//            var key = char.ToUpper(definition.TraitCategoryId.First()) + definition.TraitCategoryId[1..];
//            if (key.Contains('_'))
//            {
//                var split = key.Split('_');
//                key = string.Empty;
//                for (var index = 0; index < split.Length; index++)
//                {
//                    var entry = split[index];
//                    key += char.ToUpper(entry.First()) + entry[1..];
//                }
//            }

//            await textWriter.WriteLineAsync(StringExtensions.GetIndentedString(
//                indentation,
//                $"public const uint {key} = {definition.Hash};"));
//        }
//    }
//}