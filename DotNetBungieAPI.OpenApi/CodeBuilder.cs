using System.Text;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Analysis;
using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi;

public class CodeBuilder
{
    private const string GlobalUsingsText = @"
global using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;
";

    private const string NameSpace = "namespace DotNetBungieAPI.Generated.Models;";
    private const string NamespaceBase = "namespace DotNetBungieAPI.Generated.Models";
    
    private readonly string _destinationFolder;

    public CodeBuilder(string destinationFolder)
    {
        _destinationFolder = destinationFolder;
        if (!Directory.Exists(destinationFolder))
        {
            throw new Exception("Directory doesn't exist");
        }
    }

    public async Task BuildBareDefinitions(Models.OpenApi openApiModel, ModelGeneratorBase modelGenerator)
    {
        var typeTree = new TypeTree();
        typeTree.CreateSchemasTypeTree(openApiModel);

        await using (var streamWriter = new StreamWriter(Path.Combine(
                         _destinationFolder,
                         "GlobalUsings.cs"), append: false))
        {
            await streamWriter.WriteAsync(GlobalUsingsText);
        }
        
        await using (var streamWriter = new StreamWriter(Path.Combine(
                         _destinationFolder,
                         "DotNetBungieAPIJsonSerializationContext.cs"), append: false))
        {
            await streamWriter.WriteLineAsync("namespace DotNetBungieAPI.Generated.Models;");
            await streamWriter.WriteLineAsync();
            
            foreach (var (typeName, typeSchema) in openApiModel.Components.Schemas)
            {
                if (typeSchema.Type is "object" && (typeSchema.Properties is null || !typeSchema.Properties.Any()))
                    continue;
                await streamWriter.WriteLineAsync($"[JsonSerializable(typeof({typeName}))]");
            }
            
            await streamWriter.WriteLineAsync("public partial class DotNetBungieAPIJsonSerializationContext : JsonSerializerContext { }");
        }
        
        foreach (var treeNode in typeTree.Nodes.Values)
        {
            await IterateThroughTypeTreeBare(openApiModel, treeNode, _destinationFolder, modelGenerator);
        }

        foreach (var (responseName, openApiComponentResponse) in openApiModel.Components.Responses)
        {
            var schema = openApiComponentResponse.Content.Schema;
        }
    }

    private async Task IterateThroughTypeTreeBare(
        Models.OpenApi openApiModel,
        TreeNode treeNode,
        string previousPath,
        ModelGeneratorBase modelGenerator)
    {
        if (treeNode.IsFolder)
        {
            var currentFolder = Path.Combine(previousPath, treeNode.Name);
            Directory.CreateDirectory(currentFolder);
            foreach (var childNode in treeNode.Nodes.Values)
            {
                await IterateThroughTypeTreeBare(openApiModel, childNode, currentFolder, modelGenerator);
            }
        }

        if (treeNode.IsType)
        {
            var currentFile = Path.Combine(previousPath, $"{treeNode.Name}.{modelGenerator.FileExtension}");
            var fullTypeName = currentFile
                .Replace(
                    _destinationFolder,
                    string.Empty)
                .Replace(
                    '\\',
                    '.')
                [1..^3];

            var typeSchema = openApiModel.Components.Schemas[fullTypeName];

            if (typeSchema.Type is "array")
                return;
            
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
            
            try
            {
                var typeData = TypeData.CreateTypeData(fullTypeName, typeSchema);
                modelGenerator.Writer = streamWriter;
                switch (typeData)
                {
                    case ObjectTypeData objectTypeData:
                        await modelGenerator.GenerateDataForObjectType(objectTypeData);
                        break;
                    case EnumTypeData enumTypeData:
                        await modelGenerator.GenerateDataForEnumType(enumTypeData);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}