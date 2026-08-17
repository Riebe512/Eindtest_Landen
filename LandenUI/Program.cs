using LandenModel;
using var context = new LandenContext();

var landen = from l in context.Landen
             orderby l.Naam
             select l;

foreach ( var land in landen)
    Console.WriteLine($"{land.LandCode} | {land.Naam}");


string? gekozenLandCode;
Land? gekozenLand;
do
{
    Console.Write("Geef een Landcode op:");
    gekozenLandCode = Console.ReadLine();
    gekozenLand = context.Landen.Find(gekozenLandCode);

    if (gekozenLand is null)
        Console.WriteLine("Ongeldige Landcode.");

} while (gekozenLand is null);


var steden = from s in context.Steden
             where s.LandCode == gekozenLandCode
             orderby s.Naam
             select s;

var talen = from lt in context.LandenTalen
            where lt.LandCode == gekozenLandCode
            select lt.Taal;

Console.WriteLine($"\nSteden in {gekozenLand.Naam}:");
foreach (var s in steden)
    Console.WriteLine(s.Naam);

Console.WriteLine("\nTalen:");
foreach (var taal in talen)
    Console.WriteLine(taal.Naam);


string? nieuweStad;
do
{
    Console.Write("\nWelke stad wil je toevoegen?: ");
    nieuweStad = Console.ReadLine();

    if (nieuweStad == "")
        Console.WriteLine("Ongeldige stad.");

} while (nieuweStad is null);

var stad = new Stad
{
    Naam = nieuweStad,
    LandCode = gekozenLandCode.ToUpper()
};

context.Steden.Add(stad);
context.SaveChanges();
Console.WriteLine("Je stad is toegevoegd.");
