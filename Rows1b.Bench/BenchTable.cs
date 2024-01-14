using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Rows1b.Shared;
using Rows1b.Solution.EX;
using Rows1b.Solution.HA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rows1b.Bench;

public class BenchTable(Func<IResultsProducer> Get)
{
    public bool CheckIfIdsAreSequential()
    {
        using var producer = Get();
        return producer.CheckIfIdsAreSequential();
    }

    public int CountOlderThan()
    {
        using var producer = Get();
        return producer.CountOlderThan(50, 2024, 02, 01);
    }

    public int CountUniqueInitials()
    {
        using var producer = Get();
        return producer.CountUniqueInitials();
    }

    public IEnumerable<KeyValuePair<string, int>> GetStatesPopulation()
    {
        using var producer = Get();
        return producer.GetStatesPopulation();
    }

    public void GetAgeStats(out int min, out int max, out int avg)
    {
        using var producer = Get();
        producer.GetAgeStats(2024, 02, 01, out min, out max, out avg);
    }
}
