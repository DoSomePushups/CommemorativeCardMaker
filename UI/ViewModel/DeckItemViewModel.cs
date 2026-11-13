using Domain;

namespace UI;

public class DeckItemViewModel
{
    public DeckId Id { get; set; }
    public string Name { get; set; }
    public string Caption { get; set; }
    public Color Color { get; set; }
    public string IconSource { get; set; }
    public bool IsEmpty { get; set; }
    public bool HasTwoCards { get; set; }
    public bool HasMultipleCards { get; set; }

    public DeckItemViewModel(DeckId id, string name, int cardCount, DeckStyle style, bool isMain)
    {
        Id = id;
        Name = name;
        Caption = BuildCaption(cardCount, isMain);
        IsEmpty = cardCount == 0;
        var colorIcon = GetMatchingColorIcon(style);
        Color = colorIcon.Color;
        IconSource = colorIcon.Icon;
        HasTwoCards = cardCount > 1;
        HasMultipleCards = cardCount > 2;
    }

    private string BuildCaption(int count, bool isMain)
        => isMain ? $"Все карточки · {count}" : $"{count} карточек";

    private (Color Color, string Icon) GetMatchingColorIcon(DeckStyle style) => style switch
    {
        DeckStyle.Main => (Color.FromArgb("#DBADFF"), "sparkle.png"),
        DeckStyle.Game => (Color.FromArgb("#0F45A8"), "gamepad.png"),
        DeckStyle.Empty => (Color.FromArgb("#000000"), "plus.png"),
        _ => (Color.FromArgb("#8D8D8D"), "question.png")
    };
}
