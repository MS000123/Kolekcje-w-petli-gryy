Dictionary<string, int> Ceny = new Dictionary<string, int>
{
    { "Mikstura", 15 },
    { "Pochodnia", 5 },
    { "Miecz", 40 }
};

// liczba pozycji
Console.WriteLine($"\nLiczba przedmiotów {Ceny.Count}\n");

// wyś cennika
foreach (KeyValuePair<string, int> para in Ceny)
{
    Console.WriteLine($"{para.Key}: {para.Value} sztuk złota");
}

// nowy item
Console.Write("\nPodaj nazwę przedmiotu: ");
string Nazwa = Console.ReadLine()!;

// check itemu, ceny
if ( Ceny.ContainsKey(Nazwa) )
{
    Console.WriteLine($"Cena: {Ceny[Nazwa]} sztuk złota");
}
else
{
    Console.WriteLine("Nie ma takiego przedmiotu");
}

Ceny["Mikstura"] = 12;
Console.WriteLine("");
// ponowne wyświetlenie cen
foreach (KeyValuePair<string, int> para in Ceny)
{
    Console.WriteLine($"{para.Key}: {para.Value} sztuk złota");
}
Console.WriteLine("");