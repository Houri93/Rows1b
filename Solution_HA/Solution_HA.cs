using Rows1b.Shared;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rows1b.Solution.HA;

public sealed class Solution_HA : IResultsProducer
{
    static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "rows1b_100_000_000.txt");
    private readonly StreamReader streamReader;
    public Solution_HA()
    {
        streamReader = new StreamReader(path);
    }

    //10.5
    //38097553
    public int CountOlderThan(int age, int year, int month, int day)
    {
        var today = new DateTime(year, month, day);
        var totalCount = 0;

        string? line;

        while ((line = streamReader.ReadLine()) is not null)
        {
            var tabsCount = 0;
            var yearStr = string.Empty;
            var monthStr = string.Empty;
            var dayStr = string.Empty;

            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];

                if (c == '\t')
                {
                    tabsCount++;
                }
                else if (tabsCount is 2)
                {
                    yearStr = line[(i)..(i + 4)];
                    monthStr = line[(i + 5)..(i + 7)];
                    dayStr = line[(i + 8)..(i + 10)];
                    break;
                }
            }

            var dobYear = int.Parse(yearStr);
            var dob = new DateTime(dobYear, int.Parse(monthStr), int.Parse(dayStr));

            // Calculate the age.
            var personAge = year - dobYear;

            // Go back to the year in which the person was born in case of a leap year
            if (dob > today.AddYears(-personAge)) personAge--;

            if (personAge > age)
            {
                totalCount++;
            }
        }

        return totalCount;
    }

    public int CountUniqueInitials()
    {
        string? line;
        HashSet<(char a, char b)> uniqueInitials = [];
        while ((line = streamReader.ReadLine()) is not null)
        {
            char firstChar = line[line.IndexOf('\t') + 1];
            char secondChar = line[line.IndexOf(' ') + 1];
            uniqueInitials.Add((firstChar, secondChar));
        }
        return uniqueInitials.Count;
    }

    public bool CheckIfIdsAreSequential()
    {
        string? line;
        var sequence = 1;
        while ((line = streamReader.ReadLine()) is not null)
        {
            if (sequence != int.Parse(line[..line.IndexOf('\t')].ToString()))
            {
                return false;
            }

            sequence++;
        }

        return true;
    }

    public IEnumerable<KeyValuePair<string, int>> GetStatesPopulation()
    {
        string? line;
        Dictionary<string, int> pops = new();
        while ((line = streamReader.ReadLine()) is not null)
        {
            var state = line[(line.LastIndexOf('\t') + 1)..];
            if (!pops.TryGetValue(state, out var pop))
            {
            }
            pops[state] = pop + 1;
        }

        return pops;

    }

    public void GetAgeStats(int year, int month, int day, out int min, out int max, out int avg)
    {
        min = default;
        max = default;

        double avgD = default;

        var today = new DateTime(year, month, day);

        string? line;
        var totalCount = 0;
        while ((line = streamReader.ReadLine()) is not null)
        {
            totalCount++;

            var tabsCount = 0;
            string yearStr = default!, monthStr = default!, dayStr = default!;

            var lineLength = line.Length;
            for (int i = 0; i < lineLength; i++)
            {
                var c = line[i];

                if (c == '\t')
                {
                    tabsCount++;
                }
                else if (tabsCount is 2)
                {
                    yearStr = line[i..(i + 4)];
                    monthStr = line[(i + 5)..(i + 7)];
                    dayStr = line[(i + 8)..(i + 10)];
                    break;
                }
            }

            var dob = new DateTime(int.Parse(yearStr), int.Parse(monthStr), int.Parse(dayStr));

            // Calculate the age.
            var personAge = today.Year - dob.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dob.Date > today.AddYears(-personAge)) personAge--;

            if (personAge > max)
            {
                max = personAge;
            }

            if (personAge < min)
            {
                min = personAge;
            }

            avgD += personAge;
        }

        avgD /= totalCount;
        avg = (int)Math.Round(avgD);
    }

    public void Dispose()
    {
        streamReader.Dispose();
    }
}
