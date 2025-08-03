using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class DefinitionsEnumFileGenerator : AdditionalFileGenerator
{
    public override string FileNameAndExtension => "DefinitionsEnum.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteLineAsync("namespace DotNetBungieAPI.Models;");

        await WriteLineAsync();

        await WriteLineAsync("public enum DefinitionsEnum");

        await WriteLineAsync('{');

        var definitions = openApiModel
            .Components.Schemas.Values.OfType<OpenApiObjectComponentSchema>()
            .SelectMany(x => x.Properties.Values)
            .OfType<IMappedDefinition>()
            .Where(x => x.MappedDefinition is not null)
            .Select(x => x.MappedDefinition!.GetReferencedPath())
            .Distinct()
            .Select(x => x.Split('.').Last())
            .Order()
            .ToArray();

        await WriteAsync("    ");
        await WriteLineAsync(string.Join(",\n    ", definitions));

        await WriteAsync('}');
    }
}
