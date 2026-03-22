using APBD_Zadanie_2.Domena;
using APBD_Zadanie_2.Enums;


var laptop = new Laptop("Dell XPS", 16, "Intel");
var lampa = new Lamp("Stojąca", "R-69 nie przemyślałem tego ale lecimy dalej", "Biała");
var projektor = new Projektor("Samsung nwm nie znam modeli", "1920x1080", "1:9");
var monitor = new MonitorR("Dell X-420", "2135x420", "21:37"); //Nazwa Monitor.cs sprawiała, że system próbuje się odwołać do System.Threading.Monitor, czymkolwiek to jest.

laptop.Status = Stan.Uszkodzony;
lampa.Status = Stan.Niedostępny;
projektor.Status = Stan.Wypożyczony;
monitor.Status = Stan.W_naprawie;

Console.WriteLine($"Laptop: {laptop.Nazwa}, RAM: {laptop.RamGb}GB, Status: {laptop.Status} ID: {laptop.Id}");
Console.WriteLine($"Lampa: {lampa.Nazwa}, Typ Gwinut: {lampa.TypGwintu}, Kolor: {lampa.Kolor}, Status: {lampa.Status}, ID: {lampa.Id}");
Console.WriteLine($"Projektor: {projektor.Nazwa}, Rodzielczość: {projektor.Rozdzeiczosc}, Ratio: {projektor.Ratio}, Status: {projektor.Status}, ID: {projektor.Id}");
Console.WriteLine($"Monitor: {monitor.Nazwa}, Rodzielczość: {monitor.Rozdzielczosc}, Ratio: {monitor.Ratio}, Status: {monitor.Status}, ID: {monitor.Id} ");