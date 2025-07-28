using DotNetBungieAPI.OpenApi.Analysis;
using DotNetBungieAPI.OpenApi.CodeGeneration;

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
        MethodGroupGeneratorBase? methodGroupGenerator,
        params AdditionalFileGenerator[] additionalFileGenerators
    )
    {
        modelGenerator.Spec = openApiModel;
        if (methodGroupGenerator is not null)
        {
            methodGroupGenerator.Spec = openApiModel;
        }

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

        if (methodGroupGenerator is not null)
        {
            await CreateApiInterfaces(openApiModel, methodGroupGenerator);
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

            try
            {
                if (modelGenerator.CanHandle(typeSchema))
                {
                    await using var streamWriter = new StreamWriter(currentFile, append: false);
                    modelGenerator.Writer = streamWriter;
                    await modelGenerator.GenerateFromSchema(fullTypeName, typeSchema);
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
        var groups = openApiModel
            .Paths.GroupBy(x =>
            {
                if (x.Value.Get is not null)
                {
                    return x.Value.Get.OperationId.Split('.')[0];
                }

                if (x.Value.Post is not null)
                {
                    return x.Value.Post.OperationId.Split('.')[0];
                }

                return string.Empty;
            })
            .ToDictionary(x => x.Key, x => x);

        foreach (var (groupName, groupMethods) in groups)
        {
            var fixedGroupName = string.IsNullOrWhiteSpace(groupName) ? "Misc" : groupName;
            var fileName = Path.Combine(
                _destinationFolder,
                $"{fixedGroupName}.ApiMethods.{methodGroupGenerator.FileExtension}"
            );
            await using var streamWriter = new StreamWriter(fileName, append: false);
            methodGroupGenerator.Writer = streamWriter;

            await methodGroupGenerator.GenerateMethodGroupAsync(
                fixedGroupName,
                groupMethods.Select(x => (x.Key, x.Value)).ToArray()
            );
        }
    }
}
