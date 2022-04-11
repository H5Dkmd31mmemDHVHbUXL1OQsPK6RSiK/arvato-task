using System.Text.RegularExpressions;

namespace Arvato.Payment.Core.Helpers;

public static class StringHelpers
{
    private static readonly Regex WhiteSpaceRegex = new(@"\s+");

    public static bool IsAllNumeric(string? s)
    {
        return !string.IsNullOrWhiteSpace(s) && ReplaceWhitespace(s).All(char.IsDigit);
    }

    public static bool IsAllAlphabetic(string? s)
    {
        return !string.IsNullOrWhiteSpace(s) && ReplaceWhitespace(s).All(char.IsLetter);
    }

    public static string ReplaceWhitespace(string input)
    {
        return WhiteSpaceRegex.Replace(input, "");
    }
}