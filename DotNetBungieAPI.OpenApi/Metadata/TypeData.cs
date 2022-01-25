using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public abstract class TypeData
{
    protected const string Indent = "    ";
    
    public string TypeName { get; }
    public string Description { get; }

    public TypeData(string typeName, OpenApiComponentSchema openApiComponentSchema)
    {
        TypeName = typeName.GetTypeName();
        Description = openApiComponentSchema.Description;
        AnalyzeSchema(openApiComponentSchema);
    }

    protected abstract void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema);

    public abstract Task SerializeTypeDataToStream(StreamWriter streamWriter);

    public static TypeData CreateTypeData(
        string typeName,
        OpenApiComponentSchema openApiComponentSchema)
    {
        switch (openApiComponentSchema)
        {
            case { Enum: not null }:
                return new EnumTypeData(typeName, openApiComponentSchema);
            case { Type: "object" }:
                return new ObjectTypeData(typeName, openApiComponentSchema);
            default:
                throw new Exception("Type conversion not supported");
        }
    }

    protected static async Task WriteComment(bool indent, string text, StreamWriter streamWriter)
    {
        await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <summary>");
        var entries = text.Split("\r\n");
        if (entries.Length == 1)
        {
            await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {text}");
        }
        else
        {
            for (var i = 0; i < entries.Length; i++)
            {
                var descLine = entries[i];
                if (i == entries.Length - 1)
                {
                    await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                }
                else
                {
                    await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                    await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <para />");
                }
            }
        }

        await streamWriter.WriteLineAsync($"{(indent ? Indent : string.Empty)}/// </summary>");
    }
}