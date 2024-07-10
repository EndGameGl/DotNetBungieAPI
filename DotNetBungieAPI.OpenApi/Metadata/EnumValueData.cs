using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class EnumValueData
{
    public string Name { get; }
    public string Description { get; }
    public string Value { get; }

    public EnumValueData(EnumValue enumValue)
    {
        Name = enumValue.Identifier;
        Description = enumValue.Description;
        Value = enumValue.NumericValue;
    }
}
