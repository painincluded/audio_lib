using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace audio_lib;

public class Track
{
    static string defaultFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "AudioLib", "library.json");

    public string Title { get; set; }
    public string Author { get; set; }
    public int Bpm { get; set; }

    public static List<Track> tracks = new List<Track>();

    // Create new track with user input and save to library
    public static void CreateTrack()
    {
        try
        {
            Track track = new Track();

            Console.WriteLine("\n--- " + Translator.Get("CreateTrackTitle") + " ---");

            track.Title = Utils.GetLimitedStringInput(Translator.Get("PromptTitle"), 50);
            track.Author = Utils.GetLimitedStringInput(Translator.Get("PromptAuthor"), 50);
            track.Bpm = Utils.GetBpmInput(Translator.Get("PromptBpm"));

            tracks.Add(track);
            SaveLib();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating track: {ex.Message}");
        }
    }

    // Remove track from library with user confirmation to prevent accidental deletion
    public static void DeleteTrack()
    {
        if (tracks.Count == 0)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        ShowTracks();

        int index = Utils.GetIntInput(Translator.Get("PromptTrackNum"), 1, tracks.Count) - 1;

        // Confirmation prevents loss of data
        if (Utils.GetConfirmation($"Delete '{tracks[index].Title}' by {tracks[index].Author}?"))
        {
            tracks.RemoveAt(index);
            SaveLib();
            Console.WriteLine($"{Translator.Get("RemovedTrack")} {index + 1}");
        }
        else
        {
            Console.WriteLine("Delete cancelled.");
        }
    }

    // Display all tracks in formatted table for user selection
    public static void ShowTracks()
    {
        int current = 1;

        Console.WriteLine();
        Console.WriteLine($"| {"num",-5} | {"title",-20} | {"author",-15} | {"bpm",-5} |");
        // Format table with separator line for readability
        Console.WriteLine(new string('-', 57));

        foreach (Track track in tracks)
        {
            Console.WriteLine($"| {current,-5} | {track.Title,-20} | {track.Author,-15} | {track.Bpm,-5} |");
            current++;
        }
        Console.WriteLine();
    }

    // Sort and display tracks without modifying original order in memory
    public static void SortTracks(string sortByTranslatedValue)
    {
        List<Track> tempSortedList;

        if (sortByTranslatedValue == Translator.Get("SortTitle"))
        {
            tempSortedList = tracks.OrderBy(t => t.Title).ToList();
        }
        else if (sortByTranslatedValue == Translator.Get("SortAuthor"))
        {
            tempSortedList = tracks.OrderBy(t => t.Author).ToList();
        }
        else if (sortByTranslatedValue == Translator.Get("SortBpm"))
        {
            tempSortedList = tracks.OrderBy(t => t.Bpm).ToList();
        }
        else
        {
            tempSortedList = tracks.ToList();
        }

        int current = 1;
        Console.WriteLine($"\n--- {Translator.Get("SortedBy")} {sortByTranslatedValue} ---");
        Console.WriteLine($"| {"num",-5} | {"title",-20} | {"author",-15} | {"bpm",-5} |");
        Console.WriteLine(new string('-', 57));

        foreach (Track track in tempSortedList)
        {
            Console.WriteLine($"| {current,-5} | {track.Title,-20} | {track.Author,-15} | {track.Bpm,-5} |");
            current++;
        }
        Console.WriteLine();
    }

    // Load and merge tracks from JSON file with comprehensive error handling
    public static void LoadTracks(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found at '{filePath}'.");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<Track> newTracks = JsonSerializer.Deserialize<List<Track>>(json);

            if (newTracks != null && newTracks.Count > 0)
            {
                tracks.AddRange(newTracks);
                SaveLib();
                Console.WriteLine($"Successfully loaded {newTracks.Count} track(s).");
            }
            else
            {
                Console.WriteLine("Warning: No valid tracks found in the file.");
            }
        }
        // Catch JSON parsing errors to distinguish from file I/O issues
        catch (JsonException ex)
        {
            Console.WriteLine($"Error: Invalid JSON format in file. {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: Cannot read file. {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tracks: {ex.Message}");
        }
    }

    // Serialize and save track library to JSON file with automatic directory creation
    public static void SaveLib(string? filePath = null)
    {
        try
        {
            filePath ??= defaultFilePath;
            string directory = Path.GetDirectoryName(filePath);

            // Create directory structure if it doesn't exist
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(tracks);
            File.WriteAllText(filePath, json);

            Console.WriteLine($"{Translator.Get("LibSaved")} {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: Cannot save library. {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving library: {ex.Message}");
        }
    }

    // Load track library from file on startup, creating empty library if needed
    public static void LoadLib()
    {
        try
        {
            string directory = Path.GetDirectoryName(defaultFilePath);

            // Ensure library directory exists
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create empty library file on first run
            if (!File.Exists(defaultFilePath))
            {
                File.WriteAllText(defaultFilePath, "[]");
            }

            string json = File.ReadAllText(defaultFilePath);
            tracks = JsonSerializer.Deserialize<List<Track>>(json) ?? new List<Track>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading library: {ex.Message}");
            tracks = new List<Track>();
        }
    }
}