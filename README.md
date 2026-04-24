
# Projekt pro ETE15E - Programování

## Vytvořil: František Saidl <xsaif003@studenti.czu.cz>

## Název: Správce hudební knihovny

## Popis

Konzolová aplikace pro správu hudební knihovny. Uživatel může přidávat skladby, načítat je ze souboru, zobrazovat seznam, třídit a mazat. Aplikace podporuje angličtinu, češtinu a augur. Data se ukládají do JSON souboru.

## Návrh hlavních proměnných a datových struktur

- **tracks** – seznam typu List obsahující všechny načtené skladby
- **defaultFilePath** – cesta k výchozímu souboru knihovny ([Hudba]/AudioLib/library.json)
- **CurrentLanguage** – vybraný jazyk aplikace ("en", "cs", "au")

## Koncepční popis programu

1. Přidat novou skladbu – zadání názvu, autora a BPM
2. Načíst skladby ze souboru – importování z JSON souboru
3. Zobrazit všechny skladby – seznam v tabulkovém formátu
4. Třídit skladby – podle názvu, autora nebo BPM
5. Smazat skladbu – s potvrzením uživatele
6. Změnit jazyk – výběr z dostupných jazyků
7. Ukončit – uložení a zavření aplikace

## Vstupní omezení

- Název a autor: max. 50 znaků
- BPM: 0-300
- Cesta k souboru musí existovat

## AI

Následující funkce byly vytvořeny s pomocí **GitHub Copilot Chat**:

| Funkce | Prompt |
|--------|--------|
| `GetLimitedStringInput()` | "Design a function for getting limited string input" |
| `GetFilePathInput()` | "Design a function to check for file existence" |
| `GetIntInput()` | "Design a function that can do both a normal int input and limited int input" |
