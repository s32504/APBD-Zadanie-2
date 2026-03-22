namespace APBD_Zadanie_2.Domena;

class Laptop : Sprzet
{
    public int RamGb { get; set; }
    public string Cpu { get; set; }

    public Laptop(string nazwa, int ram, string cpu) : base (nazwa)
    {
        RamGb = ram;
        Cpu = cpu;
    }
}