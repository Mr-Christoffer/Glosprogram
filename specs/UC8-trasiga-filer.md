# UC8 – Tåla trasiga filer

**Som** användare **vill jag** att programmet klarar en tom mapp eller felaktiga rader, **så att** det inte kraschar på grund av en dålig fil.

## Acceptanskriterier
- [ ] Tom eller saknad mapp ger ett tydligt meddelande
- [ ] Rader med fel antal kolumner hoppas över (gärna med en varning)
- [ ] Mellanslag runt orden tas bort (`"katt, cat"` fungerar)
- [ ] En tom fil ger ett tydligt meddelande istället för krasch (idag: `IndexOutOfRangeException` på `lines[0]`)
- [ ] En rubrik utan kommatecken (t.ex. `swedish`) ger ett tydligt meddelande istället för krasch (idag: `IndexOutOfRangeException` på `languages[1]`)

## Koncept
`Directory.Exists`, `.Length`-kontroll, `.Trim()`
