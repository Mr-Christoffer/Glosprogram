Console.WriteLine("Glosprogram");
/*
List<string> words =
[
    "hus", "house", // jämna index = svenskt upplag, udda är engelska
    "hem", "home",
    "stor", "big", // synonymer får hanteras i en loop
    "stor", "large",
]; */
List<Word> words = [
    new Word("hus", "house", "swedish", "english"),
    new Word("hem", "home", "swedish", "english"),
    new Word("stor", "big", "swedish", "english"),
    // new Word("stor", "large", "swedish", "english")
    ];

// Referera till ett ord ur vår array (hem på engelska):
System.Console.WriteLine(words[1].WordOut);

// Dictionary
Dictionary<string, Word> swedishToEnglish = words.ToDictionary(
    word => word.WordIn, // Nyckel
    word => word // Värde
);
// Referera till ett ord ur vår dictionary
System.Console.WriteLine(swedishToEnglish["hem"].WordOut);
class Word(string wordIn, string wordOut, string languageIn, string languageOut)
{
    public string WordIn{get; } = wordIn;
    public string WordOut{get; } = wordOut;
    public string LanguageIn{get; } = languageIn;
    public string LanguageOut{get; } = languageOut;
}

