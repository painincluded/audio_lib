using System.Collections.Generic;

namespace audio_lib;

// Handles multilingual support by translating UI strings based on selected language
public static class Translator
{
    // Set to "en" for English, "cs" for Czech, or "au" for Augur
    public static string CurrentLanguage = "cs";

    // Retrieve translated string for given key, falling back to English if not found
    public static string Get(string key)
    {
        if (CurrentLanguage == "cs" && czechWords.ContainsKey(key))
            return czechWords[key];

        if (CurrentLanguage == "au" && augurWords.ContainsKey(key))
            return augurWords[key];

        if (englishWords.ContainsKey(key))
            return englishWords[key];

        // Return error indicator if translation key not found
        return $"[{key}]";
    }

    // Allow user to switch between available languages
    public static void HandleLanguageChange()
    {
        Console.WriteLine("1. English (en)");
        Console.WriteLine("2. Čeština (cs)");
        Console.WriteLine("3. Augur (au)");

        // Get language selection from user
        int langOpt = Utils.GetIntInput("\nSelect Language / Vyberte jazyk / Choose your tongue:", 1, 3);

        switch (langOpt)
        {
            case 1:
                CurrentLanguage = "en";
                break;
            case 2:
                CurrentLanguage = "cs";
                break;
            case 3:
                CurrentLanguage = "au";
                break;
        }

        Console.Clear();
    }

    // --- 1. ENGLISH ---
    // All UI strings for English language
    private static Dictionary<string, string> englishWords = new Dictionary<string, string>()
    {
        { "PickOption", "Pick an option:" },
        { "MenuAdd", "1 add a track" },
        { "MenuLoad", "2 load track(s) from a json file" },
        { "MenuShow", "3 show all tracks" },
        { "MenuSort", "4 sort" },
        { "MenuDelete", "5 delete a track" },
        { "MenuExit", "6 exit" },
        { "MenuLanguage", "7 change language" },

        { "SortMenuText", "sort by: \n 1 title \n 2 author \n 3 bpm" },
        { "SortTitle", "Title" },
        { "SortAuthor", "Author" },
        { "SortBpm", "Bpm" },
        { "SortedBy", "Sorted by" },

        { "EnterFilePath", "enter the path to your file:" },
        { "CreateTrackTitle", "Create Track" },
        { "PromptTitle", "title:" },
        { "PromptAuthor", "author:" },
        { "PromptBpm", "enter bpm:" },
        { "PromptTrackNum", "enter track number:" },
        { "RemovedTrack", "removed track number:" },
        { "LibSaved", "Library saved to:" },

        { "ErrInvalidNum", "Please enter a valid number:" },
        { "ErrInvalidNumRange", "Please enter a valid number between {0} and {1}:" },
        { "ErrEmptyInput", "Input cannot be empty. Try again:" }
    };

    // --- 2. CZECH ---
    // All UI strings for Czech language
    private static Dictionary<string, string> czechWords = new Dictionary<string, string>()
    {
        { "PickOption", "Vyberte možnost:" },
        { "MenuAdd", "1 přidat skladbu" },
        { "MenuLoad", "2 načíst skladbu(y) z json souboru" },
        { "MenuShow", "3 zobrazit všechny skladby" },
        { "MenuSort", "4 seřadit" },
        { "MenuDelete", "5 smazat skladbu" },
        { "MenuLanguage", "6 zmenit jazyk"},
        { "MenuExit", "7 ukončit" },

        { "SortMenuText", "seřadit podle: \n 1 názvu \n 2 autora \n 3 bpm" },
        { "SortTitle", "Název" },
        { "SortAuthor", "Autor" },
        { "SortBpm", "Bpm" },
        { "SortedBy", "Seřazeno podle" },

        { "EnterFilePath", "zadejte cestu k vašemu souboru:" },
        { "CreateTrackTitle", "Vytvořit skladbu" },
        { "PromptTitle", "název:" },
        { "PromptAuthor", "autor:" },
        { "PromptBpm", "zadejte bpm:" },
        { "PromptTrackNum", "zadejte číslo skladby:" },
        { "RemovedTrack", "odstraněna skladba číslo:" },
        { "LibSaved", "Knihovna uložena do:" },

        { "ErrInvalidNum", "Prosím zadejte platné číslo:" },
        { "ErrInvalidNumRange", "Prosím zadejte platné číslo mezi {0} a {1}:" },
        { "ErrEmptyInput", "Vstup nesmí být prázdný. Zkuste to znovu:" }
    };

    // --- 3. AUGUR (Mystical Prophet Speak) ---
    // All UI strings for Augur language (themed around mystical prophecy)
    private static Dictionary<string, string> augurWords = new Dictionary<string, string>()
    {
        { "PickOption", "Foretell your path:" },
        { "MenuAdd", "1 manifest a new sonic vision" },
        { "MenuLoad", "2 summon visions from the ancient scrolls (json)" },
        { "MenuShow", "3 reveal all prophesied sounds" },
        { "MenuSort", "4 bring order to the chaos" },
        { "MenuDelete", "5 banish a vision into the void" },
        { "MenuLanguage", "6 change your tongue" },
        { "MenuExit", "7 return to the mortal realm" },

        { "SortMenuText", "align the stars by: \n 1 true name \n 2 creator \n 3 heartbeat (bpm)" },
        { "SortTitle", "True Name" },
        { "SortAuthor", "Creator" },
        { "SortBpm", "Heartbeat" },
        { "SortedBy", "The heavens align by" },

        { "EnterFilePath", "speak the incantation of the file's resting place:" },
        { "CreateTrackTitle", "Manifesting Vision..." },
        { "PromptTitle", "speak its true name:" },
        { "PromptAuthor", "who breathed life into it?:" },
        { "PromptBpm", "what is its heartbeat (bpm)?:" },
        { "PromptTrackNum", "which vision shall be judged? (number):" },
        { "RemovedTrack", "the void has consumed vision number:" },
        { "LibSaved", "The prophecy is safely etched at:" },

        { "ErrInvalidNum", "The cosmos rejects this value. Speak a true number:" },
        { "ErrInvalidNumRange", "The fates demand a number between {0} and {1}:" },
        { "ErrEmptyInput", "Silence is not an answer. Speak your intent:" }
    };
}