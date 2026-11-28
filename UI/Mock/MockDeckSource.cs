using Domain;

namespace UI;

internal static class MockDeckSource
{
    private static readonly Dictionary<DeckId, Deck> _idDecks = [];

    public static IReadOnlyCollection<Deck> Decks => _idDecks.Values;

    static MockDeckSource()
    {
        var main = new Deck("Main", style: DeckStyle.Main, id: MockIds.Main);
        var books = new Deck("Books", id: MockIds.Books);
        var games = new Deck("Games", style: DeckStyle.Game, id: MockIds.Games);
        var birthdays = new Deck("Birthdays", id: MockIds.Birthdays);
        main.AddCard(MockIds.LittlePrince);
        main.AddCard(MockIds.BloodMeridian);
        main.AddCard(MockIds.TheLastOfTheMohicans);
        main.AddCard(MockIds.DiscoElysium);
        books.AddCard(MockIds.LittlePrince);
        books.AddCard(MockIds.BloodMeridian);
        books.AddCard(MockIds.TheLastOfTheMohicans);
        games.AddCard(MockIds.DiscoElysium);
        _idDecks.Add(main.Id, main);
        _idDecks.Add(games.Id, games);
        _idDecks.Add(books.Id, books);
        _idDecks.Add(birthdays.Id, birthdays);
    }

    public static Deck? FindById(DeckId id) => _idDecks.GetValueOrDefault(id);
}
