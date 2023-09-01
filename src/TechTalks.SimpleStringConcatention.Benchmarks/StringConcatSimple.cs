using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace TechTalks.SimpleStringConcatention.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
//[LongRunJob(RuntimeMoniker.Net70)]
//[LongRunJob(RuntimeMoniker.Net80)]
//[SimpleJob(RunStrategy.Monitoring, iterationCount: 10, id: "MonitoringJob")]
public class StringConcatSimple
{
    private string title = "Mr.", firstName = "Artyom", middleName = "Tonoyan", lastName = "Armen";

    [Benchmark]
    public string StringBuilder()
    {
        var stringBuilder =
            new StringBuilder();

        return stringBuilder
            .Append(title).Append(' ')
            .Append(firstName).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).ToString();
    }

    [Benchmark]
    public string StringBuilderExact24()
    {
        var stringBuilder =
            new StringBuilder(24);

        return stringBuilder
            .Append(title).Append(' ')
            .Append(firstName).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).ToString();
    }

    [Benchmark]
    public string StringBuilderEstimate100()
    {
        var stringBuilder =
            new StringBuilder(100);

        return stringBuilder
            .Append(title).Append(' ')
            .Append(firstName).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).ToString();
    }

    [Benchmark]
    public string StringPlus() =>
        title + ' ' + firstName + ' ' + middleName + ' ' + lastName;

    [Benchmark]
    public string StringFormat() =>
        string.Format("{0} {1} {2} {3}", title, firstName, middleName, lastName);

    [Benchmark]
    public string StringInterpolation() =>
        $"{title} {firstName} {middleName} {lastName}";

    [Benchmark(Baseline = true)]
    public string StringJoin() =>
        string.Join(" ", title, firstName, middleName, lastName);

    [Benchmark]
    public string StringConcat() =>
        string.Concat(new string[] { title, " ", firstName, " ", middleName, " ", lastName });
}
