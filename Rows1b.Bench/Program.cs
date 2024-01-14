using Rows1b.Bench;
using Rows1b.Solution.HA;
using System.Diagnostics;

var bt = new BenchTable(() => new Solution_HA());

RunTest(nameof(bt.GetStatesPopulation), () =>
{
    var states = bt.GetStatesPopulation();
    Console.WriteLine(states.Count());
});

RunTest(nameof(bt.CountUniqueInitials), () =>
{
    var count = bt.CountUniqueInitials();
    Console.WriteLine(count);
});

RunTest(nameof(bt.CheckIfIdsAreSequential), () =>
{
    var check = bt.CheckIfIdsAreSequential();
    Console.WriteLine(check);
});

RunTest(nameof(bt.CountOlderThan), () =>
{
    var count = bt.CountOlderThan();
    Console.WriteLine(count);
});

RunTest(nameof(bt.GetAgeStats), () =>
{
    bt.GetAgeStats(out var min, out var max, out var avg);
    Console.WriteLine($"min {min} max {max} avg {avg}");
});

Console.WriteLine("Completed");

Console.ReadKey();

static void RunTest(string name, Action a)
{
    Console.WriteLine($"Executing {name} ...");
    var ts = Stopwatch.GetTimestamp();

    try
    {
        a.Invoke();
        Console.WriteLine($"Finished {name} in {Stopwatch.GetElapsedTime(ts)}");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.ToString());
    }
}

