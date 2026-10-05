# Prompthistorik – Glosprogram

Sessionen ägde rum 2026-10-05 med Claude Opus 5.5 (`claude-opus-5-5`) i Claude Code.
Prompterna är återgivna ordagrant. Under varje prompt står kort vad som blev resultatet.

---

### 1
> kan du se var i koden jag behöver ändra för att den ska bli generisk i betydelsen att språk för översättningar bestäms av tillgängliga översättningsfiler i wordlists

**Resultat:** Genomgång av `Program.cs`. Jag pekade ut tre ställen: det hårdkodade filnamnet, de hårdkodade språken och variabelnamnet `swedishToEnglish`. Jag upptäckte också att rubrikraden lästes in som ett ord, och tog upp null-fällan med `!`.

### 2
> jag vill att du skapar en lista på ändringar vi kan göra stegvis, en i taget, som UseCases

**Resultat:** Nio use cases (UC1–UC9), var och en med acceptanskriterier och koncept.

### 3
> kan du läsa igenom koden, och spara en system prompt som beskriver kodstandarden vi har tillämpat.

**Resultat:** `CLAUDE.md` skapades med kodstandard och arbetssätt.

### 4
> Våra Use Cases, kan du spara dem i en mapp "specs"

**Resultat:** Mappen `specs/` skapades med en fil per use case och en översikt i `specs/README.md`.

### 5
> kan du skriva i System prompten vilken modell du använder just nu

**Resultat:** Avsnittet "AI-modell" lades till i `CLAUDE.md`.

### 6
> kan du generera UC1 och markera med kommentarer vad du har gjort för förändringar

**Resultat:** UC1 implementerades med `lines.Skip(1)` och `// UC1:`-kommentarer. Testet kunde inte köras eftersom `Word.cs` var tom på disk.

### 7
> kör

**Resultat:** Testet visade att rubrikraden hade tagits bort ur CSV-filen, så `Skip(1)` hoppade över `katt`.

### 8
> lägg tillbaka rubriken. Sedan skriv i readme en manual för så som programet är nu

**Resultat:** Rubriken lades tillbaka och UC1 verifierades och bockades av. En användarmanual skrevs i `README.md`.

### 9
> gör nu UC2 också på samma sätt

**Resultat:** UC2 implementerades: språken läses från rubriken. Det verifierades i en tillfällig kopia där rubriken var `svenska,engelska`.

### 10
> kan du skapa en version av wordlist somm är mellan svenska och spanska med samma ord

**Resultat:** `wordlists/swedish-spanish.csv` skapades med samma 74 svenska ord och 98 ordpar.

### 11
> kör UC 3

**Resultat:** UC3 implementerades: ordlistorna listas med nummer via `Directory.GetFiles` och `Array.Sort`. Programmet kraschade efter listan, eftersom filnamnet hade ändrats till `swedish-engelska.csv`.

### 12
> kan du lägga buggrapportet i bugs

**Resultat:** Mappen `bugs/` skapades med `BUG1` och en översikt. Buggen markerades som löst efter att filnamnet rättats för hand.

### 13
> kör UC4

**Resultat:** UC4 implementerades: ordlistan väljs med `int.TryParse` i en valideringsloop, och null-hantering lades till i menyn. Manualen i `README.md` uppdaterades.

### 14
> utifrån en jämförelse mellan specs, readme och programmet. är det något du inte har paritet med

**Resultat:** Jämförelsen hittade avvikelser i `CLAUDE.md` mot koden, i specs mot verkligheten, i README, i BUG1, och att ändringar inte var committade.

### 15
> kan du åtgörda dessa partitetsdifferanser

**Resultat:** Följande uppdaterades: `CLAUDE.md` (klasser i egna filer), UC4, UC5 (kodstil och svenska texter), UC6 (rättat kriterium), UC8 och README (tom fil och felaktig rubrik), samt BUG1.

### 16
> kan du spara vår prompt history i prompt_history.md

**Resultat:** Den här filen.

### 17
> vilka två ord saknas från den spanska listan? och varför?

**Resultat:** Inga svenska ord saknas. Det är två synonymrader som saknas, `stor,large` och `liten,little`, eftersom spanskan inte har någon naturlig andra översättning: *grande* och *pequeño* täcker båda betydelserna.

### 18
> ok. men uppdatera prompt_history automatiskt från och med nu

**Resultat:** En `UserPromptSubmit`-hook lades till i `.claude/settings.json`. Den kör `.claude/hooks/log_prompt.py`, som lägger till varje ny prompt här automatiskt. Claude fyller i resultatraden efter varje svar enligt `CLAUDE.md`.

### 19
> kör uc5-uc7

**Resultat:** UC5–UC7 implementerades och testades. UC5: neutrala namn, ledtext med språk, svenska texter och kodstil enligt CLAUDE.md. UC6: `q` och Ctrl+Z avslutar, tom rad frågar igen, `TryGetValue` istället för `!`. UC7: val av översättningsriktning, och synonymer fungerar åt båda hållen. Hooken rensar nu bort VS Code-taggar som `<ide_opened_file>`. README och specs uppdaterades.
