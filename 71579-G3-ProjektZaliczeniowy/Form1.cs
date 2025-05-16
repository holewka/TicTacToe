using System;
using System.Drawing;
using System.Windows.Forms;

namespace _71579_G3_ProjektZaliczeniowy  // autorka: Wiktoria Chomenko, 71579, grupa 3 
{
    public partial class Form1 : Form
    {
        // Tablica przycisków reprezentująca planszę 10x10
        private readonly Button[,] plansza = new Button[10, 10]; // readonly - zainicjowana struktura danych nie może zostać zmieniona

        // Obiekt reprezentujący całą logikę gry (gracz, komputer, plansza)
        private readonly Gra gra = new Gra();

        public Form1()
        {
            InitializeComponent();  // buduje cały interfejs graficzny
            StworzTablice();        // tworzenie planszy
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
                        Font = new Font("Arial", 12),            // dla lepszej widoczności
                        Size = new Size(rozmiar, rozmiar),
                        Location = new Point(kolumna * rozmiar, wiersz * rozmiar),
                        Text = "?",                               // domyślny znak pola
                        BackColor = Color.WhiteSmoke
                    };

                    kafelek.Click += RuchGracza;                 // przypisanie zdarzenia kliknięcia

                    Controls.Add(kafelek);
                    plansza[wiersz, kolumna] = kafelek;
                }
            }
        }

        // Ruch gracza po kliknięciu przycisku
        private void RuchGracza(object sender, EventArgs e)
        {
            Button klikniety = sender as Button;
            int x = klikniety.Location.Y / 40;
            int y = klikniety.Location.X / 40;

            // Ignoruj jeśli pole jest zajęte
            if (!gra.RuchGracza(x, y)) return;

            klikniety.Text = gra.Gracz.Znak;
            klikniety.BackColor = Color.LightBlue;

            // Sprawdzenie wygranej gracza
            if (gra.CzyWygrana(gra.Gracz.Znak))
            {
                MessageBox.Show("Wygrał gracz!");
                gra.Gracz.DodajPunkt();     // dodanie punktu
                AktualizujWynik();          // aktualizacja punktacji
                ZablokujPlansze();          // koniec gry
                return;
            }

            // Sprawdzenie remisu
            if (gra.CzyRemis())
            {
                MessageBox.Show("Remis!");
                return;
            }

            RuchKomputera(); // jeśli gracz nie wygrał ani nie ma remisu, komputer robi ruch
        }

        // Ruch komputera – losowe wybranie wolnego pola
        private void RuchKomputera()
        {
            if (gra.RuchKomputera(out int x, out int y))
            {
                plansza[x, y].Text = gra.Komputer.Znak;
                plansza[x, y].BackColor = Color.SandyBrown;

                // Sprawdzenie wygranej komputera
                if (gra.CzyWygrana(gra.Komputer.Znak))
                {
                    MessageBox.Show("Wygrał komputer!");
                    gra.Komputer.DodajPunkt();
                    AktualizujWynik();
                    ZablokujPlansze();
                    return;
                }

                // Sprawdzenie remisu
                if (gra.CzyRemis())
                {
                    MessageBox.Show("Remis!");
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

        // Przycisk dla resetu planszy
        private void Resetuj_Click(object sender, EventArgs e)
        {
            gra.ResetujGre();  // czyści planszę logicznie

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    plansza[x, y].Text = "?";
                    plansza[x, y].Enabled = true;
                    plansza[x, y].BackColor = Color.WhiteSmoke;
                }
            }
        }

        // Przycisk dla wyjścia z gry
        private void Zamknij_Click(object sender, EventArgs e)
        {
            Application.Exit();  // zakończenie aplikacji
        }

        // Aktualizacja punktacji
        private void AktualizujWynik()
        {
            lblGracz.Text = $"PlayerWins: {gra.Gracz.Punkty}";
            lblKomp.Text = $"CpuWins: {gra.Komputer.Punkty}";
        }
    }
}

