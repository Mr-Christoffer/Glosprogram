# UC10 – Översätta mellan engelska och spanska

**Som** användare **vill jag** kunna översätta mellan engelska och spanska, **så att** jag kan använda programmet
även när inget av språken är svenska.

## Lösningsalternativ
Det finns ingen ordlista `english-spanish.csv`. Det finns två sätt att lösa det:

| | A. Ny ordlistefil | B. Kombinera listor via ett gemensamt språk (rekommenderas) |
|---|---|---|
| Hur | Skapa `wordlists/english-spanish.csv` för hand | Programmet ser att `swedish-english` och `swedish-spanish` båda innehåller `swedish` och bygger `english-spanish` genom att para ihop ord med samma svenska ord (`katt,cat` + `katt,gato` → `cat,gato`) |
| Kodändring | Ingen, programmet är redan generiskt (UC3 och UC4) | Ja |
| Underhåll | Tre filer måste hållas i synk | Nya ord i de två listorna kommer med automatiskt |
| Lärande | Inget nytt C#-koncept | Nya koncept: `Join`, `Distinct` |

Alternativ B passar bäst med målet att språken ska bestämmas av de filer som finns: med N ordlistor som delar
ett språk får man fler språkpar utan att skapa några nya filer. Alternativ A kan användas som snabbfix.

## Acceptanskriterier
- [ ] Menyn visar `english-spanish` som ett val, gärna markerat som kombinerat, t.ex. `english-spanish (via swedish)`
- [ ] `cat` → `gato` och, med omvänd riktning (UC7), `gato` → `cat`
- [ ] Synonymer fungerar: `angry` → `enfadado` och `enojado`, `grande` → `big` och `large`
- [ ] Ingen översättning visas två gånger, även om flera svenska ord leder till samma par
- [ ] Ord som bara finns i den ena listan hoppas över utan krasch
- [ ] De vanliga ordlistorna (`swedish-english`, `swedish-spanish`) fungerar precis som förut
- [ ] Ingen ny `.csv`-fil har lagts till (gäller alternativ B)

## Bra att veta
- Översättningar via ett tredje språk kan bli lite missvisande. Svenska `stålar` (slang) ger `money` och `plata` (slang),
  så `money` → `dinero` och `plata` visas som om de vore lika neutrala. På samma sätt ger `boy` → `chico` och `chaval`.
  Det är en begränsning i metoden, inte ett fel i koden, och den bör nämnas i README.
- Med dagens ordlistor blir det 116 engelsk-spanska par och inga dubbletter. Kriteriet om dubbletter skyddar mot
  framtida ordlistor där t.ex. två svenska synonymer har samma engelska och spanska översättning.

## Koncept
LINQ `Join` (para ihop två listor på en gemensam nyckel), `Distinct`, anonyma typer eller tupler, `HashSet`
