Dictionary<string, int> WareHouse = new Dictionary<string, int>     // Magazyn from site
{
    { "Mikstura", 3 },
    { "Pochodnia", 2 },
    { "Klucz", 1 }
};

bool Running = true;    // runtime

while (Running)
{
    // WareHouse menu options | pokaż magazyn, przyjmij dostawę, wydaj przedmiot, usuń pustą pozycję, zakończ.
    Console.WriteLine("\n1 - pokaż magazyn");       // show
    Console.WriteLine("2 - przyjmij dostawę");      // + item
    Console.WriteLine("3 - wydaj przedmiot");       // - item
    Console.WriteLine("4 - usuń pustą pozycję");
    Console.WriteLine("5 - zakończ\n");     // end

    // input ?
    Console.Write("Wybór: ");
    bool CorrectInput = int.TryParse(Console.ReadLine(), out int Choice);

    if (!CorrectInput)    // wrong input
    {
        Console.WriteLine("Wpisz liczbe całkowitą");
        continue;    // next menu
    }

    switch (Choice)
    {
        case 1:     // 1st

        if (WareHouse.Count == 0)   // empty warehouse
            {
                Console.WriteLine("Magazyn jest pusty");
            }
        else
            {
                foreach (KeyValuePair<string, int> Item in WareHouse)
                {
                    Console.WriteLine($"{Item.Key}: {Item.Value}");
                }
            }
            break;



        case 2:     // 2nd
        {
            Console.Write("Nazwa przedmiotu: ");
            string ItemName = Console.ReadLine();

            Console.Write("Liczba sztuk: ");
            bool CorrectAmount = int.TryParse(Console.ReadLine(), out int Amount);

            if (!CorrectAmount || Amount <= 0)    // wrong amount
            {
                Console.WriteLine("Wpisz dodatnią liczbę całkowitą");
                break;
            }

            if (WareHouse.ContainsKey(ItemName))    // existing item
            {
                WareHouse[ItemName] += Amount;
            }
            else    // new item
            {
                WareHouse.Add(ItemName, Amount);
            }

            Console.WriteLine("Dostawa przyjęta");
            break;
        }



        case 3:     // 3rd
        {
            Console.Write("Nazwa przedmiotu: ");
            string ItemName = Console.ReadLine();

            if (!WareHouse.ContainsKey(ItemName))    // item not found
            {
                Console.WriteLine("Nie ma takiego przedmiotu");
                break;
            }

            Console.Write("Liczba sztuk do wydania: ");
            bool CorrectAmount = int.TryParse(Console.ReadLine(), out int Amount);


            if (!CorrectAmount || Amount <= 0)    // wrong amount
            {
                Console.WriteLine("Wpisz dodatnią liczbę całkowitą");
                break;
            }

            if (Amount > WareHouse[ItemName])    // not enough items
            {
                Console.WriteLine("Za mało sztuk w magazynie");
            }
            else
            {
                WareHouse[ItemName] -= Amount;    // issue items
                Console.WriteLine($"Wydano: {ItemName}, sztuk: {Amount}");
            }
            break;
        }



        case 4:     // 4th
        {
            Console.Write("Nazwa przedmiotu do usunięcia: ");
            string ItemName = Console.ReadLine();

            if (!WareHouse.ContainsKey(ItemName))    // item not found
    {
        Console.WriteLine("Nie ma takiego przedmiotu");
        break;
    }

            if (WareHouse[ItemName] == 0)    // empty stock
            {
                WareHouse.Remove(ItemName);    // remove item
                Console.WriteLine($"Usunięto: {ItemName}");
            }
            else
            {
                Console.WriteLine("Nie można usunąć pozycji ze stanem większym od 0");
            }
            break;
        }


        case 5:     // 5th
        Running = false; // end game
        Console.WriteLine("Koniec gry");
        break;

        default:        // unknown
        Console.WriteLine("Nieznana opcja");
        break;
    }
}