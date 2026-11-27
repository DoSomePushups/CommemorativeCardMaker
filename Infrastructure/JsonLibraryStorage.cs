using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure;

public sealed class JsonLibraryStorage(string filePath)
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    private readonly SemaphoreSlim _lock = new(1, 1);

    public async Task<LibraryDto> LoadAsync(CancellationToken ct = default)
    {
        await _lock.WaitAsync(ct);
        try
        {
            if (!File.Exists(filePath))
                return LibraryDto.Empty;

            await using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<LibraryDto>(stream, Options, ct)
                   ?? LibraryDto.Empty;
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task SaveAsync(LibraryDto library, CancellationToken ct = default)
    {
        await _lock.WaitAsync(ct);
        try
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var tempPath = filePath + ".tmp";
            await using (var stream = File.Create(tempPath))
            {
                await JsonSerializer.SerializeAsync(stream, library, Options, ct);
            }

            File.Move(tempPath, filePath, overwrite: true);
        }
        finally
        {
            _lock.Release();
        }
    }
}