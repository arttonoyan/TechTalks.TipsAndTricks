using BenchmarkDotNet.Attributes;

namespace TechTalks.SimpleStringConcatention.Benchmarks;

//Prefer string.Equals over ToLower/ToUpper
public class StringEqualsSample
{
    private readonly string str1 = "HELLO WORLD";
    private readonly string str2 = "hello world";

    [Benchmark]
    public bool Equals_OrdinalIgnoreCase() =>
        string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool Compare_OrdinalIgnoreCase() =>
        string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase) == 0;

    [Benchmark]
    public bool ToLower() => str1.ToLower() == str2.ToLower();

    [Benchmark]
    public bool ToUpper() => str1.ToUpper() == str2.ToUpper();
}
