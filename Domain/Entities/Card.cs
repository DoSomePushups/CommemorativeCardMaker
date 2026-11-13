namespace Domain;

public abstract class Card<TCard>(string name, HashSet<Attribute>? attributes = null) 
    : Entity<CardId>(new(Guid.NewGuid()))
    where TCard : Card<TCard>
{
    private readonly HashSet<Attribute> _attributes = attributes ?? [];
    public IReadOnlySet<Attribute> Attributes => _attributes;

    protected abstract TCard Self { get; }

    public string Name { get; private set; } = name;

    public TCard ChangeName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        return Self;
    }

    public TCard AddAttribute(Attribute attribute)
    {
        _attributes.Add(attribute);
        return Self;
    }

    public TCard AddAttributes(IEnumerable<Attribute> attributes)
    {
        foreach (var attribute in attributes)
            _attributes.Add(attribute);
        return Self;
    }
}
