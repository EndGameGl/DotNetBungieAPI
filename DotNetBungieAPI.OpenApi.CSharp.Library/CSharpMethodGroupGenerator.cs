using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public class CSharpMethodGroupGenerator : MethodGroupGeneratorBase
{
    public override string FileExtension => "cs";
    public override Task GenerateMethodGroupAsync(string groupName, (string ApiPath, OpenApiPath ApiPathInfo)[] methods)
    {
        throw new NotImplementedException();
    }
}