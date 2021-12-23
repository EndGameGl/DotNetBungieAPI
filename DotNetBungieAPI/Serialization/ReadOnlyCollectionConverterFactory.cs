using System.Reflection;

namespace DotNetBungieAPI.Serialization;

internal sealed class ReadOnlyCollectionConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType) return false;

        if (typeToConvert.GetGenericTypeDefinition() != typeof(ReadOnlyCollection<>)) return false;

        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var collectionType = typeToConvert.GetGenericArguments()[0];

        var converter = (JsonConverter)Activator.CreateInstance(
            typeof(ReadOnlyCollectionConverter<>).MakeGenericType(collectionType),
            BindingFlags.Instance | BindingFlags.Public,
            null,
            new object[] { options },
            null);

        return converter;
    }

    private class ReadOnlyCollectionConverter<T> : JsonConverter<ReadOnlyCollection<T>>
    {
        private readonly JsonSerializerOptions _options;

        public ReadOnlyCollectionConverter(JsonSerializerOptions options)
        {
            _options = options;
        }

        public override bool HandleNull => true;

        public override ReadOnlyCollection<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return ReadOnlyCollections<T>.Empty;

            IList<T> tempCollection = new List<T>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    return new ReadOnlyCollection<T>(tempCollection);
                tempCollection.Add(JsonSerializer.Deserialize<T>(ref reader, _options));
            }

            throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReadOnlyCollection<T> value,
            JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var item in value) JsonSerializer.Serialize(writer, item, options);

            writer.WriteEndArray();
        }
    }
}