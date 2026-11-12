int[] ZlotoWTurach = { 5, 12, 0, 8, 15 };   // 5 Tur
int Suma = 0;
int Tura = 0;
int TuryZ10 = 0;
Console.WriteLine();

foreach (int Zloto in ZlotoWTurach)
{
    Tura++;
    // 1. Tura 12345
    Console.WriteLine($"Tura {Tura}: {Zloto} sztuk złota");

    Suma += Zloto;
    if (Zloto >=10)
    {
        TuryZ10++;  // Tury z wynikiem 10
    }
}

double Srednia = (double)Suma / ZlotoWTurach.Length;

Console.WriteLine();
Console.WriteLine($"Łącznie: {Suma}");
Console.WriteLine($"Średnio na turę: {Srednia:F2}");
Console.WriteLine($"Tury z wynikiem co najmniej 10: {TuryZ10}");
Console.Write($"Od końca: ");

for (int i = ZlotoWTurach.Length - 1; i >= 0; i--)
{
    Console.Write(ZlotoWTurach[i]);

    if (i > 0)
    {
        Console.Write(" ");
    }
}

Console.WriteLine();