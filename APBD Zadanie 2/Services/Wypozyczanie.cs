namespace APBD_Zadanie_2.Services;
using APBD_Zadanie_2.Domena;
using APBD_Zadanie_2.Enums;

class Wypozyczanie
{
    public Aktor Aktor { get; }
    public Sprzet Sprzet { get; }
    public DateTime DataWypozyczenia { get; }
    public DateTime DataOczekiwanegoZwrotu { get; }
    public DateTime? DataZwrotu { get; private set; }

    public Wypozyczanie(Aktor aktor, Sprzet sprzet, int days)
    {
        Aktor = aktor;
        Sprzet = sprzet;
        DataWypozyczenia = DateTime.Now;
        DataOczekiwanegoZwrotu = DataWypozyczenia.AddDays(days);

        Sprzet.Status = Stan.Wypożyczony;
    }
    public void Return()
    {
        DataZwrotu = DateTime.Now;
        Sprzet.Status = Stan.Dostępny;
    }
}