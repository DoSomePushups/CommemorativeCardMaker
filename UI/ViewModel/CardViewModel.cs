using Domain;

namespace UI;

public class CardViewModel
{
    public CardId Id { get; }
    public string Name { get; }

    public CardViewModel(CardId id, string name)
    {
        Id = id;
        Name = name;
    }
}
