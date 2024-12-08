using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode._2024;

[TestFixture]
public class Day6
{
    private const string TestInput =
        """
        ....#.....
        .........#
        ..........
        ..#.......
        .......#..
        ..........
        .#..^.....
        ........#.
        #.........
        ......#...
        """;

    private const string Input =
        """
        ..........#.....................#...................#.......................................................................#....#
        .........#................................................................#....##......#........##.............#..................
        ............#..............#..#.................................................................#.................................
        ..............#.....#................................................................................#...........................#
        ............................................................................................................#.............#.......
        .........#..........##......................................#......................................#......#...#.......#...#.....#.
        ..#...................................................#.................#....#........#.....#.................#...................
        .....#............#.#..#..................#.......................#................................#......#..............#........
        #.................................................................#..........#.......................................#.#..........
        ..##...................#..................................#..#.................................#...#..#.#.#.........#...##........
        ..#..........................#...............#...............#..........................#.................................#.......
        ................##......#......#......................##.............#........#................................#.#..#.............
        .............................................................#.#.......................................................#..........
        .....##.............................................#.......................#...............#...............#..#...#....#.........
        .#.........................#..................................#..........#....#...............................................#...
        .......................#..#.............#......#.....#..#................................................#....#........#..........
        ...............#.....................#................#...................................#......#........................#.......
        .......................#....#..............#.......#...........................#....................................#.#...........
        ..#..................#...........#........................#............#...................#......................#.............#.
        ..............................................#........................................#..............#...........#.........#.....
        ............#.................#...#..........#.#.....................##.........#................##...........##............#.....
        ..................#.......#..................................................................#....#..................#.......#....
        ..........##......#...............................................#.................................#.......#.............#.......
        ................................................................................#.......................................#.........
        .....#........................#.............##......................#.......#.......#...............................#.............
        ..#.......................................##........#.............#...............................................#...............
        .............#.....#..........................................#...................#.................................#..........#..
        .........#............#..#....................#............##.............#..................................#....................
        ........................................................#..........#.............................#................................
        ......................#..............................................................................................#............
        .......#............#..#........................#...............#.......#.............................#......................#....
        ...................................................................................#........................#........#..#.....#.#.
        ..#.......#......#...................................................................................#..#.....#................#..
        .....#...#......................................................#...................#.#..............................#.#..........
        ..#.#.....................#....................#...........#.................#........#..#.........#........#..................#..
        ....#......#.......#.....................................................##...........#...........................................
        ........................#......#......................#......#.....................................................#.......#......
        ............................................................#..........................#...#.#..................................#.
        .#..........#..............................#.....#.............................................#..................................
        #..........................................#......#.............#...........................................#.........#...........
        ......#...............................#..#......................#.....#.......#.....#..#......................#.......#...........
        ........................................#..#.................................#......#.......................#.....................
        .#................#...........#.........#.............................................................#...........................
        .....#.......................#....................................................................................................
        .............#................#............................................#...........#......................#..................#
        #........................#....#.....................#................#..##.............#......................#...#...............
        ....#....................#....#.#..................#...........................................................#......##..........
        #............#..........##............................................................#...........................................
        ...........#..................................#..##................#..............................................................
        ..........................#..............................................................................#...............#........
        .......................................................................#...........#...#...........#..#.....#..................#..
        .........................#....#.......#......................#....................................#...............................
        ..#..................#...................................................#......................................#.................
        ..............#....##........................................#..................#.................................................
        ..........................#............................................#...................#............................#.........
        ......#...............................#..........................#.............................#..................................
        ...................................#.............................................................#..............#.................
        .................#...#.......#..............#.#...........................................#.......#.....#.........................
        ........................#.......................................#..#.........................#...##...#...........................
        ....#..#.............#........#.............#..........#......#.........................................#....#..#.................
        .......................................................................#...........#......#.....................#...........#.....
        #.#..............................#................................................................................................
        .#.................................................#...................#..........................................................
        ..............................#.............#.............................#.....#............#....................................
        .#...............................#.......#...##.#.................#............................................#..................
        .............#....#.................#.........#..............#....#...............................................................
        ......................#.#..........................................................................#................#.............
        .#....................#.....#................#.....................#..................#......................#....................
        .............#.#............#......................................#.......................#......................#...............
        .#..#...#...................#.....................................................................................................
        ...........................................................................#.....................#................................
        ...........#.............................#......#.................................................................................
        ..............#.................................................#.##........#..........................#.........................#
        ..................#...#...........................................................................................................
        ........#.....#......................#..#....#...#.#......................................#.#............#........................
        .....#..#.........................................................#......#.....#...........#..................#...#..........#....
        ......#.........................................#......................#........#...................................#.............
        ..........................................#........................#........#.............#........#..#...........................
        .......#..............#...................#...........................................#.............#.............................
        ..............#....#....#......#...........................................................#..........................#...........
        ..................................................................................#.......#...................#...#....#..........
        .................#........................#........#...#.....................................................#........#...........
        ...........................#......^.#..............#.#.....................#.#...........#....##.......#..........................
        .............#.....#.........................................................................#..........#......#..#.#.............
        ...................................................................#.......#.......#...........................................#..
        .......#.........#.......................#...................................................................#..........#.....#..#
        .....................#...............#...#..#.....................................................#.....##.##..........#..........
        .......................#.......#..................................#.................#.....................................#.......
        ................................................#........#....................#........................#..........................
        ......#....#..#....#.......................#....#...#.............................#............................#......#...........
        ...................................................................................................##.#.....#.................#...
        .................#...#....................#........................#...............##.....#...........#........#.............#....
        .....#............#......................................................................#................#....#..................
        ........#.............#..................................................................#....#.......#...........................
        .#.......................................#.......................................#....#.............................#.............
        ...#.............................#..................#............................#.....................#.....#...........#........
        ....#......#.................................................................................................................#....
        .....................................#..........#.............#......................................#............................
        ..#...#....#............#.....................................................#..#................................................
        .....#.......................................................#............#..........................#...........#................
        #.....................#..............#................................................#..........................#......#........#
        ........#.........................#........................#................#.......................#.............................
        ...........................#........#............................#.......#..............#.........................................
        ......###.........................................................................#.........#........#................#...#.......
        ............#........................#................#.................#........................#.............#.......#..........
        ........#.#................................#.....................................................#................................
        .#...#............#........#........#..#...............................................#............................#............#
        ...#.............#.........#....................................#..............#.......................................##.........
        ...#...........#.....................................#.........#................#......................#............#.............
        ..................#....................................................##.......##..........#...............................##....
        ........................#.........#...........#............................................................###....................
        ....................#.......#....................................................#...#..............................#............#
        ............................#.....................................................................................................
        ......#........#........................#..........#..........#.......#..........................#................................
        ....................................#..............#...#.#......................................................................#.
        .....#.....#...#..............................................###......#..............#.........##......#...............#.........
        ........................#.........................#...............#...............#.#........#.....................#.#............
        ...............#..............#........#........................................#..........#........#......#......................
        .....................#..........................#...............................#........#.......#.....#...................#......
        .........#...........................................#.............................#....#.......#......#..#....#..................
        .........#...#........#....................#.......#..#...#..............................................................#........
        ..................#......................................#........................................................................
        ........#.....................................................#..#...........#........#......................#...#....#.....#.....
        ...........................#........#....#.........................................................#.............#................
        .....#.#.........#................................................................................#...............................
        ...#............................................#......................#.......#.#...............#............#...................
        .........#................................#.....#...........#.#....................#...#.....................................#.#..
        ..........#.#....#......#.........#....#.....#........#...........................#...............................................
        ............#...............#............#..........#.............................#...............................................
        #.#............#.....................##................................................#....#.................##..................
        """;

