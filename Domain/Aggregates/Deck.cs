namespace Domain;

public class Deck(string name, DeckStyle style = DeckStyle.Default, HashSet<CardId>? cards = null, DeckId? id = null)
    : Entity<DeckId>(id ?? new(Guid.NewGuid()))
{
    private readonly HashSet<CardId> _cards = [..cards ?? []];
    public IReadOnlySet<CardId> Cards => _cards;

    public string Name { get; private set; } = name ?? throw new ArgumentNullException(nameof(name));

    public DeckStyle Style { get; private set; } = style;

    public int Count => _cards.Count();

    public bool IsEmpty => Count == 0;

    public Deck AddCard(CardId id)
    {
        _cards.Add(id);
        return this;
    }

    public Deck AddCards(IEnumerable<CardId> ids)
    {
        foreach (var id in ids)
            _cards.Add(id);
        return this;
    }
}
