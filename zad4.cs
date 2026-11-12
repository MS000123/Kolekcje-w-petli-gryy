int LiczbaTur;

while (true)
{
    Console.Write("Podaj liczbę tur (1-10): "); 
    bool PoprawneDane = int.TryParse(Console.ReadLine(), out LiczbaTur);

    if (!PoprawneDane || LiczbaTur < 1 || LiczbaTur > 10)   // input turns 1-10
    {
        Console.WriteLine("Wpisz liczbę całkowitą od 1 do 10.");
        continue;
    }

    break;
}

int[] ZlotoWTurach = new int[LiczbaTur];     // one place per turn

// Złoto w każdej turze
for (int i = 0; i < ZlotoWTurach.Length; i++)
{
    while (true)
    {
        Console.Write($"Złoto w turze {i + 1}: ");
        bool PoprawneDane = int.TryParse(Console.ReadLine(), out int Zloto);

        if (!PoprawneDane || Zloto < 0)     // wrong input or - zloto
        {
            Console.WriteLine("Wpisz nieujemną liczbę całkowitą.");
            continue;
        }

        ZlotoWTurach[i] = Zloto;
        break;
    }
}

// Wartości początkowe
long Suma = 0;
int Minimum = ZlotoWTurach[0];
int Maksimum = ZlotoWTurach[0];
int PierwszaNajlepszaTura = 1;
int LiczbaMaksimum = 0;
int PierwszaTuraBezZlota = -1;

// Suma, minimum, maksimum i pierwsza tura bez złota
for (int i = 0; i < ZlotoWTurach.Length; i++)
{
    Suma += ZlotoWTurach[i];

    if (ZlotoWTurach[i] < Minimum)
    {
        Minimum = ZlotoWTurach[i];
    }

    if (ZlotoWTurach[i] > Maksimum)
    {
        Maksimum = ZlotoWTurach[i];
        PierwszaNajlepszaTura = i + 1;
    }

    if (ZlotoWTurach[i] == 0 && PierwszaTuraBezZlota == -1)
    {
        PierwszaTuraBezZlota = i + 1;
    }
}

// Liczenie wyników równych znalezionemu maksimum
foreach (int Zloto in ZlotoWTurach)
{
    if (Zloto == Maksimum)
    {
        LiczbaMaksimum++;
    }
}

// Wyniki
Console.WriteLine();
Console.WriteLine($"Suma: {Suma}");
Console.WriteLine($"Minimum: {Minimum}");
Console.WriteLine($"Maksimum: {Maksimum}");
Console.WriteLine($"Pierwszy najlepszy wynik: tura {PierwszaNajlepszaTura}");
Console.WriteLine($"Liczba tur z maksimum: {LiczbaMaksimum}");

if (PierwszaTuraBezZlota == -1)
{
    Console.WriteLine("Nie było tury bez złota.");
}
else
{
    Console.WriteLine($"Pierwsza tura bez złota: {PierwszaTuraBezZlota}");
}