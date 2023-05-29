namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Custom class to keep and provide <see cref="JsonSerializerOptions" /> object along with serialization utility
///     methods
/// </summary>
public interface IBungieNetJsonSerializer
{
    ValueTask<object> DeserializeAsync(byte[] data, Type type);

    ValueTask<T> DeserializeAsync<T>(byte[] data);

    ValueTask<object> DeserializeAsync(Stream data, Type type);

    ValueTask<T> DeserializeAsync<T>(Stream data);

    T Deserialize<T>(Stream data);

    object Deserialize(string json, Type type);

    object Deserialize(ReadOnlySpan<byte> data, Type type);

    T Deserialize<T>(ReadOnlySpan<byte> data);

    T Deserialize<T>(string json);

    T Deserialize<T>(ref byte[] data);

    string Serialize<T>(T obj);

    Task SerializeAsync<T>(Stream stream, T data);
}
