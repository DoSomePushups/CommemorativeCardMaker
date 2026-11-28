using Domain;

namespace UI;

public static class MockCardSource
{
    private static readonly Dictionary<CardId, MockCard> _cardsById = [];

    static MockCardSource()
    {
        _cardsById[MockIds.LittlePrince] = new MockCard("Маленький принц", MockIds.LittlePrince);
        _cardsById[MockIds.BloodMeridian] = new MockCard("Кровавый меридиан", MockIds.BloodMeridian);
        _cardsById[MockIds.TheLastOfTheMohicans] = new MockCard("Последний из могикан", MockIds.TheLastOfTheMohicans);
        _cardsById[MockIds.DiscoElysium] = new MockCard("Диско элизиум", MockIds.DiscoElysium);
    }

    public static IReadOnlyCollection<MockCard> Cards => _cardsById.Values;

    public static MockCard? FindById(CardId id) => _cardsById.GetValueOrDefault(id);

    public static IReadOnlyList<MockCard?> FindByIds(IEnumerable<CardId> ids) => [.. ids.Select(id => _cardsById.GetValueOrDefault(id))];
}
