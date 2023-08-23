using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace TechTalks.Enumerables;

[MemoryDiagnoser]
[LongRunJob(RuntimeMoniker.Net60)]
public class ListContainsBenchmark
{
    private List<string> _list = null!;

    [GlobalSetup]
    public void SetUp()
    {
        _list = new(8) { "True", "a", "b", "c", "d", "e", "f", "g" };
    }

    [Params("True", "false")]
    public string Value { get; set; } = null!;

    [Benchmark]
    public bool Any() => _list.Any(p => p == Value);

    [Benchmark]
    public bool Exists() => _list.Exists(p => p == Value);

    [Benchmark]
    public bool Contains() => _list.Contains(Value);
}
