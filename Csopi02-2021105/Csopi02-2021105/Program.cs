using Csopi02_2021105;
using System.Text;

const string FILE = @"..\..\..\src\forras.txt";
const int AKTUALIS_EV = 2014;

List<versenyzo> versenyzok = new();

using StreamReader sr = new(FILE, Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new versenyzo(sr.ReadLine()));

Console.WriteLine($"Versenyt befejezok szama: {versenyzok.Count} fo");

// LINQ lekérdezések

var f01 = versenyzok.Count(v => v.Kategoria == "elit junior");

var f02 = versenyzok
    .Where(v => v.Nem)
    .Average(v => AKTUALIS_EV - v.SzulEv);

var f03 = versenyzok
    .Sum(v => v.VersenyIdok["Futás"].TotalHours);

var f04 = versenyzok
    .Where(v => v.Kategoria == "20-24")
    .Average(v => v.VersenyIdok["Úszás"].TotalMinutes);

var f05 = versenyzok
    .Where(v => !v.Nem)
    .MinBy(v => v.OsszIdo);

var f06 = versenyzok
    .GroupBy(v => v.Nem)
    .ToDictionary(g => g.Key, g => g.Count());

var f07 = versenyzok
    .GroupBy(v => v.Kategoria)
    .ToDictionary(g => g.Key, g => g.Average(
        v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));

// Kiírások

Console.WriteLine($"Versenyzők száma 'elit junior' kategóriában: {f01} fő");
Console.WriteLine($"Férfi versenyzők átlagéletkora: {f02:0.00} év");
Console.WriteLine($"A versenyzők futással töltött összideje: {f03:0.00} óra");
Console.WriteLine($"Átlagos úszási idő 20-24 kategóriában: {f04:0.00} perc");
Console.WriteLine($"Női győztes: {f05}");
Console.WriteLine("Nemek szerint a versenyt befejezők száma:");
foreach (var kvp in f06)
    Console.WriteLine($"\t{(kvp.Key ? "Férfi" : "Nő")}: {kvp.Value} fő");

Console.WriteLine("Korkategóriánként az átlag depóban töltött idő:");
foreach (var kvp in f07)
    Console.WriteLine($"\t{kvp.Key}: {kvp.Value:0.00} perc");
