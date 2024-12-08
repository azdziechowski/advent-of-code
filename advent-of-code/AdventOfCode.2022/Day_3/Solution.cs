using System;
using System.IO;
using System.Linq;

namespace AoC.Day_3;

public class Solution
{
    public static void Run()
    {
        var lines = File.ReadAllLines( "input.txt");

        // #region part1
        //
        // var sum = 0;
        // foreach (var line in lines)
        // {
        //     var firstCompartment = line.Take(line.Length / 2);
        //     var secondCompartment = line.TakeLast(line.Length / 2);
        //     var intersection = firstCompartment.Intersect(secondCompartment);
        //     foreach (var c in intersection)
        //     {
        //         if (char.IsLower(c))
        //         {
        //             sum += c - 'a' + 1;
        //         }
        //         else
        //         {
        //             sum += c - 'A' + 27;
        //         }
        //     }
        // }
        //
        // Console.WriteLine(sum);
        // #endregion

        #region part2
        var sum = 0;
        for (var i = 0; i < lines.Length; i += 3)
        {
            var intersection = lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]);
            foreach (var c in intersection)
            {
                if (char.IsLower(c))
                {
                    sum += c - 'a' + 1;
                }
                else
                {
                    sum += c - 'A' + 27;
                }
            }
        }

        Console.WriteLine(sum);
        #endregion
        
    }
}