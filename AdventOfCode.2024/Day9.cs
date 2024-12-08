namespace AdventOfCode._2024;

[TestFixture]
public class Day9
{
    private const string TestInput =
        """
        to_replace
        """;

    private const string Input =
        """
        to_replace
        """;

    [TestCase(TestInput, "")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput, "")]
    public void Part2(string input, string expectedOutput)
    {
        var testOutput = Solution2(input);
        Console.WriteLine($"{nameof(Part2)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution2(Input);
        Console.WriteLine($"{nameof(Part2)} actual result: {actualOutput}");
    }

    private static string Solution1(string input)
    {
        return "";
    }

    private static string Solution2(string input)
    {
        return "";
    }
}