Console.WriteLine();
List<string> Items = new List<string>   // list from site
{
    "Miecz",
    "Tarcza",
    "Mikstura",
    "Klucz"
};

int i = 0;      // index, start of 1st item (0)

for (i = 0; i < Items.Count; i++)   // items 0,1,2,3 = 4
{
    Console.WriteLine($"{i + 1}. {Items[i]}");      // show item | 1-4.
}


// blank list
if (Items.Count == 0)
{
    Console.WriteLine("Lista jest pusta");
}
else
{
    while (true)      // ask until correct input
    {
        Console.Write("Podaj numer przedmiotu do usuniecia: ");     // question / user input
        bool CorrectInput = int.TryParse(Console.ReadLine(), out int Number);

        if (!CorrectInput)      // correct input false
        {
            Console.WriteLine("Wpisz liczbę całkowitą");
        }
        else if (Number < 1)    // out of range | too low
        {
            Console.WriteLine($"Numer musi być w zakresie od 1 do {Items.Count}");
        }
        else if (Number > Items.Count)    // out of range | too high
        {
            Console.WriteLine($"Numer musi być w zakresie od 1 do {Items.Count}");
        }
        else
        {
            int Index = Number - 1;     // number to index
            string RemovedItem = Items[Index];      // save item name
            Items.RemoveAt(Index);      // remove item
            Console.WriteLine($"Usunięto: {RemovedItem}");

            Console.WriteLine("Aktualna lista:");

            for (i = 0; i < Items.Count; i++)    // rest items
            {
                Console.WriteLine($"{i + 1}. {Items[i]}");
            }

            break;
        }
    }
}