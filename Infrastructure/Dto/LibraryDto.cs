using System.Text.Json;

namespace Infrastructure;

public sealed record LibraryDto(int Version, List<CardDto> Cards, List<DeckDto> Decks)
{
    public const int CurrentVersion = 1;

    public static LibraryDto Empty => new(CurrentVersion, [], []);
}

public sealed record CardDto(Guid Id, string Kind, string Name, List<AttributeDto> Attributes);

public sealed record AttributeDto(Guid Id, string Kind, JsonElement? Value);

public sealed record DeckDto(Guid Id, string Name, DeckStyle Style, List<Guid> Cards)
{
    public static DeckDto From(Deck deck) =>
        new(deck.Id.Value, deck.Name, deck.Style, deck.Cards.Select(c => c.Value).ToList());

    public Deck ToDomain() =>
        new(Name, Style, [.. Cards.Select(g => new CardId(g))], new DeckId(Id));
}