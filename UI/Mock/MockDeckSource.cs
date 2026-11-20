using Domain;

namespace UI;

internal static class MockDeckSource
{
    private static readonly Dictionary<DeckId, Deck> _idDecks = [];

    public static IReadOnlyCollection<Deck> Decks => _idDecks.Values;

    static MockDeckSource()
    {
        var main = new Deck("Main", style: DeckStyle.Main, id: new(Guid.Parse("00000000-0000-0000-0000-000000000000")));
        var games = new Deck("Games", style: DeckStyle.Game, id: new(Guid.Parse("00000000-0000-0000-0000-000000000001")));
        var books = new Deck("Books", id: new(Guid.Parse("00000000-0000-0000-0000-000000000002")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C1")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C2")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C3")));
        games.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C4")));
        _idDecks.Add(main.Id, main);
        _idDecks.Add(games.Id, games);
        _idDecks.Add(books.Id, books);
    }

    public static Deck? FindById(DeckId id)
    {
        if (_idDecks.TryGetValue(id, out var deck))
            return deck;
        return null;
    }
}
