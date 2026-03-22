namespace APBD_Zadanie_2.Domena;
using APBD_Zadanie_2.Services;

abstract class Aktor
{
    public Guid Id { get; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public abstract int MaksymalnaLiczbaWypozyczen { get; }

    protected Aktor(string imie, string nazwisko)
    {
        Id = Guid.NewGuid();
        Imie = imie;
        Nazwisko = nazwisko;
    }
}

class Student : Aktor
{
    public string NumerIndeksu { get; set; }
    public override int MaksymalnaLiczbaWypozyczen => Konfiguracja.LimitStudenta;

    public Student(string imie, string nazwisko, string numerIndeksu) : base(imie, nazwisko)
    {
        NumerIndeksu = numerIndeksu;
    }
}

class Pracownik : Aktor
{
    public string Stanowisko { get; set; }
    public override int MaksymalnaLiczbaWypozyczen => Konfiguracja.LimitPracownika;

    public Pracownik(string imie, string nazwisko, string stanowisko) : base(imie, nazwisko)
    {
        Stanowisko = stanowisko;
    }
}