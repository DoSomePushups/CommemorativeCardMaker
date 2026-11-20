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
        var birthdays = new Deck("Books", id: new(Guid.Parse("00000000-0000-0000-0000-000000000003")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C1")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C2")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C3")));
        main.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C4")));
        games.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C1")));
        games.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C2")));
        books.AddCard(new(Guid.Parse("00000000-0000-0000-0000-0000000000C3")));
        _idDecks.Add(main.Id, main);
        _idDecks.Add(games.Id, games);
        _idDecks.Add(books.Id, books);
        _idDecks.Add(birthdays.Id, birthdays);
    }

    public static Deck? FindById(DeckId id) => _idDecks.GetValueOrDefault(id);
}
