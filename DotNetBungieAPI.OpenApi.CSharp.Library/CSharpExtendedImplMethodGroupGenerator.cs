using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Models;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp.Library;

public class CSharpExtendedImplMethodGroupGenerator : MethodGroupGeneratorBase
{
    private const string Indent = "    ";
    private const string NameSpace = "namespace DotNetBungieAPI.Services.ApiAccess;";

    public override string FileExtension => "cs";
    public override string Location => "MethodImpl";

    public override async Task GenerateMethodGroupAsync(string groupName, (string ApiPath, OpenApiPath ApiPathInfo)[] methods)
    {
        await WriteLineAsync(
            $$"""
            using System.IO;
            using System.Threading;
            using System.Threading.Tasks;
            using DotNetBungieAPI.Models;
            using DotNetBungieAPI.Models.Applications;
            using DotNetBungieAPI.Models.Authorization;
            using DotNetBungieAPI.Models.Exceptions;
            using DotNetBungieAPI.Service.Abstractions;
            using DotNetBungieAPI.Service.Abstractions.ApiAccess;

            {{NameSpace}}

            internal sealed class {{groupName}}Api : I{{groupName}}Api
            {
                private readonly IBungieClientConfiguration _configuration;
                private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
                private readonly IBungieNetJsonSerializer _serializer;

                public {{groupName}}Api(
                    IBungieClientConfiguration configuration,
                    IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
                    IBungieNetJsonSerializer serializer
                )
                {
                    _configuration = configuration;
                    _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
                    _serializer = serializer;
                }
            """
        );

        await WriteLineAsync();

        foreach (var (path, methodData) in methods)
        {
            var (method, type) = methodData.GetMethod();

            var responseTypeReference = (OpenApiComponentReference)method.Responses["200"];
            var responseFullType = (OpenApiObjectComponentSchema)Spec.Components.Responses[responseTypeReference.GetReferencedPath()].Schema;

            await WriteComment(true, methodData.Description);
            if (method.Parameters is { Length: > 0 })
            {
                foreach (var methodParameterInfo in method.Parameters)
                {
                    await WriteParameterComment(true, methodParameterInfo.Name, methodParameterInfo.Description);
                }
            }

            if (method.RequestBody is not null)
            {
                await WriteParameterComment(true, "requestBody", "Request body");
            }

            await WriteParameterComment(true, "authorizationToken", "Authorization information");

            await WriteParameterComment(true, "cancellationToken", "Method cancellation token");

            var responseCSharpType = responseFullType.Properties["Response"].GetCSharpType("Models");

            await WriteAsync($"{Indent}public async Task<BungieResponse<{responseCSharpType}>> {method.OperationId.Split('.').Last()}");

            if (method is { Parameters: [] } and { RequestBody: null } and { Security: null or [] })
            {
                await WriteLineAsync(
                    """
                    (AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default)
                    """
                );
                await WriteLineAsync($"{Indent}{{");

                await WriteMethodBody(path, type, responseCSharpType, method);

                await WriteLineAsync($"{Indent}}}");
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
                    parameters.Add($"{Indent}{Indent}{method.RequestBody.Content["application/json"].Schema.GetCSharpType("Models")} requestBody");
                }

                parameters.Add($"{Indent}{Indent}AuthorizationTokenData? authorizationToken = null");

                parameters.Add($"{Indent}{Indent}CancellationToken cancellationToken = default");

                await WriteLineAsync(string.Join(",\n", parameters));

                await WriteLineAsync($"{Indent})");

                await WriteLineAsync($"{Indent}{{");

                await WriteMethodBody(path, type, responseCSharpType, method);

                await WriteLineAsync($"{Indent}}}");
            }
            await WriteLineAsync();
        }

