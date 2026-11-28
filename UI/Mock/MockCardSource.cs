using Domain;

namespace UI;

public class MockCardSource
{
    private static readonly Dictionary<CardId, MockCard> _cardsById = [];

    public static IReadOnlyCollection<MockCard> Cards => _cardsById.Values;

    public static MockCard? FindById(CardId id) => _cardsById.GetValueOrDefault(id);

    public static IReadOnlyList<MockCard?> FindByIds(IEnumerable<CardId> ids) => [.. ids.Select(id => _cardsById.GetValueOrDefault(id))];
}
