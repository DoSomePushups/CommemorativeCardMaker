using Domain;

namespace UI;

public class MockCard(string name, CardId? id = null)
    : Card<MockCard>(name, id: id)
{
    protected override MockCard Self => this;
}