        await WriteLineAsync('}');
    }

    private async Task WriteMethodBody(string path, string httpMethod, string responseCSharpType, OpenApiPathMethodInfo methodInfo)
    {
        var methodPrefix = httpMethod == "GET" ? "GetFrom" : "PostTo";

        if (methodInfo.Security is { Length: > 0 })
        {
            foreach (var openApiPathMethodSecurity in methodInfo.Security)
            {
                foreach (var oauthScope in openApiPathMethodSecurity.Oauth2)
                {
                    await WriteLineAsync(
                        $"""
                        {Indent}{Indent}if (!_configuration.HasSufficientRights(ApplicationScopes.{oauthScope}))
                        {Indent}{Indent}    throw new InsufficientScopeException(ApplicationScopes.{oauthScope});
                        """
                    );
                    await WriteLineAsync();
                }
            }
        }

        var queryParameters = methodInfo.GetQueryParameters().ToArray();
        var pathParameters = methodInfo.GetPathParameters().ToArray();

        if (queryParameters is { Length: 0 } && pathParameters is { Length: 0 })
        {
            var hasRequestBody = await WriteRequestBodySerialization(methodInfo);

            await WriteLineAsync(
                $"""
                {Indent}{Indent}return await _dotNetBungieApiHttpClient.{methodPrefix}BungieNetPlatform<{responseCSharpType}>("{path}", cancellationToken{(
                    hasRequestBody ? ", stream" : string.Empty
                )}, authToken: authorizationToken?.AccessToken);
                """
            );
        }
        else
        {
            await WriteLineAsync(
                $"""
                {Indent}{Indent}var url = StringBuilderPool
                {Indent}{Indent}    .GetBuilder(cancellationToken)
                """
            );

            if (pathParameters is { Length: > 0 })
            {
                await WriteLineAsync(
                    $"""
                    {Indent}{Indent}    .Append($"{path}")
                    """
                );
            }

            if (queryParameters is { Length: > 0 })
            {
                foreach (var queryParameter in queryParameters)
                {
                    if (queryParameter.Schema is OpenApiEnumReferenceComponentSchema enumRefSchema)
                    {
                        await WriteLineAsync(
                            $"""
                            {Indent}{Indent}    .AddQueryParam("{queryParameter.Name}", ({Resources.TypeMappings[
                                enumRefSchema.Format ?? enumRefSchema.Type
                            ]}){queryParameter.Name})
                            """
                        );
                    }
                    else
                    {
                        await WriteLineAsync(
                            $"""
                            {Indent}{Indent}    .AddQueryParam("{queryParameter.Name}", {queryParameter.Name})
                            """
                        );
                    }
                }
            }

            await WriteLineAsync(
                $"""
                {Indent}{Indent}    .Build();
                """
            );

            var hasRequestBody = await WriteRequestBodySerialization(methodInfo);

            await WriteLineAsync(
                $"""
                 {Indent}{Indent}return await _dotNetBungieApiHttpClient.{methodPrefix}BungieNetPlatform<{responseCSharpType}>(url, cancellationToken{(
                    hasRequestBody ? ", content: stream" : string.Empty
                )}, authToken: authorizationToken?.AccessToken);
                 """
            );
        }
    }

    private async Task WriteComment(bool indent, string description)
    {
        await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <summary>");
        var entries = description.Split("\r\n");
        if (entries.Length == 1)
        {
            await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {description}");
        }
        else
        {
            for (var i = 0; i < entries.Length; i++)
            {
                var descLine = entries[i];
                if (i == entries.Length - 1)
                {
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                }
                else
                {
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <para />");
                }
            }
        }

        await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// </summary>");
    }

    private async Task WriteParameterComment(bool indent, string parameterName, string description)
    {
        await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <param name=\"{parameterName}\">{description}</param>");
    }

    private async Task<bool> WriteRequestBodySerialization(OpenApiPathMethodInfo methodInfo)
    {
        var hasRequestBody = false;

        if (methodInfo.RequestBody is not null)
        {
            hasRequestBody = true;

            await WriteLineAsync(
                $"""
                {Indent}{Indent}var stream = new MemoryStream();
                {Indent}{Indent}await _serializer.SerializeAsync(stream, requestBody);
                {Indent}{Indent}stream.Position = 0;
                """
            );
            await WriteLineAsync();
        }

        return hasRequestBody;
    }
}
