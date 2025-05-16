using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _71579_G3_ProjektZaliczeniowy
{
    // klasa zarządzająca logiką planszy 10x10 
    public class Plansza
    {
        // dwuwymiarowa tablica reprezentująca pola planszy
        private readonly string[,] pola;

        // właściwość przechowująca rozmiar planszy (np. 10)
        public int Rozmiar { get; }

        // konstruktor – tworzy planszę o zadanym rozmiarze i resetuje ją
        public Plansza(int rozmiar)
        {
            Rozmiar = rozmiar;
            pola = new string[rozmiar, rozmiar];
            Resetuj();
        }

        // przypisuje znak do pola, jeśli jest ono wolne
        public bool UstawPole(int x, int y, string znak)
        {
            if (pola[x, y] != "?") return false; // jeśli zajęte – zwróć false
            pola[x, y] = znak;
            return true;
        }

        // zwraca znak znajdujący się na danym polu
        public string PobierzPole(int x, int y) => pola[x, y];

        // sprawdza, czy wszystkie pola są zajęte – remis
        public bool CzyRemis()
        {
            foreach (var pole in pola)
                if (pole == "?") return false;
            return true;
        }

        // sprawdza, czy dany znak ułożył linię 6 elementów
        public bool SprawdzWygrana(string znak)
        {
            for (int x = 0; x < Rozmiar; x++)
            {
                for (int y = 0; y < Rozmiar; y++)
                {
                    if (pola[x, y] == znak)
                    {
                        // cztery możliwe kierunki
                        if (CzyLinia(x, y, 0, 1, znak)) return true;  // poziomo 
                        if (CzyLinia(x, y, 1, 0, znak)) return true;  // pionowo 
                        if (CzyLinia(x, y, 1, 1, znak)) return true;  // ukośnie 
                        if (CzyLinia(x, y, 1, -1, znak)) return true; // ukośnie 
                    }
                }
            }
            return false;
        }

        // sprawdza, czy istnieje ciąg 6 identycznych znaków w zadanym kierunku
        private bool CzyLinia(int x, int y, int dx, int dy, string znak)
        {
            for (int i = 0; i < 6; i++)
            {
                int nx = x + i * dx;
                int ny = y + i * dy;

                if (nx < 0 || nx >= Rozmiar || ny < 0 || ny >= Rozmiar)
                    return false;

                if (pola[nx, ny] != znak)
                    return false;
            }
            return true;
        }

        // resetuje planszę do stanu początkowego (same "?" na polach)
        public void Resetuj()
        {
            for (int i = 0; i < Rozmiar; i++)
                for (int j = 0; j < Rozmiar; j++)
                    pola[i, j] = "?";
        }
    }
}


