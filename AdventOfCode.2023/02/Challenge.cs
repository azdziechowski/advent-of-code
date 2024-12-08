using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code._02;

public class Challenge : ChallengeBase
{
    public override void RunPart1()
    {
        var limits = new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };

        var input = ReadInput();
        var sum = 0;
        foreach (var line in input)
        {
            var (gameId, sets) = Split(line);

            var possible = true;
            foreach (var set in sets)
            {
                var dictionary = set
                    .Select(s => s.Split())
                    .ToDictionary(arr => arr.Last(), arr => int.Parse(arr.First()));  // { "blue": 3, "red": 4, .. }

                foreach (var (color, count) in dictionary)
                {
                    if (limits[color] >= count) continue;
                    possible = false;
                    break;
                }
            }

            if (possible) sum += int.Parse(gameId);
        }

        Console.WriteLine(sum);
    }
    
    public override void RunPart2()
    {
        var input = ReadInput();
        var sum = 0;
        foreach (var line in input)
        {
            var minimums = new Dictionary<string, int> { { "red", 0 }, { "green", 0 }, { "blue", 0 } };

            var (_, sets) = Split(line);

            foreach (var set in sets)
            {
                var dictionary = set
                    .Select(s => s.Split())
                    .ToDictionary(arr => arr.Last(), arr => int.Parse(arr.First()));  // { "blue": 3, "red": 4, .. }

                foreach (var (color, count) in dictionary)
                {
                    if (minimums[color] >= count) continue;
                    minimums[color] = count;
                }
            }

            sum += minimums.Values.Aggregate((l, r) => l * r);
        }

        Console.WriteLine(sum);
    }

    private (string gameId, string[][] sets) Split(string line)
    {
        // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        var split = line.Split(":");
        
        var gameId = split.First() // Game 1
             .Split()// [Game, 1]
            .Last(); // 1

        var sets = split.Last() // 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            .Split(";").Select(l => l.Trim()) //  [ "3 blue, 4 red", "1 red, 2 green, 6 blue", "2 green"
            .Select(l =>
                l.Split(", ")) //  [["3 blue"], ["4 red"]], [["1 red"],  ["2 green"], ["6 blue"]], [["2 green"]]
            .ToArray();
        
        return (gameId: gameId, sets: sets);
    }
}