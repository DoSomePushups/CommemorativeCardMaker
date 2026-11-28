using CommunityToolkit.Mvvm.ComponentModel;
using Domain;

namespace UI;

public partial class DeckViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _caption = string.Empty;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("deckId", out var value))
            throw new InvalidOperationException("deckId was not found in navigation parameters");
        if (value is not string text || !Guid.TryParse(text, out var guid))
            throw new InvalidOperationException($"Invalid deckId: {value}");
        LoadDeck(new DeckId(guid));
    }

    private void LoadDeck(DeckId id)
    {
        var deck = MockDeckSource.FindById(id)
            ?? throw new InvalidOperationException($"Deck with id {id} wasn't found");
        Name = deck.Name;
        Caption = DeckCaption.Build(deck.Count, deck.Style == DeckStyle.Main);
    }
}
