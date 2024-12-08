using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022.Day_4;

public class Solution
{
    public static void Run()
    {
        var lines = File.ReadAllLines("input.txt");

        // #region part1
        //
        // var count = 0;
        // foreach (var line in lines)
        // {
        //     var split = line.Split(",");
        //     var first = split.First().Split("-").Select(int.Parse).ToArray();
        //     var second = split.Last().Split("-").Select(int.Parse).ToArray();
        //
        //     if (first.First() == second.First() || first.Last() == second.Last())
        //     {
        //         count++;
        //     }
        //     else if (first.First() < second.First() && first.Last() > second.Last())
        //     {
        //         count++;
        //     }
        //     else if (second.First() < first.First() && second.Last() > first.Last())
        //     {
        //         count++;
        //     }
        // }
        //
        // Console.WriteLine(count);
        //
        // #endregion

        #region part2

        var count = 0;
        foreach (var line in lines)
        {
            var split = line.Split(",");
            var a = split.First().Split("-").Select(int.Parse).ToArray();
            var b = split.Last().Split("-").Select(int.Parse).ToArray();

            int[] left, right;
            if (a.First() < b.First())
            {
                left = a;
                right = b;
            }
            else
            {
                left = b;
                right = a;
            }

            if (left.Last() >= right.First()) count++;



        }
        
        Console.WriteLine(count);

        #endregion
    }
}