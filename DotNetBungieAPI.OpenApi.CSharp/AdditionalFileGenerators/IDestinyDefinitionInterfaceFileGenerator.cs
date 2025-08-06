using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.AdditionalFileGenerators;

public class IDestinyDefinitionInterfaceFileGenerator : AdditionalFileGenerator
{
    private const string Code = """
        namespace DotNetBungieAPI.Generated.Models;

        public interface IDestinyDefinition
        {
            /// <summary>
            ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
            /// <para />
            ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
            /// </summary>
            uint Hash { get; set; }

            /// <summary>
            ///     The index of the entity as it was found in the investment tables.
            /// </summary>
            int Index { get; set; }

            /// <summary>
            ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
            /// </summary>
            bool Redacted { get; set; }
        }
        """;

    public override string FileNameAndExtension => "IDestinyDefinitions.cs";
    public override string Location => "Models";

    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(Code);
    }
}
