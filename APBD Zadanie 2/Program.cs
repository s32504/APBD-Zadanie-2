using APBD_Zadanie_2.Domena;


var laptop = new Laptop("Dell XPS", 16, "Intel");

Console.WriteLine($"Laptop: {laptop.Nazwa}, RAM: {laptop.RamGb}GB, Status: {laptop.Status} ID: {laptop.Id}");