// Karta Bohatera - Zad 6
// Projekt - Karta bohatera 4.0

const int MaxHealth = 100;
Console.Write("Podaj imię gracza: ");
String PlayerName = Console.ReadLine()!;
// Health
int Health = 80;

// Money
int Money = 10;

// Backpack |  replaced old tonic section
List<string> Backpack = new List<string>
{
    "Miecz",
    "Mikstura"
};

// items that could be found
string[] Items =
{
    "Mikstura",
    "Klucz",
    "Pochodnia",
    "Zwój"
};

// Action history
List<string> History = new List<string>();

// gold | from site
int[] GoldPerTurn = new int[20];

// Math
int Turn = 1;
int Explorations = 0;
bool GameRunning = true;

while (GameRunning && Health > 0 && Turn <= 20)   // main loop | max 20 loops
{
    double HealthPercent = (double)Health / MaxHealth * 100;    // % of max health
    bool Alive = Health > 0;

    // INFO
    Console.ForegroundColor = ConsoleColor.Red;  // red col title
    Console.WriteLine("\n===== HELLO ADVENTURER 5.0 =====");        // changed name of game
    Console.ResetColor();
    Console.WriteLine($"Gracz: {PlayerName}");
    Console.WriteLine($"Tura: {Turn}\n");

    Console.WriteLine("----- STAN BOHATERA -----");
    Console.WriteLine($"Zdrowie: {Health}/{MaxHealth} ({HealthPercent:F2}%)");

    // alive info
    if (!Alive)     // bool false - hero dead
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bohater nie żyje");
        Console.ResetColor();
    }
    else if (Health < 25)       // low hp - still alive
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Bohater jest ranny");
        Console.ResetColor();
    }
    else        // bool true - alive and hp >= 25
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bohater jest zdrowy");
        Console.ResetColor();
    }

