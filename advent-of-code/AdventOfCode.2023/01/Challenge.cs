using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code.challenges._2023._01;

public class Challenge : ChallengeBase
{
    public override void RunPart1()
    {
        var input = ReadInput();
        var digits = "0123456789".ToCharArray();
        
        var sum = input
            .Select(l => (line: l, first: l.IndexOfAny(digits), last: l.LastIndexOfAny(digits)))
            .Select(t => new string(new[] { t.line[t.first], t.line[t.last] }))
            .Select(int.Parse)
            .Sum();
        
        Console.WriteLine(sum);
    }

    public override void RunPart2()
    {
        var input = ReadInput();
        var digits = "123456789".Select(c => new string(c, 1)).ToList();
        var digitsSpelledOut = new Dictionary<string, string> { {"one", "1"} , {"two", "2"}, {"three", "3"}, {"four", "4"}, {"five", "5"}, {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"} };

        var sum = 0;
        foreach (var line in input)
        {
            string? first = null;
            for (var i = 0; i < line.Length && first is null; i++)
            {
                var current = line[i].ToString();
                if (digits.Contains(current))
                {
                    first = current;
                    break;
                }

                foreach (var (key, value) in digitsSpelledOut)
                {
                    if (!line[..(i+1)].EndsWith(key)) continue;
                    first = value;
                    break;
                }
            }

            string? last = null;
            for (var i = line.Length - 1; i >= 0 && last is null; i--)
            {
                var current = line[i].ToString();
                if (digits.Contains(current))
                {
                    last = current;
                    break;
                }

                foreach (var (key, value) in digitsSpelledOut)
                {
                    if (!line[i..].StartsWith(key)) continue;
                    last = value;
                    break;
                }
            }


            sum += int.Parse(first + last);
        }

        Console.WriteLine(sum);
    }
}