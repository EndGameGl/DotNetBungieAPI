using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Serialization;

public sealed class HistoricalStatDefinitionPointerConverter
    : JsonConverter<HistoricalStatDefinitionPointer>
{
    public override bool HandleNull => true;

    public override HistoricalStatDefinitionPointer Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new HistoricalStatDefinitionPointer(reader.GetString());
    }

    public override void Write(
        Utf8JsonWriter writer,
        HistoricalStatDefinitionPointer value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.StatId, options);
    }
}
