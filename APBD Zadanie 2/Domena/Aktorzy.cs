namespace APBD_Zadanie_2.Domena;

abstract class Aktor
    {
        public Guid Id { get; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

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

    public Student(string imie, string nazwisko, string numerIndeksu) : base(imie, nazwisko)
    {
        NumerIndeksu = numerIndeksu;
    }
}

