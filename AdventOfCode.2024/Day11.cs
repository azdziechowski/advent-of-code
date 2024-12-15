using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode._2024;

[TestFixture]
public class Day11
{
    private static Dictionary<(string, int), long> _memo = new();

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

    [TestCase(TestInput, "")]
    public void Part2(string input, string expectedOutput)
    {
        // no test input available

        var actualOutput = Solution2(Input);
        Console.WriteLine($"{nameof(Part2)} actual result: {actualOutput}");
    }

    private static string Solution1(string input)
    {
        var stones = input.Trim()
            .Split(' ')
            .Select(x => x.Trim())
            .ToList();
        
        Console.WriteLine(string.Join(", ", stones));
        for (var i = 0; i < 25; i++)
        {
            var newStones = new List<string>();    
            foreach (var stone in stones)
            {
                newStones.AddRange(Blink(stone));
            }
            stones = newStones;
            Console.WriteLine(string.Join(", ", stones));
        }    
        
        return stones.Count.ToString();
    }

    private static List<string> Blink(string stone)
    {
        // If the stone is engraved with the number 0, it is replaced by a stone engraved with the number 1.
        // If the stone is engraved with a number that has an even number of digits, it is replaced by two stones.
        //     The left half of the digits are engraved on the new left stone,
        //     and the right half of the digits are engraved on the new right stone.
        //     (The new numbers don't keep extra leading zeroes: 1000 would become stones 10 and 0.)
        // If none of the other rules apply, the stone is replaced by a new stone; the old stone's number multiplied by 2024 is engraved on the new stone.
        return stone switch
        {
            "0" => ["1"],
            _ when stone.Length % 2 == 0 => [stone[..(stone.Length / 2)], long.Parse(stone[(stone.Length / 2)..]).ToString()],
            _ => [(long.Parse(stone) * 2024).ToString()]
        };
    }

    private static string Solution2(string input)
    {
        var stones = input.Trim()
            .Split(' ')
            .Select(x => x.Trim())
            .ToList();

        long total = 0;
        foreach (var stone in stones)
        {
            total += GetCount(stone, 75);
        }

        return total.ToString();

    }

    private static long GetCount(string stone, int iterations)
    {
        if (iterations == 0)
        {
            return 1;
        }
        
        if(_memo.TryGetValue((stone, iterations), out var result))
            return result;

        long total = 0;
        var next = Blink(stone);
        foreach (var n in next.GroupBy(n => n))
        {
            total += n.ToList().Count * GetCount(n.Key, iterations - 1);
        }

        _memo.Add((stone, iterations), total);
        
        return total;
    }
}