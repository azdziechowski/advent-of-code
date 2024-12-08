using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021._11
{
    public class Challenge : ChallengeBase
    {
        private static Dictionary<(int, int), Octopus> octopi = new Dictionary<(int, int), Octopus>();

        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt");

            var n = lines.First().Length;
            Debug.Assert(lines.Length == n);

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var c = lines[i].ToCharArray()[j];
                    var level = c - 48;
                    var octopus = GetOrCreateOctopus(i, j, level);
                    var adjCoords = GetAdjCoords(i, j, n);
                    foreach (var adjCoord in adjCoords)
                    {
                        var x = i + adjCoord.Item1;
                        var y = j + adjCoord.Item2;
                        var neighbour = GetOrCreateOctopus(x, y, lines[x].ToCharArray()[y] - 48);
                        octopus.Adj.Add(neighbour);
                    }
                }
            }

            
            long totalFlashes = 0;
            for (int step = 0; step < 10000; step++)
            {
                foreach (var octopus in octopi.Values)
                {
                    var flashes = octopus.Increment(step);
                    totalFlashes += flashes;
                }

                #region part2
                var allFlashed = octopi.All(o => o.Value.LastFlashedAt == step);
                if (allFlashed)
                {
                    Console.WriteLine($"All flashed at step: {step + 1}");
                    return;
                }
                #endregion


                // Print(n);
            }
            Console.WriteLine(totalFlashes);
        }

        private static void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(octopi[(i, j)].Lvl);
                }

                Console.WriteLine();
            }
        }

        private static Octopus GetOrCreateOctopus(int x, int y, int level)
        {
            if (octopi.TryGetValue((x, y), out var octopus))
                return octopus;

            octopus = new Octopus(x, y, level);
            octopi[(x, y)] = octopus;
            return octopus;
        }

        private static List<(int, int)> GetAdjCoords(int x, int y, int n)
        {
            var coords = new List<(int, int)>()
            {
                (-1, -1),
                (-1, 0),
                (-1, 1),
                (0, -1),
                (0, 1),
                (1, -1),
                (1, 0),
                (1, 1)
            };

            return coords.Where(coord => 
                    coord.Item1 + x >= 0 && 
                    coord.Item1 + x < n && 
                    coord.Item2 + y >= 0 && 
                    coord.Item2 + y < n)
                .ToList();
        }

        public class Octopus
        {
            public int X { get;  }
            public int Y { get;  }

            public Octopus(int x, int y, int lvl)
            {
                X = x;
                Y = y;
                Lvl = lvl;
            }
            
            public int Lvl { get; private set; } = 0;
            public int LastFlashedAt = -1;
            public List<Octopus> Adj { get; set; } = new List<Octopus>();

            public int Increment(int step)
            {
                if (LastFlashedAt == step)
                {
                    return 0;
                }
                
                Lvl += 1;

                if (Lvl <= 9)
                    return 0;
                
                LastFlashedAt = step;
                Lvl = 0;
                var flashes = 0;
                foreach (var octopus in Adj)
                {
                    flashes += octopus.Increment(step);
                }
                
                return flashes + 1;
            }
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