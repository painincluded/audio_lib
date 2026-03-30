using System;

namespace audio_lib;

public class Program
{
    static bool running = true;

    static string[] options = ["MenuAdd", "MenuLoad", "MenuShow", "MenuSort", "MenuDelete", "MenuExit", "MenuLanguage"];
    static string[] sortBy = ["SortTitle", "SortAuthor", "SortBpm"];

    public static void Main()
    {
        // Initialize with Czech language as default
        Translator.CurrentLanguage = "cs";

        // Load existing track library from file
        Track.LoadLib();

        // Main application loop - runs until user selects exit
        while (running == true)
        {
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
        try
        {
            switch (option)
            {
                case 1:
                    Track.CreateTrack();
                    break;
                case 2:
                    HandleLoadTracks();
                    break;
                case 3:
                    Track.ShowTracks();
                    break;
                case 4:
                    HandleSort();
                    break;
                case 5:
                    Track.DeleteTrack();
                    break;
                case 6:
                    Track.SaveLib();
                    running = false;
                    break;
                case 7:
                    Translator.HandleLanguageChange();
                    Console.Clear();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
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