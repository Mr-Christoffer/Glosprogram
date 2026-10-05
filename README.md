# Glosprogram

Ett konsolprogram i C# som översätter ord från svenska till engelska med hjälp av en ordlista.

## Krav
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Starta programmet
Öppna en terminal i projektmappen och kör:

```
dotnet run
```

Programmet måste startas från projektmappen, eftersom ordlistan läses från `wordlists/` relativt den mapp du står i.

## Användning
1. Programmet frågar: `Ange vilket ord du vill översätta`
2. Skriv ett svenskt ord och tryck Enter.
3. Programmet skriver ut den engelska översättningen och frågar efter nästa ord.

Exempel:

```
Glosprogram
Ange vilket ord du vill översätta
katt
cat
Ange vilket ord du vill översätta
stor
big
large
Ange vilket ord du vill översätta
xyz
This word does not exist in this dictionary
```

- Stora och små bokstäver spelar ingen roll: `HUND` och `hund` ger samma svar.
- Ord med flera översättningar (synonymer) skriver ut alla översättningarna, en per rad.

## Avsluta
Tryck **Ctrl+C**. Programmet har inget eget kommando för att avsluta.

## Ordlistan
Orden läses från `wordlists/swedish-english.csv`. Filens format:

```
swedish,english
katt,cat
hund,dog
stor,big
stor,large
```

- Första raden är en rubrik med språkens namn. Den läses inte in som ett ord.
- Varje rad efter rubriken innehåller ett ordpar: det svenska ordet, ett kommatecken och det engelska ordet.
- Lägg till fler rader med samma svenska ord för att lägga till synonymer.
- Skriv inga mellanslag runt kommatecknet.

## Begränsningar i nuvarande version
- Bara ordlistan `swedish-english.csv` används, och bara åt hållet svenska → engelska.
- **Ctrl+Z** (slut på inmatning) får programmet att krascha.
- En rad i ordlistan utan kommatecken får programmet att krascha vid start.

Planerade förbättringar finns beskrivna som use cases i [specs/](specs/README.md).
