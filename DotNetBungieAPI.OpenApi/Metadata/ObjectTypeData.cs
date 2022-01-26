using System.Collections.ObjectModel;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class ObjectTypeData : TypeData
{
    public ReadOnlyCollection<PropertyTypeData> Properties { get; private set; }

    public ObjectTypeData(string typeName, OpenApiComponentSchema openApiComponentSchema) :
        base(typeName, openApiComponentSchema)
    {
    }

    protected override void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema)
    {
        var properties = openApiComponentSchema
            .Properties
            .Select(x => new PropertyTypeData(x.Key, x.Value))
            .ToList();
        Properties = new ReadOnlyCollection<PropertyTypeData>(properties);
    }

    public override async Task SerializeTypeDataToStream(StreamWriter streamWriter)
    {
        if (Description is not null)
        {
            await WriteComment(false, Description, streamWriter);
        }

        await streamWriter.WriteLineAsync($"public class {TypeName} : IDeepEquatable<{TypeName}>");
        await streamWriter.WriteLineAsync('{');

        var totalValues = Properties.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = Properties[i];
            if (propertyTypeData.Description is not null)
            {
                await WriteComment(true, propertyTypeData.Description, streamWriter);
            }

            await streamWriter.WriteLineAsync($"{Indent}[JsonPropertyName(\"{propertyTypeData.OriginPropertyName}\")]");
            await streamWriter.WriteLineAsync(
                $"{Indent}public {propertyTypeData.CSharpPropertyTypeName} {propertyTypeData.CSharpPropertyName} {{ get; set; }}");
            if (i != amountCheckValue)
            {
                await streamWriter.WriteLineAsync();
            }
        }

        await streamWriter.WriteLineAsync();

        await WriteDeepEqualsMethod(streamWriter);

        await streamWriter.WriteAsync('}');
    }

    private async Task WriteDeepEqualsMethod(StreamWriter streamWriter)
    {
        await streamWriter.WriteLineAsync($"{Indent}public bool DeepEquals({TypeName}? other)");
        await streamWriter.WriteLineAsync($"{Indent}{{");

        await streamWriter.WriteLineAsync($"{Indent}{Indent}return other is not null &&");

        var totalValues = Properties.Count;
        var amountCheckValue = totalValues - 1;

        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = Properties[i];
            if (propertyTypeData.IsValueType)
            {
                await streamWriter.WriteLineAsync(
                    $"{Indent}{Indent}{Indent}   {propertyTypeData.CSharpPropertyName} == other.{propertyTypeData.CSharpPropertyName}{(i != amountCheckValue ? " &&" : ";")}");
            }

            if (propertyTypeData.IsClassObject)
            {
                await streamWriter.WriteLineAsync(
                    $"{Indent}{Indent}{Indent}   ({propertyTypeData.CSharpPropertyName} is not null ? {propertyTypeData.CSharpPropertyName}.DeepEquals(other.{propertyTypeData.CSharpPropertyName}) : other.{propertyTypeData.CSharpPropertyName} is null){(i != amountCheckValue ? " &&" : ";")}");
            }

            if (propertyTypeData.IsCollection)
            {
                if (propertyTypeData.GenericProperties[0].IsValueType)
                {
                    await streamWriter.WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyTypeData.CSharpPropertyName}.DeepEqualsListNaive(other.{propertyTypeData.CSharpPropertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
                else
                {
                    await streamWriter.WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyTypeData.CSharpPropertyName}.DeepEqualsList(other.{propertyTypeData.CSharpPropertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
            }

            if (propertyTypeData.IsDictionary)
            {
                if (propertyTypeData.GenericProperties[1].IsClassObject)
                {
                    await streamWriter.WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyTypeData.CSharpPropertyName}.DeepEqualsDictionary(other.{propertyTypeData.CSharpPropertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
                else
                {
                    await streamWriter.WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyTypeData.CSharpPropertyName}.DeepEqualsDictionaryNaive(other.{propertyTypeData.CSharpPropertyName}){(i != amountCheckValue ? " &&" : ";")}");

                }
            }
        }

        await streamWriter.WriteLineAsync($"{Indent}}}");
    }
}