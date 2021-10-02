using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Serialization
{
    internal sealed class DestinyResourceConverter : JsonConverter<DestinyResource>
    {
        public override bool HandleNull => true;

        public override DestinyResource Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return new DestinyResource(null);

            return new DestinyResource(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DestinyResource value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}