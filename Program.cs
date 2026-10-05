Console.WriteLine("Glosprogram");

// UC3: Hämta alla .csv-filer i mappen wordlists. Nya filer hittas automatiskt utan att koden ändras.
string[] files = Directory.GetFiles("wordlists", "*.csv");
// UC3: Sortera så att numreringen blir densamma varje gång (ordningen från GetFiles är inte garanterad).
Array.Sort(files);

Console.WriteLine("Tillgängliga ordlistor:");
// UC3: for istället för foreach, eftersom vi behöver indexet i för att numrera listan.
for (int i = 0; i < files.Length; i++)
{
    // UC3: i + 1 så att listan börjar på 1 för användaren (arrayer börjar på 0).
    // GetFileNameWithoutExtension gör om "wordlists\swedish-english.csv" till "swedish-english".
    Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(files[i])}");
}

// UC4: Fråga tills användaren har skrivit ett giltigt nummer. while (true) + break avslutar loopen först när valet är okej.
int choice;
while (true)
{
    Console.WriteLine($"Välj ordlista (1-{files.Length}):");
    string? input = Console.ReadLine();

    // UC4: null betyder att inmatningen tog slut (Ctrl+Z). Utan den här kontrollen skulle loopen fråga i all oändlighet.
    if (input == null)
    {
        return;
    }

    // UC4: TryParse returnerar false istället för att krascha om texten inte är ett tal (t.ex. "abc").
    // Sedan kontrolleras att talet finns i listan, så att t.ex. 0 eller 99 inte godkänns.
    if (int.TryParse(input, out choice) && choice >= 1 && choice <= files.Length)
    {
        break;
    }

    Console.WriteLine("Ogiltigt val, försök igen.");
}

// UC4: choice - 1 eftersom listan som visas börjar på 1 men arrayen börjar på 0.
string chosenFile = files[choice - 1];

List<Word> words = [];
// fyll listan med ord från fil
// UC1: Läs in alla rader till en variabel först, så att vi kan välja vilka rader som ska användas.
// UC4: Läs den valda filen istället för det hårdkodade filnamnet.
string[] lines = File.ReadAllLines(chosenFile);

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



