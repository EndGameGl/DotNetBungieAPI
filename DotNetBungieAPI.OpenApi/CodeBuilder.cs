using System.Text;
using DotNetBungieAPI.OpenApi.Analysis;
using DotNetBungieAPI.OpenApi.Extensions;

namespace DotNetBungieAPI.OpenApi;

public class CodeBuilder
{
    private const string GlobalUsingsText = @"
global using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;
";

    private const string NameSpace = "namespace DotNetBungieAPI.Generated.Models;";
    private const string NamespaceBase = "namespace DotNetBungieAPI.Generated.Models";
    private const string ClassDeclaration = "public sealed class";
    private const string EnumDeclaration = "public enum";

    private const char OpenCurlyBrackets = '{';
    private const char CloseCurlyBrackets = '}';

    private readonly string _indent = new(' ', 4);
    private readonly string _destinationFolder;

    public CodeBuilder(string destinationFolder)
    {
        _destinationFolder = destinationFolder;
        if (!Directory.Exists(destinationFolder))
        {
            throw new Exception("Directory doesn't exist");
        }
    }

    public async Task BuildBareDefinitions(Models.OpenApi openApiModel)
    {
        var typeTree = new TypeTree();
        typeTree.CreateTypeTree(openApiModel);

        await using (var streamWriter = new StreamWriter(Path.Combine(
                         _destinationFolder,
                         "GlobalUsings.cs"), append: false))
        {
            await streamWriter.WriteAsync(GlobalUsingsText);
        }


        foreach (var treeNode in typeTree.Nodes.Values)
        {
            await IterateThroughTypeTreeBare(openApiModel, treeNode, _destinationFolder);
        }
    }

    private async Task IterateThroughTypeTreeBare(
        Models.OpenApi openApiModel,
        TreeNode treeNode,
        string previousPath)
    {
        if (treeNode.IsFolder)
        {
            var currentFolder = Path.Combine(previousPath, treeNode.Name);
            Directory.CreateDirectory(currentFolder);
            foreach (var childNode in treeNode.Nodes.Values)
            {
                await IterateThroughTypeTreeBare(openApiModel, childNode, currentFolder);
            }
        }

        if (treeNode.IsType)
        {
            var currentFile = Path.Combine(previousPath, $"{treeNode.Name}.cs");
            var fullTypeName = currentFile
                .Replace(
                    _destinationFolder,
                    string.Empty)
                .Replace(
                    '\\',
                    '.')
                [1..^3];

            var typeSchema = openApiModel.Components.Schemas[fullTypeName];

            if (typeSchema.Type is "object" && (typeSchema.Properties is null || !typeSchema.Properties.Any()))
                return;

            await using var streamWriter = new StreamWriter(currentFile, append: false);

            if (fullTypeName.Any(x => x == '.'))
            {
                var pathData = fullTypeName.Split('.')[0..^1];
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(NamespaceBase);
                foreach (var pathDataEntry in pathData)
                {
                    stringBuilder.Append($".{pathDataEntry}");
                }

                stringBuilder.Append(';');
                await streamWriter.WriteLineAsync(stringBuilder.ToString());
            }
            else
            {
                await streamWriter.WriteLineAsync(NameSpace);
            }

            await streamWriter.WriteLineAsync();

            await WriteComment(false, typeSchema.Description, streamWriter);

            switch (typeSchema)
            {
                case { Type: "object" }:
                    await streamWriter.WriteLineAsync($"{ClassDeclaration} {fullTypeName.GetTypeName()}");
                    await streamWriter.WriteLineAsync(OpenCurlyBrackets);
                    if (typeSchema.Properties is not null)
                    {
                        foreach (var (propertyName, propertyDefinition) in typeSchema.Properties)
                        {
                            await streamWriter.WriteLineAsync();
                            await WriteComment(true, propertyDefinition.Description, streamWriter);
                            await streamWriter.WriteLineAsync($"{_indent}[JsonPropertyName(\"{propertyName}\")]");
                            await streamWriter.WriteAsync(
                                $"{_indent}public {propertyDefinition.GetCSharpType()} {char.ToUpper(propertyName[0])}{propertyName[1..]} {{ get; init; }}");
                            if (propertyDefinition.MappedDefinition is not null)
                            {
                                await streamWriter.WriteAsync(
                                    $" // {propertyDefinition.MappedDefinition.TypeReference.GetTypeName()}");
                            }

                            await streamWriter.WriteLineAsync();
                        }
                    }

                    await streamWriter.WriteLineAsync(CloseCurlyBrackets);
                    break;
                case { Enum: not null }:
                    if (typeSchema.EnumIsBitmask)
                        await streamWriter.WriteLineAsync("[System.Flags]");
                    await streamWriter.WriteLineAsync(
                        $"{EnumDeclaration} {fullTypeName.GetTypeName()} : {Resources.TypeMappings[typeSchema.Format]}");
                    await streamWriter.WriteLineAsync(OpenCurlyBrackets);
                    var total = typeSchema.EnumValues.Count;
                    var beforeTotal = total - 1;
                    for (int i = 0; i < total; i++)
                    {
                        var current = typeSchema.EnumValues[i];
                        if (i == beforeTotal)
                        {
                            await WriteComment(true, current.Description, streamWriter);
                            await streamWriter.WriteLineAsync(
                                $"{_indent}{current.Identifier} = {current.NumericValue}");
                        }
                        else
                        {
                            await WriteComment(true, current.Description, streamWriter);
                            await streamWriter.WriteLineAsync(
                                $"{_indent}{current.Identifier} = {current.NumericValue},");
                        }
                    }

                    await streamWriter.WriteLineAsync(CloseCurlyBrackets);
                    break;
            }
        }
    }

    private async Task WriteComment(bool indent, string text, StreamWriter streamWriter)
    {
        if (!string.IsNullOrEmpty(text))
        {
            await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}/// <summary>");
            var entries = text.Split('\n');
            if (entries.Length == 1)
            {
                await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}///     {text}");
            }
            else
            {
                for (int i = 0; i < entries.Length; i++)
                {
                    var descLine = entries[i];
                    if (i == entries.Length - 1)
                    {
                        await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}///     {descLine}");
                    }
                    else
                    {
                        await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}///     {descLine}");
                        await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}/// <para />");
                    }
                }
            }

            await streamWriter.WriteLineAsync($"{(indent ? _indent : string.Empty)}/// </summary>");
        }
    }
}