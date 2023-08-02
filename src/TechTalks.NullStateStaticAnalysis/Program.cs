namespace TechTalks.NullState.StaticAnalysis;

//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis
internal class Program
{
    static void Main(string[] args)
    {
        Test_Member();
        Test_Enumerable();
    }

    private static void Test_Member()
    {
        var partition = new Partition();
        if (partition.HasParent)
        {
            Console.WriteLine($"Partition has parent with id Length {partition.ParentId.Length}");
        }
        else
        {
            Console.WriteLine("Partition has no parent");
        }
    }

    private static void Test_Enumerable()
    {
        var numbers = CreateNumbersOrNull();
        if (numbers.IsNullOrEmpty())
        {
            Console.WriteLine("Numbers is null or empty");
        }
        else
        {
            Console.WriteLine($"Numbers is not null or empty, Count={numbers.Count}");
        }

        //string.IsNullOrEmpty("Test");
    }

    public static List<int>? CreateNumbersOrNull(int count = 5)
    {
        return Enumerable.Range(0, count).ToList();
    }
}
