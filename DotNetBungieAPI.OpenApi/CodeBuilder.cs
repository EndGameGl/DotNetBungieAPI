using System.Text;
using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Analysis;
using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi;

public class CodeBuilder
{
    private readonly string _destinationFolder;

    public CodeBuilder(string destinationFolder)
    {
        _destinationFolder = destinationFolder;
        if (!Directory.Exists(destinationFolder))
        {
            throw new Exception("Directory doesn't exist");
        }
    }

    public async Task BuildBareDefinitions(
        Models.OpenApi openApiModel,
        ModelGeneratorBase modelGenerator,
        MethodGroupGeneratorBase methodGroupGenerator,
        params AdditionalFileGenerator[] additionalFileGenerators
    )
    {
        var typeTree = new TypeTree();
        typeTree.CreateSchemasTypeTree(openApiModel);

        foreach (var additionalFileGenerator in additionalFileGenerators)
        {
            await using var streamWriter = new StreamWriter(
                Path.Combine(_destinationFolder, additionalFileGenerator.FileNameAndExtension),
                append: false
            );
            additionalFileGenerator.Writer = streamWriter;
            await additionalFileGenerator.WriteFile(openApiModel);
        }

        foreach (var treeNode in typeTree.Nodes.Values)
        {
            await IterateThroughTypeTreeBare(
                openApiModel,
                treeNode,
                _destinationFolder,
                modelGenerator
            );
        }

        await CreateApiInterfaces(openApiModel, methodGroupGenerator);

        foreach (var (responseName, openApiComponentResponse) in openApiModel.Components.Responses)
        {
            var schema = openApiComponentResponse.Content.Schema;
        }
    }

    private async Task IterateThroughTypeTreeBare(
        Models.OpenApi openApiModel,
        TreeNode treeNode,
        string previousPath,
        ModelGeneratorBase modelGenerator
    )
    {
        if (treeNode.IsFolder)
        {
            var currentFolder = Path.Combine(previousPath, treeNode.Name);
            Directory.CreateDirectory(currentFolder);
            foreach (var childNode in treeNode.Nodes.Values)
            {
                await IterateThroughTypeTreeBare(
                    openApiModel,
                    childNode,
                    currentFolder,
                    modelGenerator
                );
            }
        }

        if (treeNode.IsType)
        {
            var currentFile = Path.Combine(
                previousPath,
                $"{treeNode.Name}.{modelGenerator.FileExtension}"
            );
            var fullTypeName = currentFile
                .Replace(_destinationFolder, string.Empty)
                .Replace('\\', '.')[1..^3];

            var typeSchema = openApiModel.Components.Schemas[fullTypeName];

            if (typeSchema.Type is "array")
                return;

            //if (typeSchema.Type is "object" && (typeSchema.Properties is null || !typeSchema.Properties.Any()))
            //    return;

            try
            {
                var typeData = TypeData.CreateTypeData(fullTypeName, typeSchema);
                await using var streamWriter = new StreamWriter(currentFile, append: false);
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

    private async Task CreateApiInterfaces(
        Models.OpenApi openApiModel,
        MethodGroupGeneratorBase methodGroupGenerator
    )
    {
        var methods = openApiModel
            .Paths.Select(x => new MethodData(x.Key, x.Value, openApiModel))
            .ToList();

        var groups = methods.GroupBy(x => x.MethodGroup).ToDictionary(x => x.Key, x => x.ToList());

        foreach (var (groupName, groupMethods) in groups)
        {
            var fixedGroupName = string.IsNullOrWhiteSpace(groupName) ? "Misc" : groupName;
            var fileName = Path.Combine(
                _destinationFolder,
                $"{fixedGroupName}.ApiMethods.{methodGroupGenerator.FileExtension}"
            );
            await using var streamWriter = new StreamWriter(fileName, append: false);
            methodGroupGenerator.Writer = streamWriter;

            await methodGroupGenerator.GenerateMethodGroupAsync(fixedGroupName, groupMethods);
        }
    }
}
