using System.Drawing;

namespace Domain;

public abstract class Attribute<TValue>(TValue? value = default) 
    : Entity<AttributeId>(new(Guid.NewGuid()))
    where TValue : IAttributeValue<TValue>
{
    public Point Location { get; private set; }

    public TValue? Value { get; private set; } = value;

    public void SetValue(TValue value) => Value = value;
}
