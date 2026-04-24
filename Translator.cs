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
        Console.WriteLine(Translator.Get("LangEnglish"));
        Console.WriteLine(Translator.Get("LangCzech"));
        Console.WriteLine(Translator.Get("LangAugur"));

        // Get language selection from user
        int langOpt = Utils.GetIntInput(Translator.Get("SelectLanguage"), 1, 3);

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
    }

    // 1. ENGLISH
    private static Dictionary<string, string> englishWords = new Dictionary<string, string>()
    {
{ "Header", @"
 █████╗ ██╗   ██╗██████╗ ██╗ ██████╗     ██╗     ██╗██████╗ ██████╗  █████╗ ██████╗ ██╗   ██╗
██╔══██╗██║   ██║██╔══██╗██║██╔═══██╗    ██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝
███████║██║   ██║██║  ██║██║██║   ██║    ██║     ██║██████╔╝██████╔╝███████║██████╔╝ ╚████╔╝ 
██╔══██║██║   ██║██║  ██║██║██║   ██║    ██║     ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗  ╚██╔╝  
██║  ██║╚██████╔╝██████╔╝██║╚██████╔╝    ███████╗██║██████╔╝██║  ██║██║  ██║██║  ██║   ██║   
╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═╝ ╚═════╝
 ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ 
 ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗
 ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝
 ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗
 ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║
 ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝" },
        { "PickOption", "Pick an option:" },
        { "MenuAdd", "1 add a track" },
        { "MenuLoad", "2 load track(s) from a json file" },
        { "MenuShow", "3 show all tracks" },
        { "MenuSort", "4 sort" },
        { "MenuDelete", "5 delete a track" },
        { "MenuLanguage", "6 change language" },
        { "MenuExit", "7 exit" },

        { "PressContinue", "Press any key to continue..." },

        { "SortMenuText", "sort by: \n 1 title \n 2 author \n 3 bpm" },
        { "SortTitle", "Title" },
        { "SortAuthor", "Author" },
        { "SortBpm", "Bpm" },
        { "SortedBy", "Sorted by" },

        { "EnterFilePath", "Enter the path to your file:" },
        { "CreateTrackTitle", "Create track" },
        { "PromptTitle", "Title:" },
        { "PromptAuthor", "Author:" },
        { "PromptBpm", "Enter bpm:" },
        { "PromptTrackNum", "Enter track number:" },
        { "RemovedTrack", "Removed track number:" },
        { "LibSaved", "Library saved to:" },

        { "ErrInvalidNum", "Please enter a valid number:" },
        { "ErrInvalidNumRange", "Please enter a valid number between {0} and {1}:" },
        { "ErrEmptyInput", "Input cannot be empty. Try again:" },
        { "ErrExceedsMaxLength", "Input cannot exceed {0} characters. Try again:" },
        { "ErrEmptyFilePath", "File path cannot be empty. Try again:" },
        { "ErrFileNotFound", "File not found: {0}. Please enter a valid path:" },
        { "ErrInvalidConfirmation", "Please enter 'y' or 'n':" },

        { "ErrLibraryEmpty", "Library is empty." },
        { "DeleteCancelled", "Delete cancelled." },
        { "Exiting", "Exiting..." },
        { "TableNum", "Num" },
        { "TableTitle", "Title" },
        { "TableAuthor", "Author" },
        { "TableBpm", "Bpm" },
        { "DeleteConfirmation", "Delete" },
        { "LangEnglish", "1 English (en)" },
        { "LangCzech", "2 Czech (cs)" },
        { "LangAugur", "3 Augur (au)" },
        { "SelectLanguage", "Select language:" },
        { "WarnNoValidTracks", "Warning: No valid tracks found in the file." },
        { "SuccessLoadedTracks", "Successfully loaded" }
    };

    // 2. CZECH
    private static Dictionary<string, string> czechWords = new Dictionary<string, string>()
    {
{ "Header", @"
███████╗██████╗ ██████╗  █████╗ ██╗   ██╗ ██████╗███████╗
██╔════╝██╔══██╗██╔══██╗██╔══██╗██║   ██║██╔════╝██╔════╝
███████╗██████╔╝██████╔╝███████║██║   ██║██║     █████╗  
╚════██║██╔═══╝ ██╔══██╗██╔══██║╚██╗ ██╔╝██║     ██╔══╝  
███████║██║     ██║  ██║██║  ██║ ╚████╔╝ ╚██████╗███████╗
╚══════╝╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝  ╚═══╝   ╚═════╝╚══════╝
                                                         
███████╗██╗   ██╗██╗   ██╗██╗  ██╗ ██████╗ ██╗   ██╗███████╗
╚══███╔╝██║   ██║██║   ██║██║ ██╔╝██╔═══██╗██║   ██║██╔════╝
  ███╔╝ ██║   ██║██║   ██║█████╔╝ ██║   ██║██║   ██║█████╗  
 ███╔╝  ╚██╗ ██╔╝╚██╗ ██╔╝██╔═██╗ ██║   ██║╚██╗ ██╔╝██╔══╝  
███████╗ ╚████╔╝  ╚████╔╝ ██║  ██╗╚██████╔╝ ╚████╔╝ ███████╗
╚══════╝  ╚═══╝    ╚═══╝  ╚═╝  ╚═╝ ╚═════╝   ╚═══╝  ╚══════╝
                                                            
██╗  ██╗███╗   ██╗██╗██╗  ██╗ ██████╗ ██╗   ██╗██╗   ██╗
██║ ██╔╝████╗  ██║██║██║  ██║██╔═══██╗██║   ██║╚██╗ ██╔╝
█████╔╝ ██╔██╗ ██║██║███████║██║   ██║██║   ██║ ╚████╔╝ 
██╔═██╗ ██║╚██╗██║██║██╔══██║██║   ██║██║   ██║  ╚██╔╝  
██║  ██╗██║ ╚████║██║██║  ██║╚██████╔╝╚██████╔╝   ██║   
╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝    ╚═╝" },
        { "PickOption", "Vyberte moznost:" },
        { "MenuAdd", "1 pridat skladbu" },
        { "MenuLoad", "2 nacist skladbu(y) z json souboru" },
        { "MenuShow", "3 zobrazit vsechny skladby" },
        { "MenuSort", "4 seradit" },
        { "MenuDelete", "5 smazat skladbu" },
        { "MenuLanguage", "6 zmenit jazyk" },
        { "MenuExit", "7 ukoncit" },

        { "PressContinue", "Stisknte libovolnou klavesu pro pokracovani..." },

        { "SortMenuText", "seradit podle: \n 1 nazvu \n 2 autora \n 3 bpm" },
        { "SortTitle", "Nazev" },
        { "SortAuthor", "Autor" },
        { "SortBpm", "Bpm" },
        { "SortedBy", "Serazeno podle" },

        { "EnterFilePath", "Zadejte cestu k vasemu souboru:" },
        { "CreateTrackTitle", "Vytvorit skladbu" },
        { "PromptTitle", "Nazev:" },
        { "PromptAuthor", "Autor:" },
        { "PromptBpm", "Zadejte bpm:" },
        { "PromptTrackNum", "Zadejte cislo skladby:" },
        { "RemovedTrack", "Odstranena skladba cislo:" },
        { "LibSaved", "Knihovna ulozena do:" },

        { "ErrInvalidNum", "Prosim zadejte platne cislo:" },
        { "ErrInvalidNumRange", "Prosim zadejte platne cislo mezi {0} a {1}:" },
        { "ErrEmptyInput", "Vstup nesmi byt prazdny. Zkuste to znovu:" },
        { "ErrExceedsMaxLength", "Vstup nesmi presahnout {0} znaku. Zkuste to znovu:" },
        { "ErrEmptyFilePath", "Cesta k souboru nesmi byt prazdna. Zkuste to znovu:" },
        { "ErrFileNotFound", "Soubor nenalezen: {0}. Prosim zadejte platnou cestu:" },
        { "ErrInvalidConfirmation", "Prosim zadejte 'y' nebo 'n':" },

        { "ErrLibraryEmpty", "Knihovna je prazdna." },
        { "DeleteCancelled", "Mazani zruseno." },
        { "Exiting", "Vypinani..." },
        { "TableNum", "Cislo" },
        { "TableTitle", "Nazev" },
        { "TableAuthor", "Autor" },
        { "TableBpm", "Bpm" },
        { "DeleteConfirmation", "Smazat" },
        { "LangEnglish", "1 Anglictina (en)" },
        { "LangCzech", "2 Cestina (cs)" },
        { "LangAugur", "3 Augur (au)" },
        { "SelectLanguage", "Vyberte jazyk:" },
        { "WarnNoValidTracks", "Upozorneni: V souboru nebyla nalezena zadna platna skladba." },
        { "SuccessLoadedTracks", "Uspesne nacteno" }
    };

    // 3. AUGUR
    private static Dictionary<string, string> augurWords = new Dictionary<string, string>()
    {
        { "Header", @"
███████╗ ██████╗ ███╗   ██╗██╗ ██████╗     ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗██████╗ ██╗   ██╗
██╔════╝██╔═══██╗████╗  ██║██║██╔════╝     ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔══██╗╚██╗ ██╔╝
███████╗██║   ██║██╔██╗ ██║██║██║          ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   ██████╔╝ ╚████╔╝ 
╚════██║██║   ██║██║╚██╗██║██║██║          ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══██╗  ╚██╔╝  
███████║╚██████╔╝██║ ╚████║██║╚██████╗     ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ██║  ██║   ██║   
╚══════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝ ╚═════╝     ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝   ╚═╝   
                                                                                                         
          ██████╗ ██████╗  ██████╗ ████████╗ ██████╗  ██████╗  ██████╗ ██╗     
          ██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝██╔═══██╗██╔════╝ ██╔═══██╗██║     
          ██████╔╝██████╔╝██║   ██║   ██║   ██║   ██║██║      ██║   ██║██║     
          ██╔═══╝ ██╔══██╗██║   ██║   ██║   ██║   ██║██║      ██║   ██║██║     
          ██║     ██║  ██║╚██████╔╝   ██║   ╚██████╔╝╚██████╗ ╚██████╔╝███████╗
          ╚═╝     ╚═╝  ╚═╝ ╚═════╝    ╚═╝    ╚═════╝  ╚═════╝  ╚═════╝ ╚══════╝" },
        { "PickOption", "Select protocol:" },
        { "MenuAdd", "1 [graft] new frequency" },
        { "MenuLoad", "2 [fetch] archive from sector (json)" },
        { "MenuShow", "3 [render] active registry" },
        { "MenuSort", "4 [resequence] data arrays" },
        { "MenuDelete", "5 [purge] sequence to null" },
        { "MenuLanguage", "6 [recode] linguistic output" },
        { "MenuExit", "7 [disconnect] wetware" },

        { "PressContinue", "Strike the terminal..." },

        { "SortMenuText", "Resequence registry by: \n 1 identifier \n 2 origin \n 3 pulse (bpm)" },
        { "SortTitle", "Identifier" },
        { "SortAuthor", "Origin" },
        { "SortBpm", "Pulse" },
        { "SortedBy", "Arrays resequenced by" },

        { "EnterFilePath", "Input path to source sector:" },
        { "CreateTrackTitle", "Initiating manifest protocol..." },
        { "PromptTitle", "Assign identifier:" },
        { "PromptAuthor", "Identify origin unit:" },
        { "PromptBpm", "Input pulse frequency (bpm):" },
        { "PromptTrackNum", "Select sequence for termination (index):" },
        { "RemovedTrack", "Sequence purged. Sector is now null:" },
        { "LibSaved", "Data etched to local storage at:" },

        { "ErrInvalidNum", "Input corrupted. Use valid integer:" },
        { "ErrInvalidNumRange", "Index out of bounds. Select between {0} and {1}:" },
        { "ErrEmptyInput", "Null value detected. Input required to continue:" },
        { "ErrExceedsMaxLength", "Buffer overflow. Use {0} characters max to avoid cascade:" },
        { "ErrEmptyFilePath", "Path address null. Sector location required to proceed:" },
        { "ErrFileNotFound", "Sector not found: {0}. Re-input valid path coordinates:" },
        { "ErrInvalidConfirmation", "Protocol error. Enter 'y' for yes or 'n' for no:" },

        { "ErrLibraryEmpty", "Registry is null." },
        { "DeleteCancelled", "Purge protocol terminated." },
        { "Exiting", "Terminating connection..." },
        { "TableNum", "Index" },
        { "TableTitle", "Identifier" },
        { "TableAuthor", "Origin" },
        { "TableBpm", "Pulse" },
        { "DeleteConfirmation", "Purge" },
        { "LangEnglish", "1 English (en)" },
        { "LangCzech", "2 Czech (cs)" },
        { "LangAugur", "3 Augur (au)" },
        { "SelectLanguage", "Select protocol:" },
        { "WarnNoValidTracks", "Alert: Archive sector contains no valid sequences." },
        { "SuccessLoadedTracks", "Archive successfully integrated" }
    };
}