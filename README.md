# Glosprogram

Ett konsolprogram i C# som översätter ord åt båda hållen med hjälp av ordlistor. Vilka språk som finns att välja
bestäms av ordlistorna i mappen `wordlists/`. Just nu finns svenska ↔ engelska och svenska ↔ spanska.

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
3. Välj översättningsriktning: `1` översätter från det första språket i ordlistan till det andra
   (t.ex. swedish -> spanish), `2` översätter åt andra hållet (t.ex. spanish -> swedish).
4. Programmet frågar efter ett ord och visar vilket språk det ska skrivas på, t.ex. `Ange ett ord på swedish:`
5. Skriv ett ord och tryck Enter. Programmet skriver ut översättningen och frågar efter nästa ord.

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
Översättningsriktningar:
1. swedish -> spanish
2. spanish -> swedish
Välj riktning (1-2):
1
Skriv q för att avsluta.
Ange ett ord på swedish:
katt
gato
Ange ett ord på swedish:
glad
feliz
alegre
Ange ett ord på swedish:
xyz
Ordet finns inte i ordlistan.
Ange ett ord på swedish:
q
Hej då!
```

- Stora och små bokstäver spelar ingen roll: `HUND` och `hund` ger samma svar.
- Ord med flera översättningar (synonymer) skriver ut alla översättningarna, en per rad. Det fungerar åt båda hållen,
  t.ex. ger `angry` både `arg` och `ilsken`.
- En tom rad gör att programmet frågar igen.
- För att byta ordlista eller riktning måste du avsluta och starta programmet igen.

## Avsluta
Skriv **q** och tryck Enter när programmet frågar efter ett ord. Programmet skriver då `Hej då!` och avslutas.
**Ctrl+Z** följt av Enter (slut på inmatning) avslutar också programmet, i alla lägen.

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
- Varje rad efter rubriken innehåller ett ordpar: ordet på det första språket, ett kommatecken och ordet på det andra språket. Samma rad används för båda översättningsriktningarna.
- Lägg till fler rader med samma ord för att lägga till synonymer.
- Skriv inga mellanslag runt kommatecknet.
- Spara filen som UTF-8 så att tecken som å, ä, ö och ñ fungerar.

### Lägga till ett nytt språk
Skapa en ny fil i `wordlists/`, t.ex. `swedish-german.csv`, med rubriken `swedish,german` och ett ordpar per rad.
Den nya ordlistan syns i menyn nästa gång programmet startas. Koden behöver inte ändras.

## Begränsningar i nuvarande version
- En rad i en ordlista utan kommatecken får programmet att krascha när ordlistan läses in.
- En tom ordlista, eller en rubrik utan kommatecken (t.ex. bara `swedish`), får programmet att krascha när ordlistan väljs.
- Om mappen `wordlists/` saknas kraschar programmet vid start. Om mappen är tom går det inte att göra något giltigt val.
- Ordet `q` (eller `Q`) går inte att översätta, eftersom det avslutar programmet.

Planerade förbättringar finns beskrivna som use cases i [specs/](specs/README.md). Kända buggar finns i [bugs/](bugs/README.md).
