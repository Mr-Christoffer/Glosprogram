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

// UC7: Låt användaren välja översättningsriktning. Samma valideringsmönster som menyn i UC4.
Console.WriteLine("Översättningsriktningar:");
Console.WriteLine($"1. {languages[0]} -> {languages[1]}");
Console.WriteLine($"2. {languages[1]} -> {languages[0]}");
int direction;
while (true)
{
    Console.WriteLine("Välj riktning (1-2):");
    string? input = Console.ReadLine();

    if (input == null)
    {
        return;
    }

    if (int.TryParse(input, out direction) && (direction == 1 || direction == 2))
    {
        break;
    }

    Console.WriteLine("Ogiltigt val, försök igen.");
}

// UC7: true om användaren valde det omvända hållet, t.ex. english -> swedish.
bool reversed = direction == 2;

// UC1: Skip(1) hoppar över första raden (rubriken "swedish,english") så att den inte blir ett ord.
foreach (string line in lines.Skip(1))
{
    string[] wordPair = line.Split(","); // Tuplets
    // UC2: Språken hämtas från rubriken istället för att vara hårdkodade som "swedish" och "english".
    // UC7: Vid omvänd riktning byter ord och språk plats, så att WordIn alltid är det ord användaren skriver.
    if (reversed)
    {
        words.Add(new Word(wordPair[1], wordPair[0], languages[1], languages[0]));
    }
    else
    {
        words.Add(new Word(wordPair[0], wordPair[1], languages[0], languages[1]));
    }
}

// UC7: Språket som användaren skriver på. "villkor ? om sant : om falskt" är en kort if/else som ger ett värde.
string languageIn = reversed ? languages[1] : languages[0];

// UC5: Neutralt namn istället för swedishToEnglish, eftersom språken bestäms av filen och riktningen.
// UC5: Lambda-parametrar med liten bokstav och punkten först på varje rad i LINQ-kedjan.
// UC7: Synonymer fungerar åt båda hållen, eftersom GroupBy samlar alla Word med samma WordIn,
// t.ex. "angry" -> [arg, ilsken] när riktningen är omvänd.
Dictionary<string, List<Word>> translations = words
    .GroupBy(word => word.WordIn, StringComparer.OrdinalIgnoreCase)
    .ToDictionary(
        group => group.Key, // Nyckel
        group => group.ToList(), // Värde, typiskt hela objektet (referensen)
        StringComparer.OrdinalIgnoreCase
    );

// UC6: Berätta hur man avslutar.
Console.WriteLine("Skriv q för att avsluta.");
while (true)
{
    // UC5: Ledtexten visar vilket språk ordet ska skrivas på.
    Console.WriteLine($"Ange ett ord på {languageIn}:");
    string? wordToTranslate = Console.ReadLine();

    // UC6: null (Ctrl+Z) eller "q" avslutar loopen istället för att krascha.
    if (wordToTranslate == null || wordToTranslate.Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    // UC6: En tom rad frågar bara igen. continue hoppar direkt till nästa varv i loopen.
    if (string.IsNullOrWhiteSpace(wordToTranslate))
    {
        continue;
    }

    // UC6: TryGetValue kontrollerar och hämtar i ett steg. Kompilatorn vet redan att
    // wordToTranslate inte är null här (kontrollen ovan), så ! behövs inte längre.
    if (translations.TryGetValue(wordToTranslate, out List<Word>? matches))
    {
        foreach (Word word in matches)
        {
            // UC5: Console istället för System.Console (System följer med via ImplicitUsings).
            Console.WriteLine(word.WordOut);
        }
    }
    else
    {
        // UC5: Felmeddelandet på svenska, som resten av programmet.
        Console.WriteLine("Ordet finns inte i ordlistan.");
    }
}

// UC6: Hit kommer programmet när loopen avslutas med break.
Console.WriteLine("Hej då!");



