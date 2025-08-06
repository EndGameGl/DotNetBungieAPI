using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp;

public class CSharpMethodGroupGenerator : MethodGroupGeneratorBase
{
    public override string FileExtension => "cs";

    private const string NameSpace = "namespace DotNetBungieAPI.Generated.Methods;";

    private const string Indent = "    ";

    public override async Task GenerateMethodGroupAsync(string groupName, (string ApiPath, OpenApiPath ApiPathInfo)[] methods)
    {
        await WriteLineAsync("using DotNetBungieAPI.Generated.Models;");
        await WriteLineAsync();

        await WriteLineAsync(NameSpace);
        await WriteLineAsync();

        await WriteLineAsync($"public interface I{groupName}Api");
        await WriteLineAsync('{');

        foreach (var (path, methodData) in methods)
        {
            var (method, type) = methodData.GetMethod();

            var responseTypeReference = (OpenApiComponentReference)method.Responses["200"];
            var responseFullType = (OpenApiObjectComponentSchema)Spec.Components.Responses[responseTypeReference.GetReferencedPath()].Schema;

            await WriteAsync($"{Indent}Task<ApiResponse<{responseFullType.Properties["Response"].GetCSharpType("Models")}>> {method.OperationId.Split('.').Last()}");

            if (method is { Parameters: [] } and { RequestBody: null } and { Security: null or [] })
            {
                await WriteLineAsync("();");
            }
            else
            {
                await WriteLineAsync("(");

                var parameters = new List<string>();

                foreach (var pathParam in method.GetPathParameters())
                {
                    parameters.Add($"{Indent}{Indent}{pathParam.Schema.GetCSharpType("Models")} {pathParam.Name}");
                }

                foreach (var queryParam in method.GetQueryParameters())
                {
                    if (queryParam.Deprecated.HasValue && queryParam.Deprecated.Value)
                    {
                        continue;
                    }

                    parameters.Add($"{Indent}{Indent}{queryParam.Schema.GetCSharpType("Models")} {queryParam.Name}");
                }

                if (method.RequestBody is not null)
                {
                    parameters.Add($"{Indent}{Indent}{method.RequestBody.Content["application/json"].Schema.GetCSharpType("Models")} body");
                }

                if (method.Security is { Length: > 0 })
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
