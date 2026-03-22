using APBD_Zadanie_2.Domena;
using APBD_Zadanie_2.Enums;
using APBD_Zadanie_2.Services;

static void Wypozycz(ObslugaWypozyczen serwis, Aktor aktor, Sprzet sprzet, int dni)
{
    try
    {
        serwis.Wypozycz(aktor, sprzet, dni);
        string info = aktor switch
        {
            Student s => $"(indeks: {s.NumerIndeksu})",
            Pracownik p => $"(stanowisko: {p.Stanowisko})",
            _ => ""
        };
        Console.WriteLine($"Aktor {aktor.Id}, {aktor.Imie} {aktor.Nazwisko}, {info} wypożyczył {sprzet.Nazwa}, {sprzet.Id} na {dni} dni");
    }
    catch (Exception e)
    {
        Console.WriteLine($"BŁĄD - {e.Message}");
    }
}
static void Zwroc(ObslugaWypozyczen serwis, Aktor aktor, Sprzet sprzet)
{
    var wypozyczenie = serwis.AktywneWypozyczenia(aktor)
        .FirstOrDefault(w => w.Sprzet == sprzet);
    
    if (wypozyczenie == null)
    {
        Console.WriteLine($"Brak aktywnego wypożyczenia {sprzet.Nazwa} dla {aktor.Imie} {aktor.Nazwisko}");
        return;
    }

    decimal kara = serwis.ZwrocSprzet(wypozyczenie);
    Console.WriteLine($"Aktor {aktor.Id}, {aktor.Imie} {aktor.Nazwisko} zwrócił: {wypozyczenie.Sprzet.Nazwa}, kara: {kara} zł");
}

static void RaportKoncowy(ObslugaWypozyczen serwis, List<Sprzet> sprzet)
{
    var wszystkie = serwis.WszystkieWypozyczenia();
    var aktywne = wszystkie.Where(w => w.DataZwrotu == null).ToList();
    var zakonczone = wszystkie.Where(w => w.DataZwrotu != null).ToList();
    var przeterminowane = serwis.PrzeterminowaneWypozyczenia();

    Console.WriteLine("\nRaport:");
    Console.WriteLine($"Wszystkich wypożyczeń: {wszystkie.Count}");
    Console.WriteLine($"Aktywnych:             {aktywne.Count}");
    Console.WriteLine($"Zakończonych:          {zakonczone.Count}");
    Console.WriteLine($"Przeterminowanych:     {przeterminowane.Count}");

    Console.WriteLine("\nAktywne wypożyczenia:");
    foreach (var w in aktywne)
        Console.WriteLine($"  {w.Aktor.Imie} {w.Aktor.Nazwisko} - {w.Sprzet.Nazwa} (do {w.DataOczekiwanegoZwrotu:dd.MM.yyyy})");

    Console.WriteLine("\nStan sprzętu:");
    foreach (var s in sprzet)
        Console.WriteLine($"  {s.Nazwa}: {s.Status}");
}
var serwis = new ObslugaWypozyczen();


//Dodawanie obiektów
var laptop = new Laptop("Laptop Dell XPS", 16, "Intel");
var laptop2 = new Laptop("Laptop Dell XPS", 16, "Intel");
var lampa = new Lamp("Lampa stojąca", "R-69 nie przemyślałem tego, nie znam się na gwintach, ale lecimy dalej", "Biała");
var projektor = new Projektor("Projektor Samsung nwm nie znam modeli", "1920x1080", "1:9");
var monitor = new MonitorR("Monitor Dell X-420", "2135x420", "21:37"); //Nazwa Monitor.cs sprawiała, że system próbuje się odwołać do System.Threading.Monitor, czymkolwiek to jest.


var student = new Student("Jan", "Kowalski", "123456");
var student2 = new Student("Anna", "Nowak", "654321");
var pracownik = new Pracownik("Adam", "Wiśniewski", "Technik");


monitor.Status = Stan.W_naprawie;

Console.WriteLine($"Laptop: {laptop.Nazwa}, RAM: {laptop.RamGb}GB, Status: {laptop.Status} ID: {laptop.Id}");
Console.WriteLine($"Lampa: {lampa.Nazwa}, Typ Gwinut: {lampa.TypGwintu}, Kolor: {lampa.Kolor}, Status: {lampa.Status}, ID: {lampa.Id}");
Console.WriteLine($"Projektor: {projektor.Nazwa}, Rodzielczość: {projektor.Rozdzeiczosc}, Ratio: {projektor.Ratio}, Status: {projektor.Status}, ID: {projektor.Id}");
Console.WriteLine($"Monitor: {monitor.Nazwa}, Rodzielczość: {monitor.Rozdzielczosc}, Ratio: {monitor.Ratio}, Status: {monitor.Status}, ID: {monitor.Id} ");
Console.WriteLine();

Wypozycz(serwis, student, laptop, 7); //Wypożyczenie prawidłowe
Wypozycz(serwis, student, projektor, 3); //Wypożyczenie prawidłowe
Wypozycz(serwis, pracownik, monitor, 14); //próba wypożeczenia sprzętu o innej dostepności niż "dostępny"
Wypozycz(serwis, student, laptop2, 3); //próba przekroczenia limitu dla swojej kategorii
Console.WriteLine();

Zwroc(serwis, student, laptop); //prawidłowy zwrot

Wypozycz(serwis, pracownik, laptop, -10); //Symulacja opóźnienionych
Wypozycz(serwis, pracownik, laptop2, -10); 
Zwroc(serwis, pracownik, laptop); 



Console.WriteLine();
RaportKoncowy(serwis, new List<Sprzet> { laptop, laptop2, projektor, monitor, lampa });

