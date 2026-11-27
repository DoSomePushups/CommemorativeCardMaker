namespace Infrastructure;

public sealed class JsonDeckRepository(JsonLibraryStorage storage) : IDeckRepository
{
    public async Task<IReadOnlyList<Deck>> GetAllAsync(CancellationToken ct = default)
    {
        var library = await storage.LoadAsync(ct);
        return library.Decks.Select(d => d.ToDomain()).ToList();
    }

    public async Task SaveAsync(Deck deck, CancellationToken ct = default)
    {
        var library = await storage.LoadAsync(ct);
        library.Decks.RemoveAll(d => d.Id == deck.Id.Value);
        library.Decks.Add(DeckDto.From(deck));
        await storage.SaveAsync(library, ct);
    }

    public async Task DeleteAsync(DeckId id, CancellationToken ct = default)
    {
        var library = await storage.LoadAsync(ct);
        library.Decks.RemoveAll(d => d.Id == id.Value);
        await storage.SaveAsync(library, ct);
    }
}