namespace APBD_Zadanie_2.Services;
using APBD_Zadanie_2.Enums;
using APBD_Zadanie_2.Domena;

class ObslugaWypozyczen
{
    private List<Wypozyczanie> _wypozyczenia = new();

    public void Wypozycz(Aktor aktor, Sprzet sprzet, int dni)
    {
        if (sprzet.Status != Stan.Dostępny)
            throw new Exception("Sprzęt niedostępny");

        int aktywneWypozyczenia = _wypozyczenia
            .Count(w => w.Aktor == aktor && w.DataZwrotu == null);

        if (aktywneWypozyczenia >= aktor.MaksymalnaLiczbaWypozyczen)
            throw new Exception($"Przekroczono limit wypożyczeń ({aktor.MaksymalnaLiczbaWypozyczen})");

        var wypozyczenie = new Wypozyczanie(aktor, sprzet, dni);
        _wypozyczenia.Add(wypozyczenie);
    }

    public decimal ZwrocSprzet(Wypozyczanie wypozyczenie)
    {
        wypozyczenie.Return();

        if (wypozyczenie.DataZwrotu > wypozyczenie.DataOczekiwanegoZwrotu)
        {
            int dniSpoznienia = (wypozyczenie.DataZwrotu.Value - wypozyczenie.DataOczekiwanegoZwrotu).Days;
            return dniSpoznienia * Konfiguracja.KaraZaDzien;
        }

        return 0;
    }

    public List<Wypozyczanie> AktywneWypozyczenia(Aktor aktor) =>
        _wypozyczenia.Where(w => w.Aktor == aktor && w.DataZwrotu == null).ToList();

    public List<Wypozyczanie> PrzeterminowaneWypozyczenia() =>
        _wypozyczenia.Where(w => w.DataZwrotu == null && DateTime.Now > w.DataOczekiwanegoZwrotu).ToList();

    public List<Wypozyczanie> WszystkieWypozyczenia() => _wypozyczenia.ToList();
}