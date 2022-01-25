using System.Collections.ObjectModel;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class EnumTypeData : TypeData
{
    public bool IsFlags { get; private set; }
    public string OfType { get; private set; }
    public ReadOnlyCollection<EnumValueData> Values { get; private set; }

    public EnumTypeData(string typeName, OpenApiComponentSchema openApiComponentSchema) :
        base(typeName, openApiComponentSchema)
    {
    }

    protected override void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema)
    {
        IsFlags = openApiComponentSchema.EnumIsBitmask;
        OfType = Resources.TypeMappings[openApiComponentSchema.Format];
        var enumValues = openApiComponentSchema
            .EnumValues
            .Select(x => new EnumValueData(x))
            .ToList();
        Values = new ReadOnlyCollection<EnumValueData>(enumValues);
    }

    public override async Task SerializeTypeDataToStream(StreamWriter streamWriter)
    {
        if (Description is not null)
        {
            await WriteComment(false, Description, streamWriter);
        }

        if (IsFlags)
        {
            await streamWriter.WriteLineAsync("[System.Flags]");
        }

        await streamWriter.WriteLineAsync($"public enum {TypeName} : {OfType}");
        await streamWriter.WriteLineAsync('{');

        var totalValues = Values.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var enumValueData = Values[i];
            if (enumValueData.Description is not null)
            {
                await WriteComment(true, enumValueData.Description, streamWriter);
            }

            await streamWriter.WriteLineAsync(
                $"{Indent}{enumValueData.Name} = {enumValueData.Value}{(i != amountCheckValue ? "," : string.Empty)}");
            if (i != amountCheckValue)
            {
                await streamWriter.WriteLineAsync();
            }
        }

        await streamWriter.WriteLineAsync('}');
    }
}