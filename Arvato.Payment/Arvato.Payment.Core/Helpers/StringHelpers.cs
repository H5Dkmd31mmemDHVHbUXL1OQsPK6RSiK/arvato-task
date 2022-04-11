namespace Arvato.Payment.Core.Helpers;

public static class StringHelpers
{
    public static bool IsAllNumeric(string? s)
    {
        return !string.IsNullOrWhiteSpace(s) && s.Trim().All(char.IsDigit);
    }

    public static bool IsAllAlphabetic(string? s)
    {
        return !string.IsNullOrWhiteSpace(s) && s.Trim().All(char.IsLetter);
    }
}