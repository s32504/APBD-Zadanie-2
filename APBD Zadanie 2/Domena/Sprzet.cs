using APBD_Zadanie_2.Enums;

namespace APBD_Zadanie_2.Domena;

abstract class Sprzet
{
    public Guid Id { get; }
    public string Nazwa { get; set; }
    public Stan Status { get; set; }

    protected Sprzet(string nazwa)
    {
        Nazwa = nazwa;
        Id = Guid.NewGuid();
        Status = Stan.Dostępny;
    }
}