# Glosprogram

Ett konsolprogram i C# som översätter ord med hjälp av ordlistor. Vilka språk som finns att välja
bestäms av ordlistorna i mappen `wordlists/`. Just nu finns svenska → engelska och svenska → spanska.

## Krav
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Starta programmet
Öppna en terminal i projektmappen och kör:

```
dotnet run
```

Programmet måste startas från projektmappen, eftersom ordlistorna läses från `wordlists/` relativt den mapp du står i.

## Användning
1. Programmet visar en numrerad lista med tillgängliga ordlistor.
2. Skriv numret på den ordlista du vill använda och tryck Enter.
   Om du skriver något som inte är ett nummer i listan visas `Ogiltigt val, försök igen.` och du får välja igen.
3. Programmet frågar: `Ange vilket ord du vill översätta`
4. Skriv ett ord på det första språket i ordlistan (t.ex. svenska) och tryck Enter.
5. Programmet skriver ut översättningen och frågar efter nästa ord.

Exempel:

```
Glosprogram
Tillgängliga ordlistor:
1. swedish-english
2. swedish-spanish
Välj ordlista (1-2):
5
Ogiltigt val, försök igen.
Välj ordlista (1-2):
2
Ange vilket ord du vill översätta
katt
gato
Ange vilket ord du vill översätta
glad
feliz
alegre
Ange vilket ord du vill översätta
xyz
This word does not exist in this dictionary
```

- Stora och små bokstäver spelar ingen roll: `HUND` och `hund` ger samma svar.
- Ord med flera översättningar (synonymer) skriver ut alla översättningarna, en per rad.
- För att byta ordlista måste du avsluta och starta programmet igen.

## Avsluta
Tryck **Ctrl+C**. Programmet har inget eget kommando för att avsluta.

## Ordlistor
Ordlistorna är `.csv`-filer i mappen `wordlists/`. De visas i menyn i bokstavsordning, med filnamnet utan `.csv`.
Filens format:

```
swedish,english
katt,cat
hund,dog
stor,big
stor,large
```

- Första raden är en rubrik med språkens namn. Den läses inte in som ett ord.
- Varje rad efter rubriken innehåller ett ordpar: ordet att översätta, ett kommatecken och översättningen.
- Lägg till fler rader med samma ord för att lägga till synonymer.
- Skriv inga mellanslag runt kommatecknet.
- Spara filen som UTF-8 så att tecken som å, ä, ö och ñ fungerar.

### Lägga till ett nytt språk
Skapa en ny fil i `wordlists/`, t.ex. `swedish-german.csv`, med rubriken `swedish,german` och ett ordpar per rad.
Den nya ordlistan syns i menyn nästa gång programmet startas. Koden behöver inte ändras.

## Begränsningar i nuvarande version
- Översättningen går bara åt ett håll: från det första språket i rubriken till det andra.
- **Ctrl+Z** (slut på inmatning) i menyn avslutar programmet, men vid ordfrågan får det programmet att krascha.
- En rad i en ordlista utan kommatecken får programmet att krascha när ordlistan läses in.
- En tom ordlista, eller en rubrik utan kommatecken (t.ex. bara `swedish`), får programmet att krascha när ordlistan väljs.
- Om mappen `wordlists/` saknas kraschar programmet vid start. Om mappen är tom går det inte att göra något giltigt val.

Planerade förbättringar finns beskrivna som use cases i [specs/](specs/README.md). Kända buggar finns i [bugs/](bugs/README.md).
