namespace TechTalks.ThrowHelpers;

//https://github.com/dotnet/runtime/issues/86341?fbclid=IwAR3VIAvIhst2f9i7DRitB1pTtpQD6AD7gIBqY_FWxNALiAWdcMrPKgCwIbM
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Test_ThrowIfNullOrEmptyWithMethod("");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadLine();
    }

    #region Standard

    private static void Test_ThrowIfNullOrEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("The value cannot be an empty string.", nameof(input));
        }

        Console.WriteLine($"Input value is {input}");
    }

    #endregion

    #region With Method

    private static void Test_ThrowIfNullOrEmptyWithMethod(string input)
    {
        ThrowIfNullOrEmpty(input);

        Console.WriteLine($"Input value is {input}");
    }

    private static void ThrowIfNullOrEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("The value cannot be an empty string.", nameof(input));
        }
    }

    #endregion

    #region With Extension Method

    private static void Test_ThrowIfNullOrEmptyWithExtensionMethod(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        Console.WriteLine($"Input value is {input}");
    }

    #endregion
}
