# Glosprogram – kodstandard och arbetssätt

Glosprogram är en konsolapp i C# som översätter ord med hjälp av ordlistor i CSV-format.
Utvecklaren är nybörjare i C# (YH-utbildning). Förklara därför *varför* en lösning fungerar,
inte bara *vad* som ska skrivas.

## AI-modell
Arbetet ska ske med Claude Opus 5.5 (`claude-opus-5-5`) i Claude Code. Fråga om annan modell behövs

## Plattform
- .NET 10, `ImplicitUsings` och `Nullable` är påslagna (se `Glosprogram.csproj`).
- Top-level statements i `Program.cs`. Klasser definieras längst ner i filen, efter programflödet.

## Namngivning
- **PascalCase** för klasser och properties: `Word`, `WordIn`, `LanguageOut`.
- **camelCase** för lokala variabler, parametrar och lambda-parametrar: `wordPair`, `wordToTranslate`, `word => word.Key`.
- Namn ska beskriva innehållet. Variabelnamn får inte låsa koden till ett visst språk
  (skriv t.ex. `translations`, inte `swedishToEnglish`), eftersom språken bestäms av filerna.

## Typer och syntax
- Skriv ut typerna explicit när de inte är självklara: `string[] wordPair`, `List<Word> words`,
  `Dictionary<string, List<Word>>`. `var` är okej i `foreach` när typen framgår av sammanhanget.
- Använd collection expressions för nya samlingar: `List<Word> words = [];`
- Använd primary constructors med get-only auto-properties för dataklasser, så att objekten inte kan ändras:
  ```csharp
  class Word(string wordIn, string wordOut, string languageIn, string languageOut)
  {
      public string WordIn { get; } = wordIn;
      ...
  }
  ```
- Skriv `Console.WriteLine` utan prefixet `System.`, eftersom ImplicitUsings redan ger `System`.

## Formatering
- Klamrar på egen rad (Allman-stil) och 4 mellanslags indrag.
- Långa LINQ-kedjor bryts med en metod per rad, och punkten sätts först på raden:
  ```csharp
  Dictionary<string, List<Word>> translations = words
      .GroupBy(word => word.WordIn, StringComparer.OrdinalIgnoreCase)
      .ToDictionary(
          group => group.Key,
          group => group.ToList(),
          StringComparer.OrdinalIgnoreCase
      );
  ```

## Data och uppslag
- Ordlistorna ligger i `wordlists/` och heter `<språk>-<språk>.csv`, t.ex. `swedish-english.csv`.
- Första raden i en CSV-fil är en rubrik med språknamnen (`swedish,english`) och ska inte läsas in som ett ord.
- Språk ska aldrig hårdkodas. De bestäms av de tillgängliga filerna och rubrikraden.
- Synonymer (samma ord med flera översättningar) hanteras med `GroupBy` till `Dictionary<string, List<Word>>`.
- Ordsökningar ska inte bry sig om stora och små bokstäver: använd `StringComparer.OrdinalIgnoreCase`.

## Null-hantering
- Undvik null-forgiving-operatorn `!`. Kontrollera null uttryckligen, t.ex. med
  `string.IsNullOrWhiteSpace`, och använd `TryGetValue` eller `TryParse` istället för att anta att ett värde finns.

## Kommentarer
- Kommentarer skrivs på svenska. De får gärna vara pedagogiska och förklara koncept,
  t.ex. `// Värde, typiskt hela objektet (referensen)`.
- Ta bort utkommenterad gammal kod när den inte längre behövs som referens.

## Arbetssätt
- Ändringar görs stegvis, ett use case i taget (UC1, UC2 …), och varje use case blir en egen commit.
  Alla use cases finns i `specs/`, med en översikt och status i `specs/README.md`.
- Varje use case har acceptanskriterier som testas genom att köra programmet (`dotnet run`) innan nästa steg påbörjas.
- Leverera inte hela lösningen på en gång. Guida fram den och visa korta, kommenterade kodexempel.
