# UC6 – Säker inmatning och avslut

**Som** användare **vill jag** kunna avsluta programmet snyggt och inte få en krasch när inmatningen avbryts.

## Acceptanskriterier
- [x] null (Ctrl+Z) vid ordfrågan kraschar inte (en tom rad kraschar redan inte idag)
- [x] Kommandot `q` avslutar programmet
- [x] `!` (null-forgiving) behövs inte längre

## Koncept
`string.IsNullOrWhiteSpace`, `TryGetValue`, `break`
