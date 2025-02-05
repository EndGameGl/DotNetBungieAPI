using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Serialization;

public sealed class DestinyResourceConverter : JsonConverter<BungieNetResource>
{
    public override bool HandleNull => true;

    public override BungieNetResource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new BungieNetResource(reader.GetString());
    }

    public override void Write(
        Utf8JsonWriter writer,
        BungieNetResource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.RelativePath, options);
    }
}
