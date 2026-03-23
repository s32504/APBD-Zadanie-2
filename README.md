Opis programu:

Warstwa domenowa (Domena):

Zawiera wyłącznie model danych, klasy reprezentujące rzeczywiste byty systemu (Aktorów, wyposażenie etc.). Nie zawiera logiki biznesowej ani odwołań do UI. Dzięki temu model jest niezależny od sposobu jego użycia.
Warstwa serwisów (Services)
Dwie klasy o wyraźnie rozdzielonych odpowiedzialnościach:
>Wypozyczanie przechowuje dane o pojedynczym wypożyczeniu i obsługuje zwrot przez Return(). Przy tworzeniu automatycznie ustawia status sprzętu na Wypożyczony, przy zwrocie przywraca Dostępny. 
>Obsługa Wypożyczeń zarządza listą wypożyczeń, waliduje operacje (dostępność sprzętu, limity użytkowników), nalicza kary. Udostępnia metody zapytań: AktywneWypozyczenia, PrzeterminowaneWypozyczenia, WszystkieWypozyczenia.
 
Konfiguracja (Konfiguracja.cs):

Stałe biznesowe (Maksymalne ilości wypożyczeń, wysokość kary) zebrane w jednym miejscu, plik umieszczony w głównym namespace'ie, aby uniknąć cyklicznych zależności między Domena a Services.

UI (Program.cs):

Odpowiada wyłącznie za prezentację. Metody pomocnicze eliminują powtarzający się kod. >Wypozycz wywołuje serwis i obsługuje wyjątki  
>Zwroc wyszukuje aktywne wypożyczenie i wywołuje zwrot 
>RaportKoncowy wypisuje pełne podsumowanie stanu systemu 

Kohezja:

Każda klasa ma jedną wyraźną odpowiedzialność. Wypozyczanie przechowuje dane wypożyczenia i logikę zmiany statusu sprzętu, ObslugaWypozyczen zajmuje się walidacją i wykonywaniem operacji na kolekcji wypożyczeń Konfiguracja przechowuje globalne stałe biznesowe, a Aktor i Sprzet są czyste modele domenowe bez logiki operacyjnej 

Coupling:

Zależności są jednostronne. Domena nie zna Services. Services nie zna Program.cs. Dzięki temu zmiana UI nie wymaga modyfikacji logiki biznesowej i odwrotnie.
Dziedziczenie wynikające z modelu domeny
>Student i Pracownik dziedziczą po abstrakcyjnym Aktor, różnią się limitem wypożyczeń (MaksymalnaLiczbaWypozyczen jako właściwość abstrakcyjna) oraz atrybutami (NumerIndeksu, Stanowisko). ObslugaWypozyczen nie sprawdza typu aktora — pyta aktor.MaksymalnaLiczbaWypozyczen, co jest przykładem polimorfizmu. 
>Laptop, Projektor, MonitorR, Lampa dziedziczą po abstrakcyjnym Sprzet — mają wspólny Status i Nazwę, ale różne atrybuty techniczne.

Obsługa błędów:

Operacje które mogą się nie powieść (Wypozycz) rzucają wyjątki z czytelnymi komunikatami. UI łapie je lokalnie w metodach pomocniczych, nie przerywając działania całego scenariusza.


Uruchomienie programu:

Jest bardzo proste, wystarczy uruchomić Program.cs.
