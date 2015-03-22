using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    /// <summary>
    /// Creates a hashed string from a string input.
    /// </summary>
    /// <param name="input">This is the input to be hashed</param>
    /// <returns>A hashed string</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// This method checks if an array of strings contains a given word.
    /// </summary>
    /// <param name="input">This is the input which will be check</param>
    /// <returns>True if the given word is equal to one of the elements in the array; otherwise -1</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Converts a string to integer of short type.
    /// </summary>
    /// <param name="input">This is the string which will be check if it is numerical from short type</param>
    /// <returns>If the string is short type integer the method returns true; otherwise returns false</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Converts a string to integer of int type.
    /// </summary>
    /// <param name="input">This is the string which will be check if it is numerical from int type</param>
    /// <returns>If the string is int type integer the method returns true; otherwise returns false</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Converts a string to integer of long type.
    /// </summary>
    /// <param name="input">This is the string which will be check if it is numerical from long type.</param>
    /// <returns>If the string is long type integer the method returns true; otherwise returns false</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Converts string representation of a date to it's DateTime equivalent and returns value to show if the conversion succeeded.
    /// </summary>
    /// <param name="input">A the string which will be convert and which contains a date and time</param>
    /// <returns>If the string was converted successfully it returns true; otherwise returns false</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// This method makes first letter of the word capital letter.
    /// </summary>
    /// <param name="input">This is the string which first letter will be change</param>
    /// <returns>If the input string is null or empty the method returns the same string with no changes otherwise it returns the input string with capital first letter</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// This method returns string between to setted parameters
    /// </summary>
    /// <param name="input">This is the initial word</param>
    /// <param name="startString">A string to mark the start position of the extraction</param>
    /// <param name="endString">A string to mark the end position of the extraction</param>
    /// <param name="startFrom">This is the word which will be checked for wanted substring</param>
    /// <returns></returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// This is a method whitch converts cyrillic letters to latin letters.
    /// </summary>
    /// <param name="input">This is the word which letters will be converted from cyrillic to latin</param>
    /// <returns>String with latin letters and first capital letter</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// This is a method whitch converts latin letters to cyrillic letters.
    /// </summary>
    /// <param name="input">This is the word which letters will be converted from latin to cyrillic</param>
    /// <returns>String with cyrillic capital letters</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// This method makes valid username.
    /// </summary>
    /// <param name="input">This is the string which will be validate</param>
    /// <returns>String with validated username which only contains lattin letters, numbers, underscores, backslashes and dots</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// This method makes valid filename.
    /// </summary>
    /// <param name="input">This is the string to be validate</param>
    /// <returns>String with validated filename which spaces are replaced with dash and only contains lattin letters, numbers, underscores, backslashes, dashes and dots</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// This method returns given amount of characters
    /// </summary>
    /// <param name="input">This is the string from which characters will be taken</param>
    /// <param name="charsCount">And integer which shows amount of characters</param>
    /// <returns>A substring starting from the first character in the input string, with length depending of the smaller number between input string length and the value of the second parameter.</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// A method which split given string and returns file extension name
    /// </summary>
    /// <param name="fileName">A string which will be validated</param>
    /// <returns>Empty string if the input string is null or white space or the count of the splitted words is one; otherwise returns the last element from the splitted words with lower letters</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// This method checks if string is concrete file extension.
    /// </summary>
    /// <param name="fileExtension">This is the string to be checked if there is any key from a dictionary with the same name</param>
    /// <returns>The method returns the value of the dictionary with key equals to the input string name; otherwise the method returns 'application/octet-stream'</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// A methods which converts string into array of bytes
    /// </summary>
    /// <param name="input">A string which lenght multiply by 16(type char represents 16-bit Unicode character) and which letters is inserted to char array</param>
    /// <returns>New array </returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
