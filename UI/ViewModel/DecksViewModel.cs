using System.Collections.ObjectModel;
using Domain;

namespace UI;

public class DecksViewModel
{
    public ObservableCollection<DeckItemViewModel> Decks { get; }

    // Тест на моковых данных
    public DecksViewModel()
    {
        Decks = [];
        Decks.Add(new DeckItemViewModel(new(Guid.NewGuid()), "Main", 12, DeckStyle.Main, true));
        Decks.Add(new DeckItemViewModel(new(Guid.NewGuid()), "Games", 2, DeckStyle.Game, false));
        Decks.Add(new DeckItemViewModel(new(Guid.NewGuid()), "Books", 0, DeckStyle.Empty, false));
    }
}
