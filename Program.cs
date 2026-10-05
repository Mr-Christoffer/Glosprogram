Console.WriteLine("Glosprogram");
List<Word> words = [];
// fyll listan med ord från fil
// UC1: Läs in alla rader till en variabel först, så att vi kan välja vilka rader som ska användas.
string[] lines = File.ReadAllLines("wordlists/swedish-english.csv");

// UC2: Rubriken (lines[0]) talar om vilka språk filen innehåller, t.ex. ["swedish", "english"].
string[] languages = lines[0].Split(",");

// UC1: Skip(1) hoppar över första raden (rubriken "swedish,english") så att den inte blir ett ord.
foreach (string line in lines.Skip(1))
{
    string[] wordPair = line.Split(","); // Tuplets
    // UC2: Språken hämtas från rubriken istället för att vara hårdkodade som "swedish" och "english".
    words.Add(new Word(wordPair[0], wordPair[1], languages[0], languages[1]));
}

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



