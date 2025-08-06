using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models.Destiny.Definitions.Social;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers
{
    internal class SocialCommendationDefinitionGeneratorHandler
        : BaseDefinitionHandler,
            IDefinitionHandler
    {
        public string FileSubName => nameof(DestinySocialCommendationDefinition);
        public string ClassName => "SocialCommendations";

        public async Task Generate(
            IBungieClient bungieClient,
            TextWriter textWriter,
            StringBuilder stringBuilder,
            int indentation
        )
        {
            var definitionCacheLookup = new Dictionary<string, uint>();

            foreach (
                var definition in bungieClient.Repository.GetAll<DestinySocialCommendationDefinition>()
            )
            {
                if (definition.DisplayProperties is not null)
                {
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.DisplayProperties.Name,
                        definition.Hash
                    );
                }
                else
                {
                    definitionCacheLookup.Add($"H{definition.Hash.ToString()}", definition.Hash);
                }
            }

            foreach (var (key, value) in definitionCacheLookup)
            {
                if (
                    bungieClient.Repository.TryGetDestinyDefinition<DestinySocialCommendationDefinition>(
                        value,
                        out var definition
                    )
                )
                {
                    await WriteCommentaryAsync(
                        textWriter,
                        indentation,
                        definition.DisplayProperties?.Description
                    );
                }

                if (
                    definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1
                    && !key.Contains(value.ToString())
                )
                {
                    await textWriter.WriteLineAsync(
                        StringExtensions.GetIndentedString(
                            indentation,
                            $"public const uint {key}_{value} = {value};"
                        )
                    );
                }
                else
                {
                    await textWriter.WriteLineAsync(
                        StringExtensions.GetIndentedString(
                            indentation,
                            $"public const uint {key} = {value};"
                        )
                    );
                }
            }
        }
    }
}
