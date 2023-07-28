using System.Globalization;

namespace FastLogr.Generator.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string input)
    {
        // Check if the input string is null or empty
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Split the string into words by whitespace or underscores
        string[] words = input.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

        // Capitalize the first letter of each word except the first word
        for (int i = 1; i < words.Length; i++)
        {
            words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
        }

        // Join the words back to form the camelCase string
        return string.Concat(words);
    }
    
    public static string ToLowerCamelCase(this string input)
    {
        // Check if the input string is null or empty
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Split the string into words by whitespace or underscores
        string[] words = input.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

        // Capitalize the first letter of each word starting from the first word
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = i == 0
                ? words[i].Substring(0, 1).ToLower() + words[i].Substring(1)
                : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
        }

        // Join the words back to form the lowerCamelCase string
        return string.Concat(words);
    }
}