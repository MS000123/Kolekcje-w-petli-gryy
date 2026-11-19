List<string> History = new List<string>();    // action history
bool Running = true;

while (Running)    // menu loop
{
    Console.WriteLine("1 - Eksploruj");
    Console.WriteLine("2 - Odpocznij");
    Console.WriteLine("3 - Znajdź przedmiot");
    Console.WriteLine("4 - Pokaż całą historię");
    Console.WriteLine("5 - Pokaż ostatnie trzy wpisy");
    Console.WriteLine("6 - Policz wybraną akcję");
    Console.WriteLine("7 - Wyczyść historię");
    Console.WriteLine("8 - Zakończ");
    Console.Write("Wybierz opcję: ");

    if (int.TryParse(Console.ReadLine(), out int Choice))
    {
        switch (Choice)
        {
            case 1:
                History.Add("Eksploracja");    // add action to history 1-3
                Console.WriteLine("Wykonano eksplorację");
                break;
            case 2:
                History.Add("Odpoczynek");
                Console.WriteLine("Odpoczęto");
                break;
            case 3:
                History.Add("Znaleziono przedmiot");
                Console.WriteLine("Znaleziono przedmiot");
                break;
            case 4:    // show history
            {
                if (History.Count == 0)
                {
                    Console.WriteLine("Historia jest pusta");
                }
                else
                {
                    for (int Index = 0; Index < History.Count; Index++)
                    {
                        Console.WriteLine($"{Index + 1} - {History[Index]}");
                    }
                }

                break;
            }
            case 5:    // last 3 logs
            {
                if (History.Count == 0)
                {
                    Console.WriteLine("Historia jest pusta");
                }
                else
                {
                    int Start = 0;

                    if (History.Count > 3)
                    {
                        Start = History.Count - 3;    // start from last 3 logs
                    }
                    
                    for (int Index = Start; Index < History.Count; Index++)
                    {
                        Console.WriteLine(History[Index]);
                    }
                }

                break;
            }
            case 6:    // count action
            {
                Console.WriteLine("Dostępne akcje: Eksploracja, Odpoczynek, Znaleziono przedmiot");
                Console.Write("Którą akcję zliczyć? ");
                string ActionName = Console.ReadLine();
                int Count = 0;

                for (int Index = 0; Index < History.Count; Index++)
                {
                    if (History[Index] == ActionName)
                    {
                        Count++;    // matching action
                    }
                }

                Console.WriteLine($"Liczba wystąpień: {Count}");
                break;
            }
            case 7:    // clear history
            {
                Console.Write("Wyczyścić historię? Wpisz t albo n: ");
                string Confirmation = Console.ReadLine();

                if (Confirmation == "t")
                {
                    History.Clear();    // remove all entries
                    Console.WriteLine("Historia została wyczyszczona");
                }
                else if (Confirmation == "n")
                {
                    Console.WriteLine("Czyszczenie anulowane");
                }
                else
                {
                    Console.WriteLine("Niepoprawna odpowiedź, czyszczenie anulowane");
                }

                break;
            }
            case 8:
                Running = false;    // end program
                break;
            default:
                Console.WriteLine("Nieznana opcja");
                break;
        }
    }
    else
    {
        Console.WriteLine("Wpisz poprawny numer opcji");
    }
}
