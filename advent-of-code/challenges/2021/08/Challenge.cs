using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code.challenges._2021._08
{
    public class Challenge : ChallengeBase
    {
        
        public static Dictionary<int, string> dictionary = new Dictionary<int, string>()
        {
            { 0, "abcefg" },
            { 1, "cf" },
            { 2, "acdeg" },
            { 3, "acdfg" },
            { 4, "bcdf" },
            { 5, "abdfg" },
            { 6, "abdefg" },
            { 7, "acf" },
            { 8, "abcdefg" },
            { 9, "abcdfg" },
        };

        public static Dictionary<char, int> frequency = new Dictionary<char, int>()
        {
            { 'a', 8 },
            { 'b', 6 },
            { 'c', 8 },
            { 'd', 7 },
            { 'e', 4 },
            { 'f', 9 },
            { 'g', 7 }
        };

        public static void Run()
        {
            var input = File.ReadAllLines("input.txt");
            
            long total = 0;
            
            foreach (var s in input)
            {
                var split = s.Split(" | ");
                var leftPart = split.First().Trim().Split(" ").Select(s => s.Trim()).ToList();
                var rightPart = s.Split(" | ").Last().Trim().Split(" ").Select(s => s.Trim()).ToList();
                total += Decode(leftPart, rightPart);
            }
            
            Console.WriteLine(total);
        }

        private static long Decode(List<string> leftPart, List<string> rightPart)
        {
            var freq = new Dictionary<char, int>
                {
                    {'a', 0},
                    {'b', 0},
                    {'c', 0},
                    {'d', 0},
                    {'e', 0},
                    {'f', 0},
                    {'g', 0}
                };
            
            foreach (var c in "abcdefg")
            {
                foreach (var s in leftPart)
                {
                    if (s.Contains(c))
                        freq[c]++;
                }
            }

            var truths = new Dictionary<char, char>
                {
                    {freq.Single(kv => kv.Value == 6).Key, 'b'},
                    {freq.Single(kv => kv.Value == 4).Key, 'e'},
                    {freq.Single(kv => kv.Value == 9).Key, 'f'},
                };
            
            var digit1 = leftPart.Single(s => s.Length == 2);
            var mapsToC = digit1.Single(c => c != truths.Single(kv => kv.Value == 'f').Key);
            truths.Add(mapsToC, 'c');

            var digit7 = leftPart.Single(s => s.Length == 3);
            var mapsToA = digit7.Single(c => c != truths.Single(kv => kv.Value == 'f').Key && c != truths.Single(kv => kv.Value == 'c').Key);
            truths.Add(mapsToA, 'a');

            var digit4 = leftPart.Single(s => s.Length == 4);
            var mapsToD = digit4.Single(c => c != truths.Single(kv => kv.Value == 'b').Key
                                             && c != truths.Single(kv => kv.Value == 'c').Key
                                             && c != truths.Single(kv => kv.Value == 'f').Key);
            truths.Add(mapsToD, 'd');

            foreach (var c in "abcdefg")
            {
                if (!truths.Keys.Contains(c))
                {
                    truths.Add(c, 'g');
                    break;
                }
            }

            var resultDigits = new List<int>();
            
            foreach (var s in rightPart)
            {
                var str = new string(s.Select(c => truths[c]).OrderBy(c => c).ToArray());
                resultDigits.Add(dictionary.Single(kv => kv.Value == str).Key);
            }

            var stringResult = new string(resultDigits.Select(digit => digit.ToString().Single()).ToArray());
            return long.Parse(stringResult);
        }

        public override void RunPart1()
        {
            throw new NotImplementedException();
        }

        public override void RunPart2()
        {
            throw new NotImplementedException();
        }
    }
}