namespace APBD_Zadanie_2.Domena;

class Lamp : Sprzet
{
    public string TypGwintu { get; set; }
    public string Kolor { get; set; }
    
    public Lamp(string nazwa, string typGwintu, string kolor) : base (nazwa)
    {
        TypGwintu = typGwintu;
        Kolor = kolor;
    }
}