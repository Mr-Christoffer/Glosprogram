# BUG1 – Programmet kraschar vid start: ordlistan hittas inte

**Status:** Löst – snabbfix: filnamnet rättades för hand. Slutlig lösning: [UC4](../specs/UC4-valja-ordlista.md) ersatte det hårdkodade filnamnet med användarens val (`File.ReadAllLines(chosenFile)`). Verifierat 2026-10-05 med `dotnet run`.
**Hittad:** 2026-10-05, vid test av UC3
**Allvarlighet:** Hög – programmet går inte att använda alls

## Beskrivning
`Program.cs` läser in ordlistan från `wordlists/swedish-engelska.csv`, men filen heter
`wordlists/swedish-english.csv`. Programmet kraschar därför direkt efter att listan med ordlistor har visats.

**Plats (när buggen hittades):** `Program.cs`, rad 20. Raden finns inte längre sedan UC4.

```csharp
string[] lines = File.ReadAllLines("wordlists/swedish-engelska.csv");
```

## Steg för att återskapa
1. Kör `dotnet run` i projektmappen.

## Förväntat resultat
Programmet visar listan med ordlistor och frågar sedan efter ett ord att översätta.

## Faktiskt resultat
```
Glosprogram
Tillgängliga ordlistor:
1. swedish-english
2. swedish-spanish
Unhandled exception. System.IO.FileNotFoundException: Could not find file 'C:\Code\Glosprogram\wordlists\swedish-engelska.csv'.
```

## Möjlig lösning
- **Snabbfix:** Ändra filnamnet på rad 20 till `swedish-english.csv`.
- **Långsiktigt:** I [UC4](../specs/UC4-valja-ordlista.md) ersätts det hårdkodade filnamnet med filen som användaren väljer
  ur listan. Då kan felet inte uppstå igen. Att programmet inte ska krascha när en fil saknas hör till
  [UC8](../specs/UC8-trasiga-filer.md).
