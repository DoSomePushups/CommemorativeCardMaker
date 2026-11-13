namespace Domain;

public class Entity<TId> where TId : notnull
{
    public TId Id { get; }

    public Entity(TId id) => Id = id ?? throw new ArgumentNullException(nameof(id));

    public bool Equals(Entity<TId> other)
        => EqualityComparer<TId>.Default.Equals(Id, other.Id);

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is Entity<TId> entity)
            return Equals(entity);
        return false;
    }

    public override int GetHashCode()
        => EqualityComparer<TId>.Default.GetHashCode(Id);

    public override string ToString() => $"{GetType().Name}({nameof(Id)}: {Id})";
}
