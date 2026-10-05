# UC5 – Generiska namn och texter

**Som** användare **vill jag** att texterna visar vilka språk jag översätter mellan, **så att** jag vet vad jag ska skriva.

## Acceptanskriterier
- [x] Ledtexten visar t.ex. "Ange ett ord på swedish:"
- [x] `swedishToEnglish` har bytt namn till något neutralt
- [x] Alla texter till användaren är på svenska, även "This word does not exist in this dictionary"

### Kodstil enligt CLAUDE.md
- [x] `System.Console` är ersatt med `Console`
- [x] Lambda-parametern `Word =>` heter något med liten bokstav, t.ex. `word =>`
- [x] LINQ-kedjan har punkten först på varje rad
- [x] Den utkommenterade gamla koden (`//System.Console.WriteLine(words[1].WordOut);`) är borttagen

## Koncept
Stränginterpolering `$"..."`, bra namngivning, konsekvent kodstil
