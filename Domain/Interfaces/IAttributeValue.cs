namespace Domain;

public interface IAttributeValue<TValue> where TValue : IAttributeValue<TValue>
{
    public TValue ChangeValue();
}
