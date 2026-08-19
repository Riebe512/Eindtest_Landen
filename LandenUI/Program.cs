using LandenModel;
using Microsoft.EntityFrameworkCore;
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


var GekozenLand = context.Landen
    .Where(l => l.LandCode == gekozenLandCode)
    .Include(l => l.Steden)
    .Include(l => l.Talen)
    .FirstOrDefault();

Console.WriteLine($"\nSteden in {gekozenLand.Naam}:");

foreach (var s in GekozenLand.Steden)
    Console.WriteLine(s.Naam);

Console.WriteLine("\nTalen:");
foreach (var taal in GekozenLand.Talen)
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
