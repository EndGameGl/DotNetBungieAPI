using DotNetBungieAPI.OpenApi.CodeGeneration;

namespace DotNetBungieAPI.OpenApi.CSharp.Library.AdditionalFileGenerators;

public class IDisplayPropertiesFileGenerator : AdditionalFileGenerator
{
    private const string Content = 
        """
        using DotNetBungieAPI.Models.Destiny.Definitions.Common;
        
        namespace DotNetBungieAPI.Models;
        
        public interface IDisplayProperties 
        {
            DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        }
        """;
    
    public override string FileNameAndExtension => "IDisplayProperties.cs";
    public override string Location => "Models";
    public override async Task WriteFile(Models.OpenApi openApiModel)
    {
        await WriteAsync(Content);
    }
}