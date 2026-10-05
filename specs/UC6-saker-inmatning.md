# UC6 – Säker inmatning och avslut

**Som** användare **vill jag** kunna avsluta programmet snyggt och inte få en krasch vid tom eller avbruten inmatning.

## Acceptanskriterier
- [ ] Tom rad eller null (Ctrl+Z) kraschar inte
- [ ] Kommandot `q` avslutar programmet
- [ ] `!` (null-forgiving) behövs inte längre

## Koncept
`string.IsNullOrWhiteSpace`, `TryGetValue`, `break`
