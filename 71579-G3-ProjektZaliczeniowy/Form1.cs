using System;
using System.Drawing;
using System.Windows.Forms;

namespace _71579_G3_ProjektZaliczeniowy
{
    public partial class Form1 : Form
    {
        // Tablica przycisków reprezentująca planszę 10x10
        private readonly Button[,] plansza = new Button[10, 10]; // readonly - zainicjowana struktura danych nie może zostać zmieniona

        // Znaki przypisane graczowi i komputerowi
        private const string graczZnak = "X";  //const - nigdy sie nie zmienia
        private const string kompZnak = "O";

        // Generator losowych liczb dla ruchów komputera
        private readonly Random losuj = new Random();  

        // Zmienna do przechowywania punktów
        private int punktyGracza = 0;
        private int punktyKomp = 0;

        public Form1()
        {
            InitializeComponent();  //buduje cały interfejs graficzny
            StworzTablice();      // tworzenie planszy
            AktualizujWynik();      // aktualizacja wyniku
        }

        // Tworzy planszę 10x10 jako siatkę przycisków
        private void StworzTablice()
        {
            int rozmiar = 40;

            for (int wiersz = 0; wiersz < 10; wiersz++)
            {
                for (int kolumna = 0; kolumna < 10; kolumna++)
                {
                    var kafelek = new Button
                    {
                        Font = new Font("Arial", 12),  //dla lepszej widoczności
                        Size = new Size(rozmiar, rozmiar),
                        Location = new Point(kolumna * rozmiar, wiersz * rozmiar),
                        Text = "?",  //domyślny znak pola
                        BackColor = Color.WhiteSmoke
                    };

                    kafelek.Click += RuchGracza;  // przypisanie zdarzenia kliknięcia

                    Controls.Add(kafelek);
                    plansza[wiersz, kolumna] = kafelek;
                }

            }
        }

        // Ruch gracza po kliknięciu przycisku
        private void RuchGracza(object sender, EventArgs e)
        {
            Button klikniety = sender as Button;

            // Ignoruj jeśli pole jest zajęte
            if (klikniety.Text != "?") return;

            klikniety.Text = graczZnak;
            klikniety.BackColor = Color.LightBlue;

            // Sprawdzenie wygranej gracza
            if (SprawdzWygrana(graczZnak))
            {
                MessageBox.Show("Wygrał gracz!");
                punktyGracza++;
                AktualizujWynik();
                ZablokujPlansze();
                return;
            }

            // Sprawdzenie remisu
            if (CzyRemis())
            {
                MessageBox.Show("Remis!");
                return;
            }

            
            RuchKomputera();
        }

        // Ruch komputera – losowe wybranie wolnego pola
        private void RuchKomputera()
        {
            for (int i = 0; i < 1000; i++)
            {
                int wiersz = losuj.Next(10);
                int kolumna = losuj.Next(10);

                if (plansza[wiersz, kolumna].Text == "?")
                {
                    plansza[wiersz, kolumna].Text = kompZnak;
                    plansza[wiersz, kolumna].BackColor = Color.SandyBrown;

                    // Sprawdzenie wygranej komputera
                    if (SprawdzWygrana(kompZnak))
                    {
                        MessageBox.Show("Wygrał komputer!");
                        punktyKomp++;
                        AktualizujWynik();
                        ZablokujPlansze();
                        return;
                    }

                    // Sprawdzenie remisu
                    if (CzyRemis())
                    {
                        MessageBox.Show("Remis!");
                        return;
                    }

                    return;
                }
            }
        }

        // Blokuje wszystkie przyciski po zakończeniu gry
        private void ZablokujPlansze()
        {
            foreach (var kafelek in plansza)
            {
                kafelek.Enabled = false;
            }
        }

        // Czy wszystkie pola są zapełnione (?) - remis
        private bool CzyRemis()
        {
            foreach (var btn in plansza)
            {
                if (btn.Text == "?")
                    return false;
            }
            return true;
        }

        // Przycisk dla resetu planszy
        private void Resetuj_Click(object sender, EventArgs e)
        {
            foreach (var kafelek in plansza)
            {
                kafelek.Text = "?";
                kafelek.Enabled = true;
                kafelek.BackColor = Color.WhiteSmoke;
            }
        }

        // Przycisk dla wyjścia z gry
        private void Zamknij_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Sprawdzamy wygraną
        private bool SprawdzWygrana(string znak)
        {
            for (int rzad = 0; rzad < 10; rzad++)
            {
                for (int kol = 0; kol < 10; kol++)
                {
                    if (plansza[rzad, kol].Text == znak)
                    {
                        // We wszystkich kierunkach
                        if (Kierunek(rzad, kol, 0, 1, znak)) return true;  // poziomo
                        if (Kierunek(rzad, kol, 1, 0, znak)) return true;  // pionowo
                        if (Kierunek(rzad, kol, 1, 1, znak)) return true;  // ukośnie w dół
                        if (Kierunek(rzad, kol, 1, -1, znak)) return true; // ukośnie w górę
                    }
                }
            }
            return false;
        }

        // Sprawdza ciąg 6 znaków
        private bool Kierunek(int startX, int startY, int przesX, int przesY, string znak)
        {
            Button[] linia = new Button[6];

            for (int i = 0; i < 6; i++)
            {
                int x = startX + i * przesX;
                int y = startY + i * przesY;

                // Sprawdzenie czy nie wychodzimy poza planszę, aby uniknąć zepsucia gry
                if (x < 0 || x >= 10 || y < 0 || y >= 10)
                    return false;

                // Sprawdzamy, czy na tym polu jest właściwy znak 
                if (plansza[x, y].Text == znak)
                    linia[i] = plansza[x, y];
                else
                    return false;
            }

            // Podświetlenie pól po wygranej
            foreach (var btn in linia)
            {
                btn.BackColor = Color.LightGreen;
            }

            return true;
        }

        // Aktualizacja punktacji
        private void AktualizujWynik()
        {
            lblGracz.Text = $"PlayerWins: {punktyGracza}";
            lblKomp.Text = $"CpuWins: {punktyKomp}";
        }
    }
}

