List<string> Plecak = new List<string>
{
    "Miecz",
    "Mikstura",
    "Pochodnia"
};

// Plecak ?/6
Console.WriteLine($"\nPlecak ({Plecak.Count}/6):");

// wyswietlanie eq, 1. 2. itd.
for (int i = 0; i < Plecak.Count; i++)
{
    Console.WriteLine($"{i + 1}. {Plecak[i]}");
}

// nowy item
Console.WriteLine("\nDodaj nowy przedmiot");
string NowyPrzedmiot = Console.ReadLine()!;

Plecak.Add(NowyPrzedmiot);
Console.WriteLine($"\nDodano {NowyPrzedmiot} do eq");

// check mikstury przez contains
if ( Plecak.Contains("Mikstura") )
{
    Console.WriteLine("\nMikstura jest w plecaku");
}
else
{
    Console.WriteLine("\nW plecaku nie ma mikstury");
}

// usuniecie mikstury
bool Usunieto = Plecak.Remove("Mikstura");
if (Usunieto)
{
    Console.WriteLine("Pomyślnie usunięto miksture");
}
else
{
    Console.WriteLine("Nie udało się usunąć mikstury");
}

// ponowne wyświetlenie eq
Console.WriteLine($"\nPlecak ({Plecak.Count}/6):");
for (int i = 0; i < Plecak.Count; i++)
{
    Console.WriteLine($"{i + 1}. {Plecak[i]}");
}
