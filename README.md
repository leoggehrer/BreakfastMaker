Übung:
------

**Lernziele der Aufgaben Teil A:** 
- Den Unterschied zwischen synchrone und asynchrone Abarbeitung verstehen.
- Die Programmierkonzepte async und await anwenden können.
- Die Anwendung von Task.WhenAny(...) verstehen und erklären können.
- Die Anwendung von Task.WhenAll(...) verstehen und erklären können.

**Lernziele der Aufgaben Teil B:** 
- Den Unterschied zwischen synchrone und asynchrone Abarbeitung erklären und analysieren können.

## BreakfastMaker
## Teil A
### Grundsystem

**BreakfastMaker** Erstellen Sie die Projektstruktur von *BreakfastMaker* und fassen Sie die einzelnen Projekte zu einer Solution zusammen. Die Struktur besteht aus den Projekten:

|Name|Beschreibung|
|---|---|
|BreakfastMaker.Common|In diesem Projekt sind die gemeinsamen Klassen wie Coffee, Egg, Pan usw. implementiert.|
|SyncBreakfastMaker.Logic|In diesem Projekt befinden sich die Klasse Breakfast für die synchrone Zubereitung des Frühstücks.|
|AsyncBreakfastMaker.Logic|In diesem Projekt befinden sich die Klasse Breakfast für die asynchrone Zubereitung des Frühstücks.|
|BreakfastMaker.ConApp|Eine Konsolen-Anwendung zum Starten der synchronen und asynchronen Zubereitung des Frühstücks.|

Verbinden Sie die Abhängigkeiten der einzelnen Projekte untereinander.

**Zubereitung des Frühstücks** 

In der folgenden Tabelle sind die einzelnen Schritte für die Zubereitung des Frühstücks beschrieben:

|Nr.|Name|Beschreibung|Ausgabe|Zeit|
|---|---|---|---|
|1.|*Coffee PourCoffee()*|Gießt den Kaffee in eine Tasse ein.|Pouring coffee...Coffee is already|1 sec.|
|2.|*Pan HeatPan()*|Erhitzt eine Pfanne.|Heating pan...Pan is already|10 sec.|
|3.|*Egg[] FryEggs(Pan pan, int count)*|Braten von Eiern z.B.: 2|Frying egg...Eggs are already|10 sec. pro Ei|
|4.|*Bacon[] FryBacon(Pan pan, int count)*|Braten von Speckstreifen z.B.: 2|Frying bacon...Bacons are already|10 sec. pro Speckstreifen|
|5.|*Toast[] ToastBread(int count)*|Toasten von Brot z.B.: 2|Toasting bread...Breads are already|10 sec. pro Toastbrot|
|6.|*void ApplyButter(Toast[] toasts)*|Bestreichen der Toastbrote mit Butter z.B.: 2|Brush bread with butter...Breads have butter|1 sec. pro Toastbrot|
|7.|*void ApplyJam(Toast[] toasts)*|Bestreichen der Toastbrote mit Marmelade z.B.: 2|Brush bread with jam... Breads have jam|1 sec. pro Toastbrot|
|8.|*Juice PourJuice()*|Gießt den Saft in ein Glas ein.|Pouring juice...Juice is already|1 sec.|

**Synchrone Zubereitung des Frühstücks** 

Simulieren Sie nun in einem Programm die synchrone Zubereitung des Frühstücks und geben Sie die benötigte Zeit in Sekunden an. Die Zubereitungsfolge können Sie aus der Nummerierung ableiten.

**Asynchrone Zubereitung des Frühstücks** 

Simulieren Sie nun in einem Programm die asynchrone Zubereitung des Frühstücks und geben Sie die benötigte Zeit in Sekunden an. Die Zubereitungsfolge können Sie aus der Nummerierung ableiten.

## Teil B

Beschreiben Sie in einem Dokument (AsyncAwait.md) die Eigenschaften, die Vorteile und die Nachteile der synchronen und asynchronen Programmierung. 

## Hilfsmitteln
-   https://docs.microsoft.com/de-de/dotnet/csharp/

## Abgabe
-   Termin: 1 Woche nach der Ausgabe

-   Klasse:

-   Name:

## Quellen
-  https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/async/

# 
<center> **Viel Erfolg!** </center>
