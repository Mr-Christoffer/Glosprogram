# Use cases – Glosprogram

Målet är att göra programmet generiskt: vilka språk som går att översätta mellan bestäms av filerna i `wordlists/`.
Ta ett use case i taget, i ordning. Testa acceptanskriterierna med `dotnet run`, bocka av dem och committa innan du går vidare.

| UC | Beskrivning | Status |
|----|-------------|--------|
| [UC1](UC1-skippa-rubrikrad.md) | Rubrikraden ska inte bli ett ord | ✅ |
| [UC2](UC2-sprak-fran-fil.md) | Språken läses från filen | ✅ |
| [UC3](UC3-hitta-ordlistor.md) | Hitta tillgängliga ordlistor | ✅ |
| [UC4](UC4-valja-ordlista.md) | Välja ordlista | ✅ |
| [UC5](UC5-generiska-namn.md) | Generiska namn och texter | ✅ |
| [UC6](UC6-saker-inmatning.md) | Säker inmatning och avslut | ✅ |
| [UC7](UC7-bada-hallen.md) | Översätta åt båda hållen | ✅ |
| [UC8](UC8-trasiga-filer.md) | Tåla trasiga filer | ⬜ |
| [UC9](UC9-metod-for-inlasning.md) | (bonus) Läsa in ordlistan i en metod | ⬜ |
| [UC10](UC10-engelska-spanska.md) | Översätta mellan engelska och spanska | ⬜ |