    [TestCase(TestInput, "41")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput, "6")]
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
        var map = input.Split("\n")
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();

        int x = -1, y = -1;
        for (var i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == '^')
                {
                    x = i;
                    y = j;
                    break;
                }
            }

            if (x != -1) break;
        }

        (int xTrans, int yTrans)[] dirs = [(-1, 0), (0, 1), (1, 0), (0, -1)];
        var dirIdx = 0;

        var seen = new HashSet<(int, int)> { (x, y) };
        while (true)
        {
            var tempX = x + dirs[dirIdx].xTrans;
            var tempY = y + dirs[dirIdx].yTrans;

            if (tempX < 0 || tempX >= map.Length || tempY < 0 || tempY >= map[0].Length)
                break;

            if (map[tempX][tempY] == '#')
            {
                dirIdx = ++dirIdx % dirs.Length;
                continue;
            }

            x = tempX;
            y = tempY;
            seen.Add((x, y));
        }

        var result = seen.Count;
        return result.ToString();
    }

    private static string Solution2(string input)
    {
        var map = input.Split("\n")
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();

        (int xTrans, int yTrans)[] dirs = [(-1, 0), (0, 1), (1, 0), (0, -1)];

        var obstacles = new List<(int x, int y)>();
        for (var i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == '.')
                {
                    obstacles.Add((i, j));
                }
            }
        }

        var total = 0;
        foreach (var obstacle in obstacles)
        {
            var dirIdx = 0;
            int x = -1, y = -1;
            for (var i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (map[i][j] == '^')
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }

                if (x != -1) break;
            }

            var seen = new HashSet<(int, int, int)> { (x, y, dirIdx) };
            while (true)
            {
                var tempX = x + dirs[dirIdx].xTrans;
                var tempY = y + dirs[dirIdx].yTrans;

                if (tempX < 0 || tempX >= map.Length || tempY < 0 || tempY >= map[0].Length)
                    break;

                if (map[tempX][tempY] == '#' || (tempX == obstacle.x && tempY == obstacle.y))
                {
                    dirIdx = ++dirIdx % dirs.Length;
                    continue;
                }

                x = tempX;
                y = tempY;

                if (seen.Contains((x, y, dirIdx)))
                {
                    // we've already been here in the same position before, so we have a loop
                    total++;
                    break;
                }

                seen.Add((x, y, dirIdx));
            }
        }
        
        var result = total;
        return result.ToString();
    }
}