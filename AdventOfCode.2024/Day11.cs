namespace AdventOfCode._2024;

[TestFixture]
public class Day11
{
    private const string TestInput =
        """
        125 17
        """;

    private const string Input =
        """
        475449 2599064 213 0 2 65 5755 51149
        """;

    [TestCase(TestInput, "55312")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase("", "")]
    public void Part2(string input, string expectedOutput)
    {
        // No test cases given
        
        var actualOutput = Solution2(Input);
        Console.WriteLine($"{nameof(Part2)} actual result: {actualOutput}");
    }

    private static readonly Dictionary<string, List<string>> _memo = new();

    private static string Solution1(string input)
    {
        var stones = input.Trim().Split(' ').Select(x => x.Trim()).ToList();
        for (var i = 0; i < 25; i++)
        {
            stones = GetNext(stones);
        }

        return stones.Count.ToString();
    }

    private static List<string> GetNext(List<string> stones)
    {
        // If the stone is engraved with the number 0, it is replaced by a stone engraved with the number 1.
        // If the stone is engraved with a number that has an even number of digits, it is replaced by two stones.
        //     The left half of the digits are engraved on the new left stone,
        //     and the right half of the digits are engraved on the new right stone.
        //     (The new numbers don't keep extra leading zeroes: 1000 would become stones 10 and 0.)
        // If none of the other rules apply, the stone is replaced by a new stone; the old stone's number multiplied by 2024 is engraved on the new stone.

        var results = new List<string>();
        foreach (var stone in stones)
        {
            if (_memo.TryGetValue(stone, out var next))
            {
                results.AddRange(next);
                continue;
            }
            
            var result = stone switch
            {
                "0" => new List<string> { "1" },
                _ when stone.Length % 2 == 0 => new List<string>
                    { stone.Substring(0, stone.Length / 2), long.Parse(stone.Substring(stone.Length / 2)).ToString() },
                _ => new List<string> { (long.Parse(stone) * 2024).ToString() }
            };

            _memo.Add(stone, result);
            results.AddRange(result);
        }
        
        return results;
    }

    private static string Solution2(string input)
    {
        return "";
    }
}