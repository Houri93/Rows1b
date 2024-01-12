using Rows1b.Generator;
using System.Diagnostics;
using System.Text;

var startTs = Stopwatch.GetTimestamp();
var initTs = startTs;

const int rowsCount = 1_000_000_000;//1_000_000_000;
const int seed = 69;
string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "rows1b.txt");

var faker = new Bogus.Faker<Row>()
    .UseSeed(seed);

faker.RuleFor(a => a.Name, b => b.Person.FullName);
faker.RuleFor(a => a.DateOfBirth, b => b.Person.DateOfBirth);
faker.RuleFor(a => a.City, b => b.Person.Address.City);
faker.RuleFor(a => a.Street, b => b.Person.Address.Street);
faker.RuleFor(a => a.State, b => b.Person.Address.State);
faker.RuleFor(a => a.ZipCode, b => b.Person.Address.ZipCode);
faker.RuleFor(a => a.Company, b => b.Company.CompanyName());
faker.RuleFor(a => a.Id, b => b.IndexGlobal);

Console.WriteLine($"Generating {rowsCount} rows");

File.WriteAllText(filePath, string.Empty);


var fileStream = File.OpenWrite(filePath);

for (int i = 0; i < rowsCount; i++)
{
    var row = faker.Generate();

    fileStream.Write(Encoding.UTF8.GetBytes(row.ToString() + Environment.NewLine));

    var timeSinceLast = Stopwatch.GetElapsedTime(startTs);
    if (timeSinceLast >= TimeSpan.FromSeconds(5))
    {
        var percentage = Math.Round((i / (double)rowsCount) * 100.0, 3);
        Console.WriteLine($"{Stopwatch.GetElapsedTime(initTs)} {percentage}%");
        startTs = Stopwatch.GetTimestamp();
    }
}

fileStream.Dispose();

Console.WriteLine($"Completed in {Stopwatch.GetElapsedTime(initTs)}");

Console.ReadKey();