using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Domain;

namespace UI;

public class DecksViewModel
{
    public ICommand OpenDeckCommand { get; }
    public ObservableCollection<DeckItemViewModel> Decks { get; }

    // Тест на моковых данных
    public DecksViewModel()
    {
        OpenDeckCommand = new Command<DeckId>(async id => await OpenDeckAsync(id));
        Decks = [];
        foreach (var deck in MockDeckSource.Decks)
            Decks.Add(new DeckItemViewModel(deck.Id, deck.Name, deck.Count, deck.Style, deck.Style == DeckStyle.Main));
    }

    private async Task OpenDeckAsync(DeckId deckId)
    {
        Debug.WriteLine(deckId);
        await Shell.Current.GoToAsync($"{nameof(DeckPage)}?deckId={deckId.Value}");
    }
}
