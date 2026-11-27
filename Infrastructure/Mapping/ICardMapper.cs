namespace Infrastructure;

public interface ICardMapper
{
    string Kind { get; }
    bool CanMap(object card);
    CardDto ToDto(object card);
    object ToDomain(CardDto dto);
}