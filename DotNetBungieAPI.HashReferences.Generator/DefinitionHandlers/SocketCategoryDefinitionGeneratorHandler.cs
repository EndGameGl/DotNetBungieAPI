﻿using System.Text;
using DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers.Interfaces;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.HashReferences.Generator.DefinitionHandlers;

public class SocketCategoryDefinitionGeneratorHandler : BaseDefinitionHandler, IDefinitionHandler
{
    public string FileSubName => nameof(DestinySocketCategoryDefinition);

    public string ClassName => "SocketCategories";

    public async Task Generate(
        IBungieClient bungieClient,
        TextWriter textWriter,
        StringBuilder stringBuilder,
        int indentation
    )
    {
        var definitionCacheLookup = new Dictionary<string, uint>();

        foreach (
            var definition in bungieClient.Repository.GetAll<DestinySocketCategoryDefinition>()
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
                bungieClient.Repository.TryGetDestinyDefinition<DestinySocketCategoryDefinition>(
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
