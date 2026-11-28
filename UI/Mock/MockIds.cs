using Domain;

namespace UI;

public static class MockIds
{
    public static readonly DeckId Main = new(Guid.Parse("00000000-0000-0000-0000-000000000000"));
    public static readonly DeckId Games = new(Guid.Parse("00000000-0000-0000-0000-000000000001"));
    public static readonly DeckId Books = new(Guid.Parse("00000000-0000-0000-0000-000000000002"));
    public static readonly DeckId Birthdays = new(Guid.Parse("00000000-0000-0000-0000-000000000003"));

    public static readonly CardId LittlePrince = new(Guid.Parse("00000000-0000-0000-0000-0000000000C1"));
    public static readonly CardId BloodMeridian = new(Guid.Parse("00000000-0000-0000-0000-0000000000C2"));
    public static readonly CardId TheLastOfTheMohicans = new(Guid.Parse("00000000-0000-0000-0000-0000000000C3"));
    public static readonly CardId DiscoElysium = new(Guid.Parse("00000000-0000-0000-0000-0000000000C4"));
}
