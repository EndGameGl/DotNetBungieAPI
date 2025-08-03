using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class DefinitionsEnumExtensionsFileGenerator : AdditionalFileGenerator
{
    private const string Indent = "    ";

    public override string FileNameAndExtension => "DefinitionsEnumExtensions.cs";
    public override string Location => "Models\\Extensions";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteLineAsync(
            """
            using DotNetBungieAPI.Models.Destiny;

            namespace DotNetBungieAPI.Models.Extensions;

            /// <summary>
            ///     Extension class for <see cref="DefinitionsEnum"/>
            /// </summary>

            public static class DefinitionsEnumExtensions
            {
                /// <summary>
                ///     Direct string naming mapping for all enum values
                /// </summary>
                /// <param name="definitionsEnum"></param>
                /// <returns></returns>
                /// <exception cref="ArgumentOutOfRangeException"></exception>
                public static string ToStringFast(this DefinitionsEnum definitionsEnum) =>
                    definitionsEnum switch
                    {
            """
        );

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

        await WriteAsync($"{Indent}{Indent}{Indent}");
        await WriteLineAsync(
            string.Join(
                $"\n{Indent}{Indent}{Indent}",
                definitions.Select(x => $"DefinitionsEnum.{x} => nameof(DefinitionsEnum.{x}),")
            )
        );
        await WriteLineAsync($"{Indent}{Indent}{Indent}_ => throw new ArgumentOutOfRangeException(nameof(definitionsEnum), definitionsEnum, null)");

        await WriteLineAsync($"{Indent}{Indent}}};");
        await WriteLineAsync('}');
    }
}
