namespace UI;

public static class DeckCaption
{
    public static string Build(int count, bool isMain)
        => isMain
            ? $"Все карточки · {count}"
            : $"{count} {GetDeclination(count)}";

    private static string GetDeclination(int count)
    {
        var lastDigit = count % 10;
        var lastTwoDigits = count % 100;
        if (lastDigit == 1 && lastTwoDigits != 11)
            return "карточка";
        else if (2 <= lastDigit && lastDigit <= 4 && !(12 <= lastDigit && lastDigit <= 14))
            return "карточки";
        else
            return "карточек";
    }
}
