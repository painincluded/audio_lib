namespace audio_lib;

public class Program
{
    static bool running = true;

    static string[] options = ["MenuAdd", "MenuLoad", "MenuShow", "MenuSort", "MenuDelete", "MenuLanguage", "MenuExit"];
    static string[] sortBy = ["SortTitle", "SortAuthor", "SortBpm"];

    public static void Main()
    {
        // Initialize console styling
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Title = "Audio library manager - by Frantisek Saidl";
        Console.Clear();

        // Display welcome header
        Console.WriteLine(Translator.Get("Header"));
        Console.WriteLine();

        // Initialize with English language as default
        Translator.CurrentLanguage = "en";

        // Load existing track library from file, or create new if it doesn't exist
        Track.LoadLib();

        // Main application loop - runs until user selects exit
        while (running == true)
        {
            Console.Clear();
            Console.WriteLine(Translator.Get("Header"));
            Console.WriteLine();
            DisplayMenu();
            int option = Utils.GetIntInput(Translator.Get("PickOption"), 1, 7);
            HandleMenuOption(option);
        }
    }

    // Display all menu options in current language
    static void DisplayMenu()
    {
        foreach (string optKey in options)
        {
            Console.WriteLine(Translator.Get(optKey));
        }
    }

    // Process user menu selection with error handling
    static void HandleMenuOption(int option)
    {
        switch (option)
        {
            case 1:
                Console.Clear();
                Track.CreateTrack();
                Console.WriteLine(Translator.Get("PressContinue"));
                Console.ReadKey(true);
                break;
            case 2:
                Console.Clear();
                HandleLoadTracks();
                Console.WriteLine(Translator.Get("PressContinue"));
                Console.ReadKey(true);
                break;
            case 3:
                Console.Clear();
                Track.ShowTracks();
                Console.WriteLine(Translator.Get("PressContinue"));
                Console.ReadKey(true);
                break;
            case 4:
                Console.Clear();
                HandleSort();
                Console.WriteLine(Translator.Get("PressContinue"));
                Console.ReadKey(true);
                break;
            case 5:
                Console.Clear();
                Track.DeleteTrack();
                Console.WriteLine(Translator.Get("PressContinue"));
                Console.ReadKey(true);
                break;
            case 6:
                Translator.HandleLanguageChange();
                break;
            case 7:
                Console.Clear();
                Track.SaveLib();
                Console.WriteLine($"{Translator.Get("Exiting")} {Translator.Get("PressContinue")}");
                Console.ReadKey(true);
                running = false;
                break;
        }
    }

    // Get validated file path from user before loading tracks
    static void HandleLoadTracks()
    {
        string filePath = Utils.GetFilePathInput(Translator.Get("EnterFilePath"));
        Track.LoadTracks(filePath);
    }

    // Display sort options and apply selected sorting method
    static void HandleSort()
    {
        Console.WriteLine(Translator.Get("SortMenuText"));
        int sortOption = Utils.GetIntInput(Translator.Get("PickOption"), 1, 3);
        Track.SortTracks(Translator.Get(sortBy[sortOption - 1]));
    }
}