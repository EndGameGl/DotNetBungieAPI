using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class MethodData
{
    public string Path { get; }

    public string Method { get; }

    public string MethodGroup { get; }

    public string MethodName { get; }

    public bool RequiresToken { get; }

    public string Description { get; }

    public ObjectTypeData Response { get; }

    public List<MethodParameterData> QueryParameters { get; }

    public List<MethodParameterData> PathParameters { get; }

    public ObjectTypeData? RequestBody { get; }
    public bool RequestBodyIsPlain { get; }

    public MethodData(
        string template,
        OpenApiPath openApiPath,
        Models.OpenApi openApi)
    {
        Path = template;
        OpenApiPathMethodInfo? method = null;
        if (openApiPath.Get is not null)
        {
            Method = "GET";
            method = openApiPath.Get;
        }
        else if (openApiPath.Post is not null)
        {
            Method = "POST";
            method = openApiPath.Post;
        }

        var operationIds = method!.OperationId.Split(".");
        MethodGroup = operationIds[0];
        MethodName = operationIds[1];
        RequiresToken = method.Security?.Count > 0;
        Description = method.Description;

        var responseTypeReference = method.Responses["200"].TypeReference.GetFullTypeName();
        var response = openApi.Components.Responses[responseTypeReference];
        Response = (ObjectTypeData)TypeData.CreateTypeData(responseTypeReference, response.Content.Schema);

        PathParameters = new List<MethodParameterData>();
        foreach (var parameter in method.Parameters.Where(x => x.In == "path"))
        {
            var paramMetadata = new MethodParameterData()
            {
                Name = parameter.Name,
                Description = parameter.Description,
                Type = new PropertyTypeData(parameter.Name, parameter.Schema)
            };
            PathParameters.Add(paramMetadata);
        }

        QueryParameters = new List<MethodParameterData>();
        foreach (var parameter in method.Parameters.Where(x => x.In == "query"))
        {
            var paramMetadata = new MethodParameterData()
            {
                Name = parameter.Name,
                Description = parameter.Description,
                Type = new PropertyTypeData(parameter.Name, parameter.Schema)
            };
            QueryParameters.Add(paramMetadata);
        }

        if (Method == "POST" && method.RequestBody is not null && method.RequestBody.Content.TryGetValue("application/json", out var bodyTypeRef))
        {
            if (bodyTypeRef.Schema.Type is "array")
            {
                RequestBody = new ObjectTypeData("", new OpenApiComponentSchema()
                {
                    Properties = new Dictionary<string, OpenApiComponentSchema>() { { "", bodyTypeRef.Schema } }
                });
                RequestBodyIsPlain = true;
            }
            else
            {
                var typeRef = bodyTypeRef.Schema.TypeReference.GetFullTypeName();
                var body = openApi.Components.Schemas[typeRef];
                RequestBody = (ObjectTypeData)TypeData.CreateTypeData(typeRef, body);
            }
        }
    }
}
