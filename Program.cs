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
    new Word("stor", "large", "swedish", "english"),
    new Word("stor", "huge", "swedish", "english"),
    new Word("stor", "massive", "swedish", "english")
    ];

// Referera till ett ord ur vår array (hem på engelska):
//System.Console.WriteLine(words[1].WordOut);

// Dictionary
Dictionary<string, List<Word>> swedishToEnglish = words
.GroupBy(Word => Word.WordIn, StringComparer.OrdinalIgnoreCase).
ToDictionary(
    word => word.Key, // Nyckel
    word => word.ToList(),        // Värde, typiskt hela objektet (referensen)
    StringComparer.OrdinalIgnoreCase
);
while (true)
{
    System.Console.WriteLine("Ange vilket ord du vill översätta");
    string? wordToTranslate = Console.ReadLine();

    if (swedishToEnglish.ContainsKey(wordToTranslate!))
    {
        foreach (var word in swedishToEnglish[wordToTranslate])
        {
            System.Console.WriteLine(word.WordOut);
        }
    }
    else
    {
        System.Console.WriteLine("This word does not exist in this dictionary");
    }

}


class Word(string wordIn, string wordOut, string languageIn, string languageOut)
{
    public string WordIn { get; } = wordIn;
    public string WordOut { get; } = wordOut;
    public string LanguageIn { get; } = languageIn;
    public string LanguageOut { get; } = languageOut;
}

