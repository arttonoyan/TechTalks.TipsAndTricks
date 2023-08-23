using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace TechTalks.Enumerables;

[MemoryDiagnoser]
[LongRunJob(RuntimeMoniker.Net60)]
public class ListHasItemsBenchmark
{
    private List<string> _list = null!;

    [GlobalSetup]
    public void SetUp()
    {
        _list = new() { "a", "b", "c", "d", "e", "f", "g" };
    }

    [Benchmark(Description = "List.Any()")]
    public bool Any_List() => _list.Any();

    [Benchmark(Description = "List.Count > 0")]
    public bool Count_List() => _list.Count > 0;
}
