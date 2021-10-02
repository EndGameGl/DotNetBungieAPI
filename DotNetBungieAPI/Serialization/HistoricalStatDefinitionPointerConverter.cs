#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Serialization
{
    internal sealed class HistoricalStatDefinitionPointerConverter : JsonConverter<HistoricalStatDefinitionPointer>
    {
        public override bool HandleNull => true;

        public override HistoricalStatDefinitionPointer? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var statId = reader.GetString();
            return new HistoricalStatDefinitionPointer(statId);
        }

        public override void Write(Utf8JsonWriter writer, HistoricalStatDefinitionPointer value,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}