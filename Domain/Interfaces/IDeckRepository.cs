namespace Domain;

public interface IDeckRepository
{
    Task<IReadOnlyList<Deck>> GetAllAsync(CancellationToken ct = default);
    Task SaveAsync(Deck deck, CancellationToken ct = default);
    Task DeleteAsync(DeckId id, CancellationToken ct = default);
}