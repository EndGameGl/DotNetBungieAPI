﻿#nullable enable
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
        var statId = reader.GetString();
        return new HistoricalStatDefinitionPointer(statId);
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
