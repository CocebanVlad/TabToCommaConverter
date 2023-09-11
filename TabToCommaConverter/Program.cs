using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

var culture = CultureInfo.InvariantCulture;

using var reader = new StreamReader(args[0]);
using var csvReader = new CsvReader(reader, new CsvConfiguration(culture)
{
    Delimiter = "\t"
});

await using var writer = new StreamWriter(args[1]);
await using var csvWriter = new CsvWriter(writer, new CsvConfiguration(culture)
{
    Delimiter = ","
});

var sw = Stopwatch.StartNew();

Console.WriteLine("Converting...");
await csvWriter.WriteRecordsAsync(csvReader.GetRecordsAsync<dynamic>());

sw.Stop();
Console.WriteLine($"Done {sw.Elapsed}");