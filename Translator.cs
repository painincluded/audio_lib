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
        { "ErrEmptyInput", "Input cannot be empty. Try again:" },
        { "ErrExceedsMaxLength", "Input cannot exceed {0} characters. Try again:" },
        { "ErrEmptyFilePath", "File path cannot be empty. Try again:" },
        { "ErrFileNotFound", "File not found: {0}. Please enter a valid path:" },
        { "ErrInvalidConfirmation", "Please enter 'y' or 'n':" }
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
        { "ErrEmptyInput", "Vstup nesmí být prázdný. Zkuste to znovu:" },
        { "ErrExceedsMaxLength", "Vstup nesmí přesáhnout {0} znaků. Zkuste to znovu:" },
        { "ErrEmptyFilePath", "Cesta k souboru nesmí být prázdná. Zkuste to znovu:" },
        { "ErrFileNotFound", "Soubor nenalezen: {0}. Prosím zadejte platnou cestu:" },
        { "ErrInvalidConfirmation", "Prosím zadejte 'y' nebo 'n':" }
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
        { "PickOption", "select protocol:" },
        { "MenuAdd", "1 [graft] new frequency" },
        { "MenuLoad", "2 [fetch] archive from sector (json)" },
        { "MenuShow", "3 [render] active registry" },
        { "MenuSort", "4 [resequence] data arrays" },
        { "MenuDelete", "5 [purge] sequence to null" },
        { "MenuLanguage", "6 [recode] linguistic output" },
        { "MenuExit", "7 [disconnect] wetware" },

        { "SortMenuText", "resequence registry by: \n 1 identifier \n 2 origin \n 3 pulse (bpm)" },
        { "SortTitle", "identifier" },
        { "SortAuthor", "origin" },
        { "SortBpm", "pulse" },
        { "SortedBy", "arrays resequenced by" },

        { "EnterFilePath", "input path to source sector:" },
        { "CreateTrackTitle", "initiating manifest protocol..." },
        { "PromptTitle", "assign identifier:" },
        { "PromptAuthor", "identify origin unit:" },
        { "PromptBpm", "input pulse frequency (bpm):" },
        { "PromptTrackNum", "select sequence for termination (index):" },
        { "RemovedTrack", "sequence purged. sector is now null:" },
        { "LibSaved", "data etched to local storage at:" },

        { "ErrInvalidNum", "input corrupted. use valid integer:" },
        { "ErrInvalidNumRange", "index out of bounds. select between {0} and {1}:" },
        { "ErrEmptyInput", "null value detected. input required to continue:" },
        { "ErrExceedsMaxLength", "buffer overflow. use {0} characters max to avoid cascade:" },
        { "ErrEmptyFilePath", "path address null. sector location required to proceed:" },
        { "ErrFileNotFound", "sector not found: {0}. re-input valid path coordinates:" },
        { "ErrInvalidConfirmation", "protocol error. enter 'y' for yes or 'n' for no:" }
    };
}