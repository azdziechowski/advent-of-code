namespace AdventOfCode._2024;

[TestFixture]
public class Day8
{
    private const string TestInput =
        """
        ............
        ........0...
        .....0......
        .......0....
        ....0.......
        ......A.....
        ............
        ............
        ........A...
        .........A..
        ............
        ............
        """;

    private const string Input =
        """
        ...............e...........j6.....................
        .....1...............................t.....i......
        .....4.......3..............x..tL......m..........
        .......L.....................Dxj..................
        4....X..................F.....................m...
        .............4.......x....F........k..............
        ......3...................t..........i.........Z..
        ....L..................y.....F..e.....Z...........
        X.............1........C..........i...D...........
        ........4.....................D.....k.X...m.......
        ...1...............D........e......6..............
        ...3.Y...................................m8.......
        ..OL.........................x....Z....g..........
        ....3......5.........................6j...........
        ...................J..5r.F..k...y.................
        .......................................Z..a.......
        ...........................5........j.........a.u.
        ...p..............Y....X..........................
        ...O.........................kd...................
        ........................t.................i.......
        ..................J..............u...........z....
        .O.....9.............J..............p..u..........
        .....9............................................
        l...6.....1........e......I................a......
        ...................................az.............
        ........M.......J...................gI....z.......
        .......Y...l...........p......g....d.......W......
        ........5l....9................d.....g............
        .A....9.l.Y............I..............B.......s...
        ..................................K.....B.........
        ....M.............7.......8..........h.....K......
        .......0f...oc..............G...d7.......z...s..yW
        ...M........0...........Gf.....................T..
        ................r......G..................w....h..
        ...........cP................G.8.R..............T.
        .................A.............N............u..B..
        ..H.c..b............................K...CB.....y..
        ......c...bP...2............7..K..................
        ......b.o....0.......P.............s........h.R...
        ......2........f..S........8.....................R
        U....2..............p..............7..............
        .HE..b......A.............N..............w....C...
        ................................N.............w...
        .........E...........M................W.......T...
        ......E...rS2...........W....................N....
        .....SP..n.....r..0...............................
        .....H..............A............................w
        ..........n..U....................s...............
        ..n.So.....U................f.....................
        Ho................................................
        """;

    [TestCase(TestInput, "14")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput, "34")]
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
        var map = input.Split('\n')
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();

        var dict = new Dictionary<char, List<(int, int)>>();

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                var node = map[i][j];
                if (node != '.')
                {
                    if (dict.TryGetValue(node, out var list))
                    {
                        list.Add((i, j));
                    }
                    else
                    {
                        dict[node] = [(i, j)];
                    }
                }
            }
        }

        var antinodesSet = new HashSet<(int, int)>();

        foreach (var nodes in dict.Select(kv => kv.Value))
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                for (var j = 0; j < nodes.Count; j++)
                {
                    if (i == j)
                        continue;

                    var a = nodes[i];
                    var b = nodes[j];
                    var antinode = (a.Item1 + (a.Item1 - b.Item1), a.Item2 + (a.Item2 - b.Item2));
                    if (antinode.Item1 < 0 || antinode.Item2 < 0 || antinode.Item1 >= map.Length ||
                        antinode.Item2 >= map[0].Length)
                    {
                        // outside the map
                    }
                    else
                    {
                        antinodesSet.Add(antinode);
                    }
                }
            }
        }

        return antinodesSet.Count.ToString();
    }

    private static string Solution2(string input)
    {
        var map = input.Split('\n')
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();

        var dict = new Dictionary<char, List<(int, int)>>();

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                var node = map[i][j];
                if (node != '.')
                {
                    if (dict.TryGetValue(node, out var list))
                    {
                        list.Add((i, j));
                    }
                    else
                    {
                        dict[node] = [(i, j)];
                    }
                }
            }
        }

        var antinodesSet = new HashSet<(int, int)>();

        foreach (var nodes in dict.Select(kv => kv.Value))
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                for (var j = 0; j < nodes.Count; j++)
                {
                    if (i == j)
                        continue;

                    var a = nodes[i];
                    var b = nodes[j];

                    antinodesSet.Add((a.Item1, a.Item2));
                    antinodesSet.Add((b.Item1, b.Item2));

                    var xTrans = (a.Item1 - b.Item1);
                    var yTrans = (a.Item2 - b.Item2);

                    while (true)
                    {
                        var antinode = (a.Item1 + xTrans, a.Item2 + yTrans);
                        if (antinode.Item1 < 0 || antinode.Item2 < 0 || antinode.Item1 >= map.Length ||
                            antinode.Item2 >= map[0].Length)
                        {
                            // outside the map
                            break;
                        }

                        antinodesSet.Add(antinode);
                        a = antinode;
                    }
                }
            }
        }

        return antinodesSet.Count.ToString();
    }
}