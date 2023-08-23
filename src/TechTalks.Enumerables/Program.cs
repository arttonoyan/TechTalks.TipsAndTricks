using BenchmarkDotNet.Running;

namespace TechTalks.Enumerables;

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ListContainsBenchmark>();
    }
}
