namespace APBD_Zadanie_2.Domena;

class MonitorR : Sprzet
{
    public string Rozdzielczosc {get; set;}
    public string Ratio {get; set;}

    public MonitorR(string nazwa, string rozdzielczosc, string ratio) : base(nazwa)
    {
        Rozdzielczosc = rozdzielczosc;
        Ratio = ratio;
        Nazwa = nazwa;
    }
}