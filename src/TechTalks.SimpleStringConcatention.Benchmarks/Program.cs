using BenchmarkDotNet.Running;

namespace TechTalks.SimpleStringConcatention.Benchmarks;

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<StringConcatSimple>();
    }
}
