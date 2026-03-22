using APBD_Zadanie_2.Domena;

class Projektor : Sprzet
{
    public string Rozdzeiczosc {get; set;}
    public string Ratio {get; set;}

    public Projektor(string nazwa, string rozdzeiczosc, string ratio) : base(nazwa)
    {
        Rozdzeiczosc = rozdzeiczosc;
        Ratio = ratio;
        
    }  
}