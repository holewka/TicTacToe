using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _71579_G3_ProjektZaliczeniowy
{
    // klasa reprezentująca jednego gracza (człowieka lub komputer)
    public class Gracz
    {
        // Właściwość tylko do odczytu – imię gracza
        public string Nazwa { get; }

        // znak przypisany graczowi (np. "X" lub "O")
        public string Znak { get; }

        // punkty zdobyte przez gracza – można tylko zwiększać (private set)
        public int Punkty { get; private set; }

        // konstruktor przyjmuje nazwę i znak gracza
        public Gracz(string nazwa, string znak)
        {
            Nazwa = nazwa;
            Znak = znak;
            Punkty = 0;
        }

        // metoda zwiększająca liczbę punktów
        public void DodajPunkt()
        {
            Punkty++;
        }
    }
}
