using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class DefinitionsEnumFileGenerator : AdditionalFileGenerator
{
    public override string FileNameAndExtension => "DefinitionsEnum.cs";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteLineAsync("namespace DotNetBungieAPI.Models;");

        await WriteLineAsync();

        await WriteLineAsync("public enum DefinitionsEnum");

        await WriteLineAsync('{');

        var definitions = openApiModel
            .Components.Schemas.Where(x =>
            {
                if (x.Value is OpenApiObjectComponentSchema { MobileManifestName: not null })
                {
                    return true;
                }

                return false;
            })
            .Select(x => x.Key.Split('.').Last())
            .Distinct()
            .Order()
            .ToArray();

        await WriteAsync("    ");
        await WriteLineAsync(string.Join(",\n    ", definitions));

        await WriteAsync('}');
    }
}
