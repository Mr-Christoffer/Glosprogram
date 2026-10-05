# UC6 – Säker inmatning och avslut

**Som** användare **vill jag** kunna avsluta programmet snyggt och inte få en krasch när inmatningen avbryts.

## Acceptanskriterier
- [ ] null (Ctrl+Z) vid ordfrågan kraschar inte (en tom rad kraschar redan inte idag)
- [ ] Kommandot `q` avslutar programmet
- [ ] `!` (null-forgiving) behövs inte längre

## Koncept
`string.IsNullOrWhiteSpace`, `TryGetValue`, `break`