Console.WriteLine($"Pieniądze: {Money:F2}");
Console.WriteLine($"\nPlecak: {Backpack.Count}/6");
Console.WriteLine($"Żyje: {Alive}\n");
// Menu | new from site
Console.WriteLine("----- LISTA AKCJI -----");
Console.WriteLine("1 - Eksploruj loch");
Console.WriteLine("2 - Pokaż plecak");
Console.WriteLine("3 - Użyj przedmiotu");
Console.WriteLine("4 - Dodaj znalezisko");
Console.WriteLine("5 - Wyrzuć przedmiot");
Console.WriteLine("6 - Pokaż historię");
Console.WriteLine("7 - Pokaż statystyki wyprawy");
Console.WriteLine("8 - Zakończ grę");



    // PART 2 - ACTIONS
    Console.Write("\nWybierz akcję: ");
    bool ActionInput = int.TryParse(Console.ReadLine(), out int ActionChoice);  // check if action input is a number true/false

    if (!ActionInput)  // wrong input
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wpisz liczbę całkowitą");
        Console.ResetColor();
        continue;   // back to menu
    }

    if (!Alive)     // bool false - hero dead
    {
        Console.WriteLine("Bohater nie żyje nie może żadnej wykonać akcji");
    }
    else
    {
        switch (ActionChoice)
        {
            case 1:     // exploration
            Money += 10;
            Health -= 8;
            Explorations++;

            if (Health < 0)
            {
                Health = 0;
            }

            if (Turn - 1 < GoldPerTurn.Length)
            {
                GoldPerTurn[Turn - 1] = 10;
            }

            History.Add($"Tura {Turn} - Eksploracja, zdobyto 10 złota");
            Console.WriteLine("Zdobywasz 10 złota i tracisz 8 HP");
            break;

            case 2:     // show backpack
            if (Backpack.Count == 0)
            {
                Console.WriteLine("Plecak jest pusty");
            }
            else
            {
                Console.WriteLine("Plecak:");

                for (int Index = 0; Index < Backpack.Count; Index++)
                {
                   Console.WriteLine($"{Index + 1} - {Backpack[Index]}");
                }
            }
            continue; // back to menu



            case 3:     // use item
            {
                if (Backpack.Count == 0)
                {
                    Console.WriteLine("Plecak jest pusty");
                    continue;
                }

                for (int Index = 0; Index < Backpack.Count; Index++)
                {
                    Console.WriteLine($"{Index + 1} - {Backpack[Index]}");
                }

                Console.Write("Wybierz numer przedmiotu: ");
                bool CorrectInput = int.TryParse(Console.ReadLine(), out int Number);

                if (!CorrectInput || Number < 1 || Number > Backpack.Count)
                {
                    Console.WriteLine("Niepoprawny numer przedmiotu");
                    continue;
                }

                int ItemIndex = Number - 1;
                string Item = Backpack[ItemIndex];

                if (Item == "Mikstura")
                {
                    if (Backpack.Contains("Mikstura"))
                    {
                        Console.WriteLine("Masz miksturę w plecaku");
                    }
                    Health += 20;

                    if (Health > MaxHealth)
                    {
                        Health = MaxHealth;
                    }

                    Console.WriteLine("Użyto mikstury");
                    History.Add($"Tura {Turn} - Użyto mikstury");
                }
                else if (Item == "Pochodnia")
                {
                    Console.WriteLine("Rozświetlono korytarz");
                    History.Add($"Tura {Turn} - Rozświetlono korytarz");
                }
                else if (Item == "Zwój")
                {
                    Money += 15;
                    Console.WriteLine("Użyto zwoju i zdobyto 15 złota");
                    History.Add($"Tura {Turn} - Użyto zwoju, zdobyto 15 złota");
                }
                else
                {
                    Console.WriteLine("Tego przedmiotu nie można użyć");
                    continue;
                }

                Backpack.RemoveAt(ItemIndex);
                break;
            }



            case 4:     // add item
            {
                if (Backpack.Count >= 6)
                {
                    Console.WriteLine("Plecak jest pełny");
                    continue;
                }

                for (int Index = 0; Index < Items.Length; Index++)
                {
                    Console.WriteLine($"{Index + 1} - {Items[Index]}");
                }

                Console.Write("Wybierz numer znaleziska: ");
                bool CorrectInput = int.TryParse(Console.ReadLine(), out int Number);

                if (!CorrectInput || Number < 1 || Number > Items.Length)
                {
                    Console.WriteLine("Niepoprawny numer znaleziska");
                    continue;
                }

                string Item = Items[Number - 1];
                Backpack.Add(Item);

                Console.WriteLine($"Dodano do plecaka: {Item}");
                History.Add($"Tura {Turn} - Dodano przedmiot: {Item}");
                break;
            }

            case 5:     // remove item
            {
                if (Backpack.Count == 0)
                {
                    Console.WriteLine("Plecak jest pusty");
                    continue;
                }

                for (int Index = 0; Index < Backpack.Count; Index++)
                {
                    Console.WriteLine($"{Index + 1} - {Backpack[Index]}");
                }

                Console.Write("Wybierz numer przedmiotu do wyrzucenia: ");
                bool CorrectInput = int.TryParse(Console.ReadLine(), out int Number);

                if (!CorrectInput || Number < 1 || Number > Backpack.Count)
                {
                    Console.WriteLine("Niepoprawny numer przedmiotu");
                    continue;
                }

                int ItemIndex = Number - 1;
                string Item = Backpack[ItemIndex];

                Backpack.RemoveAt(ItemIndex);
                Console.WriteLine($"Wyrzucono: {Item}");
                History.Add($"Tura {Turn} - Wyrzucono przedmiot: {Item}");
                break;
            }

            case 6:      // history
            {
                if (History.Count == 0)
                {
                    Console.WriteLine("Historia jest pusta");
                }
                else
                {
                    foreach (string Entry in History)
                    {
                        Console.WriteLine(Entry);
                    }
                }

                continue;   // back to menu
            }
            case 7: // expedition stats
            {
                int TotalGold = 0;
                int MaxGold = 0;
                int TurnsWithoutGold = 0;

                for (int Index = 0; Index < Turn - 1; Index++)
                {
                    TotalGold += GoldPerTurn[Index];

                    if (GoldPerTurn[Index] > MaxGold)
                    {
                        MaxGold = GoldPerTurn[Index];
                    }

                    if (GoldPerTurn[Index] == 0)
                    {
                        TurnsWithoutGold++;
                    }
                }

                Console.WriteLine($"Liczba eksploracji: {Explorations}");
                Console.WriteLine($"Złoto z eksploracji: {TotalGold}");
                Console.WriteLine($"Najwięcej złota w turze: {MaxGold}");
                Console.WriteLine($"Tury bez złota z eksploracji: {TurnsWithoutGold}");

                continue; // back to menu
            }

            case 8: // end game
            GameRunning = false;
            break;

            default: // unknown option
            Console.WriteLine("Nieznana akcja");
            continue;
        }
    }
    if (GameRunning) // no new turn after leaving / exit
    {
        Turn++; // next turn
    }
}

// FINAL SUMMARY
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n----- PODSUMOWANIE GRY -----");
Console.ResetColor();
Console.WriteLine($"Gracz: {PlayerName}");
Console.WriteLine($"Rozegrane tury: {Turn - 1}");    // -1 because of 1st tour
Console.WriteLine($"Liczba wypraw: {Explorations}");
Console.WriteLine($"Zdrowie: {Health}/{MaxHealth}");    // Health ?/100
Console.WriteLine($"Pieniądze: {Money:F2}");
Console.WriteLine($"Przedmioty w plecaku: {Backpack.Count}");
Console.WriteLine($"Wpisy w historii: {History.Count}");

// reason of the end
if (Health <= 0)
{
    Console.WriteLine("Powód zakończenia: bohater stracił całe HP");
}
else if (Turn > 20)
{
    Console.WriteLine("Powód zakończenia: rozegrano 20 tur");
}
else
{
    Console.WriteLine("Powód zakończenia: gracz wybrał wyjście");
}

// final backpack
Console.WriteLine("Plecak:");

if (Backpack.Count == 0)
{
    Console.WriteLine("Plecak jest pusty");
}
else
{
    foreach (string Item in Backpack)
    {
        Console.WriteLine(Item);
    }
}

// last 3 history entries
Console.Write("Ostatnie wpisy historii: ");

if (History.Count == 0)
{
    Console.WriteLine("Historia jest pusta");
}
else
{
    int Start = 0;

    if (History.Count > 3)
    {
        Start = History.Count - 3;
    }

    for (int Index = Start; Index < History.Count; Index++)
    {
        Console.WriteLine(History[Index]);
    }
}
