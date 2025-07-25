��#   T i c T a c T o e 
 # 🎮 Gra Kółko i Krzyżyk 10x10 – Windows Forms (C#)

Projekt zaliczeniowy: rozbudowana gra „kółko i krzyżyk” stworzona w języku C# z użyciem Windows Forms.  
Gra rozgrywa się na planszy 10x10, a zwycięża gracz, który jako pierwszy ułoży ciąg 6 znaków (X lub O) w jednej linii: poziomej, pionowej lub ukośnej.

## 🧑‍💻 Autor
Wiktoria Chomenko  

## 🛠 Technologie
- Język: C#
- Środowisko: Visual Studio (.NET Framework)
- Typ aplikacji: Windows Forms App
- Styl: Programowanie obiektowe (OOP)

## 📁 Struktura projektu
71579-G3-ProjektZaliczeniowy/
├── Form1.cs         # Główne okno i logika interfejsu  
├── Gra.cs           # Klasa sterująca całą rozgrywką  
├── Gracz.cs         # Klasa reprezentująca gracza (X lub O)  
├── Plansza.cs       # Logika planszy gry 10x10  
├── Form1.Designer.cs  
├── README.md        # Opis projektu  
└── bin/ obj/        # Pliki kompilacji (ignorowane przez Git)

## 🎯 Funkcje gry
- Plansza 10x10 dynamicznie generowana w oknie  
- Gracz kontra komputer (AI wykonuje losowe ruchy)  
- Sprawdzanie wygranej w 4 kierunkach  
- Wymagana linia 6 znaków do zwycięstwa  
- Zliczanie punktów gracza i komputera  
- Przycisk „Resetuj” – nowa gra  
- Przycisk „Zamknij” – zakończenie aplikacji  
- Podświetlanie zwycięskich pól na zielono  

## 👩‍🏫 Obiektowość w projekcie
Projekt został podzielony na logiczne klasy:
- Gracz – zawiera nazwę, symbol, liczbę punktów
- Plansza – przechowuje stan planszy, sprawdza zwycięstwo, remis
- Gra – zarządza przebiegiem gry, ruchem gracza i komputera
- Form1 – zajmuje się tylko interfejsem graficznym i zdarzeniami

Zastosowano zasady OOP:
- Enkapsulacja (prywatne pola i metody)
- Modularność (każda klasa odpowiada za coś innego)
- Dziedziczenie (Form1 : Form)

## 🚀 Jak uruchomić?
1. Otwórz projekt w Visual Studio  
2. Zbuduj aplikację (`Ctrl+Shift+B`)  
3. Uruchom (`F5` lub kliknij „Start”)  
4. Graj klikając w puste pola planszy – komputer odpowiada automatycznie

## 🖼 Interfejs
- Puste pole: ? (WhiteSmoke)  
- Pole gracza: X (LightBlue)  
- Pole komputera: O (SandyBrown)  
- Zwycięska linia: LightGreen  
- Etykiety: lblGracz, lblKomp – pokazują wynik

## 📜 Licencja
Projekt edukacyjny – możesz korzystać, modyfikować i rozwijać dalej.

## 🤍 Podziękowania
Projekt sprawił mi dużo frajdy i pomógł zrozumieć działanie obiektowości w praktyce.  
Dziękuję za pomoc ChatGPT, YouTube i dokumentacji C# 😊

 
