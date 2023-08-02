using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace TechTalks.SimpleStringConcatention.Benchmarks;

[MemoryDiagnoser]
[LongRunJob(RuntimeMoniker.Net60)]
//[LongRunJob(RuntimeMoniker.Net70)]
//[LongRunJob(RuntimeMoniker.Net80)]
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
    public string StringPlus()
    {
        return title + ' ' + firstName + ' ' +
            middleName + ' ' + lastName;
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1} {2} {3}",
            title, firstName, middleName, lastName);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return
        $"{title} {firstName} {middleName} {lastName}";
    }

    [Benchmark(Baseline = true)]
    public string StringJoin()
    {
        return string.Join(" ", title, firstName, //changed from ' ' to " " for net48
            middleName, lastName);
    }

    [Benchmark]
    public string StringConcat()
    {
        return string.
            Concat(new String[] { title, " ", firstName, " ", middleName, " ", lastName });
    }
}
