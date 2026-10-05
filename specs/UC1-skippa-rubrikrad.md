# UC1 – Rubrikraden ska inte bli ett ord

**Som** användare **vill jag** att rubrikraden i filen inte räknas som ett ord, **så att** jag bara får riktiga översättningar.

## Acceptanskriterier
- [x] Skriver jag "swedish" får jag "Ordet finns inte i ordlistan." (före UC5: "This word does not exist…")
- [x] Alla riktiga ord fungerar som förut

## Koncept
`File.ReadAllLines` till en variabel, `.Skip(1)`
