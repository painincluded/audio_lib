namespace audio_lib;

// Utility class for validated user input across the application
public class Utils
{
    // Get integer input with range validation, keeps asking until valid input received
    public static int GetIntInput(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int parsedInt;
        Console.WriteLine(prompt);

        // Loop until valid number in range is entered
        while (int.TryParse(Console.ReadLine(), out parsedInt) == false || parsedInt < min || parsedInt > max)
        {
            if (min == int.MinValue && max == int.MaxValue)
            {
                Console.WriteLine(Translator.Get("ErrInvalidNum"));
            }
            else
            {
                Console.WriteLine(Translator.Get("ErrInvalidNumRange").Replace("{0}", min.ToString()).Replace("{1}", max.ToString()));
            }
        }

        return parsedInt;
    }

    // Get non-empty string input from user
    public static string GetStringInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();

        // Reject empty or whitespace-only input
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(Translator.Get("ErrEmptyInput"));
            input = Console.ReadLine();
        }

        return input;
    }

    // Validate BPM within musical range (0-300 covers all realistic tempos)
    public static int GetBpmInput(string prompt)
    {
        return GetIntInput(prompt, 0, 300);
    }

    // Get string input with character limit to prevent display overflow
    public static string GetLimitedStringInput(string prompt, int maxLength = 255)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();

        // Validate both content and length
        while (string.IsNullOrWhiteSpace(input) || input.Length > maxLength)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(Translator.Get("ErrEmptyInput"));
            }
            else
            {
                Console.WriteLine(Translator.Get("ErrExceedsMaxLength").Replace("{0}", maxLength.ToString()));
            }
            input = Console.ReadLine();
        }

        return input.Trim();
    }

    // Ensure file exists before returning path to prevent file not found errors
    public static string GetFilePathInput(string prompt)
    {
        Console.WriteLine(prompt);
        string filePath = Console.ReadLine();

        // Loop until user provides valid, existing file path
        while (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine(Translator.Get("ErrEmptyFilePath"));
            }
            else
            {
                Console.WriteLine(Translator.Get("ErrFileNotFound").Replace("{0}", filePath));
            }
            filePath = Console.ReadLine();
        }

        return filePath;
    }

    // Get yes/no confirmation from user for destructive operations
    public static bool GetConfirmation(string prompt)
    {
        Console.WriteLine(prompt + " (y/n):");
        string response = Console.ReadLine().ToLower();

        // Keep asking until user enters 'y' or 'n'
        while (response != "y" && response != "n")
        {
            Console.WriteLine(Translator.Get("ErrInvalidConfirmation"));
            response = Console.ReadLine().ToLower();
        }

        return response == "y";
    }
}