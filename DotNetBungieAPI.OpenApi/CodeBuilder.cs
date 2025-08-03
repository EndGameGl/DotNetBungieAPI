using System.Net.Http.Json;
using System.Text.Json;
using DotNetBungieAPI.OpenApi.Analysis;
using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Serialization;

namespace DotNetBungieAPI.OpenApi;

public class CodeBuilder
{
    private const string OpenApiSpecLink =
        "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json";

    private readonly string _destinationFolder;

    private Models.OpenApi _spec = null!;

    public CodeBuilder(string destinationFolder)
    {
        _destinationFolder = destinationFolder;
        if (!Directory.Exists(destinationFolder))
        {
            throw new Exception("Directory doesn't exist");
        }
    }

    public async Task<bool> LoadSpecAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            _spec = await httpClient.GetFromJsonAsync<Models.OpenApi>(
                OpenApiSpecLink,
                new JsonSerializerOptions()
                {
                    Converters = { new IOpenApiComponentSchemaSerializer() }
                }
            );

            ArgumentNullException.ThrowIfNull(_spec);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task BuildDefinitions(
        ModelGeneratorBase modelGenerator,
        MethodGroupGeneratorBase? methodGroupGenerator,
        params AdditionalFileGenerator[] additionalFileGenerators
    )
    {
        modelGenerator.Spec = _spec;
        if (methodGroupGenerator is not null)
        {
            methodGroupGenerator.Spec = _spec;
        }

        var typeTree = new TypeTree();
        typeTree.CreateSchemasTypeTree(_spec);

        foreach (var additionalFileGenerator in additionalFileGenerators)
        {
            var filePath = Path.Combine(_destinationFolder, additionalFileGenerator.Location);
            Directory.CreateDirectory(filePath);
            await using var streamWriter = new StreamWriter(
                Path.Combine(filePath, additionalFileGenerator.FileNameAndExtension),
                append: false
            );
            additionalFileGenerator.Writer = streamWriter;
            await additionalFileGenerator.WriteFile(_spec);
        }

        Directory.CreateDirectory(Path.Combine(_destinationFolder, "Models"));
        foreach (var treeNode in typeTree.Nodes.Values)
        {
            await IterateThroughTypeTreeBare(
                _spec,
                treeNode,
                Path.Combine(_destinationFolder, "Models"),
                Path.Combine(_destinationFolder, "Models"),
                modelGenerator
            );
        }

        Directory.CreateDirectory(Path.Combine(_destinationFolder, "Methods"));
        if (methodGroupGenerator is not null)
        {
            await CreateApiInterfaces(_spec, methodGroupGenerator, Path.Combine(_destinationFolder, "Methods"));
        }
    }

    private async Task IterateThroughTypeTreeBare(
        Models.OpenApi openApiModel,
        TreeNode treeNode,
        string initialDirectory,
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
                    initialDirectory,
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
                .Replace(initialDirectory, string.Empty)
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
        MethodGroupGeneratorBase methodGroupGenerator,
        string path
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
                path,
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
