using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _71579_G3_ProjektZaliczeniowy
{
            // klasa łącząca wszystkie elementy gry – graczy i planszę
    public class Gra
    {
        // obiekt reprezentujący gracza
        public Gracz Gracz { get; private set; }

            // obiekt reprezentujący komputer
        public Gracz Komputer { get; private set; }

        // obiekt planszy
        public Plansza Plansza { get; private set; }

        // generator losowy do ruchów komputera
        private readonly Random losuj = new Random();

        // konstruktor – tworzy gracza, komputer i planszę
        public Gra()
        {
            Gracz = new Gracz("Gracz", "X");
            Komputer = new Gracz("Komputer", "O");
            Plansza = new Plansza(10);
        }

        // wykonuje ruch gracza – zwraca true, jeśli się udało
        public bool RuchGracza(int x, int y)
        {
            return Plansza.UstawPole(x, y, Gracz.Znak);
        }

        // wykonuje ruch komputera – losowe wolne pole
        public bool RuchKomputera(out int x, out int y)
        {
            for (int i = 0; i < 1000; i++)
            {
                x = losuj.Next(Plansza.Rozmiar);
                y = losuj.Next(Plansza.Rozmiar);

                if (Plansza.UstawPole(x, y, Komputer.Znak))
                    return true;
            }

            // nie znaleziono pola
            x = -1;
            y = -1;
            return false;
        }

        // sprawdza, czy dany znak wygrał
        public bool CzyWygrana(string znak)
        {
            return Plansza.SprawdzWygrana(znak);
        }

        // sprawdza remis
        public bool CzyRemis()
        {
            return Plansza.CzyRemis();
        }

        // resetuje grę 
        public void ResetujGre()
        {
            Plansza.Resetuj();
        }
    }
}

