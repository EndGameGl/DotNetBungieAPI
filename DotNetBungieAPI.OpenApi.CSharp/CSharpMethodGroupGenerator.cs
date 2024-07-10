using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi.CSharp;

public class CSharpMethodGroupGenerator : MethodGroupGeneratorBase
{
    public override string FileExtension => "cs";

    private const string NameSpace = "namespace DotNetBungieAPI.Generated.Models;";

    private const string Indent = "    ";

    public override async Task GenerateMethodGroupAsync(string groupName, List<MethodData> methods)
    {
        await WriteLineAsync(NameSpace);
        await WriteLineAsync();

        await WriteLineAsync($"public interface I{groupName}Api");
        await WriteLineAsync('{');

        foreach (var method in methods)
        {
            var returnParam = method.Response.Properties.First(x =>
                x.OriginPropertyName == "Response"
            );

            await WriteAsync(
                $"{Indent}Task<ApiResponse<{returnParam.GetCSharpType()}>> {method.MethodName}"
            );

            if (
                method.PathParameters.Count is 0
                && method.QueryParameters.Count is 0
                && method.RequestBody is null
                && !method.RequiresToken
            )
            {
                await WriteLineAsync("();");
            }
            else
            {
                await WriteLineAsync("(");

                var parameters = new List<string>();

                foreach (var pathParam in method.PathParameters)
                {
                    parameters.Add(
                        $"{Indent}{Indent}{pathParam.Type.GetCSharpType()} {pathParam.Name}"
                    );
                }

                foreach (var queryParam in method.QueryParameters)
                {
                    parameters.Add(
                        $"{Indent}{Indent}{queryParam.Type.GetCSharpType()} {queryParam.Name}"
                    );
                }

                if (method.RequestBody is not null)
                {
                    var body = method.RequestBody;
                    if (method.RequestBodyIsPlain)
                    {
                        parameters.Add(
                            $"{Indent}{Indent}{body.Properties[0].GetCSharpType()} body"
                        );
                    }
                    else
                    {
                        parameters.Add(
                            $"{Indent}{Indent}{body.FullTypeName.GetCSharpPropertyName()} body"
                        );
                    }
                }

                if (method.RequiresToken)
                {
                    parameters.Add($"{Indent}{Indent}string authToken");
                }

                await WriteLineAsync(string.Join(",\n", parameters));

                await WriteLineAsync($"{Indent});");
            }
            await WriteLineAsync();
        }

        await WriteLineAsync('}');
    }
}
