using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kattis
{
    public class aoc2021_5
    {
        public static void Run()
        {
            var input = File.ReadAllLines("input.txt");

            var allLines = input.Select(Line.ToLine).ToList();

            // var lines = allLines.Where(l => l.IsHorizontalOrVertical()).ToList();

            var map = new Dictionary<(int, int), int>();

            foreach (var line in allLines)
            {
                if (line.IsHorizontal()) // Y1 == Y2
                {
                    var max = line.X1 > line.X2 ? line.X1 : line.X2;
                    var min = line.X1 < line.X2 ? line.X1 : line.X2;

                    for (int i = min; i <= max; i++)
                    {
                        if (map.TryGetValue((i, line.Y1), out int current))
                        {
                            map[(i, line.Y1)] = current + 1;
                        }
                        else
                        {
                            map[(i, line.Y1)] = 1;
                        }
                    }
                }
                else if(line.IsVertical())// X1 == X2
                {
                    var max = line.Y1 > line.Y2 ? line.Y1 : line.Y2;
                    var min = line.Y1 < line.Y2 ? line.Y1 : line.Y2;

                    for (int i = min; i <= max; i++)
                    {
                        if (map.TryGetValue((line.X1, i), out int current))
                        {
                            map[(line.X1, i)] = current + 1;
                        }
                        else
                        {
                            map[(line.X1, i)] = 1;
                        }
                    }
                }
                // else // diagonal
                // {
                //     if (line.X1 > line.X2 && line.Y1 > line.Y2 ||
                //         line.X1 < line.X2 && line.Y1 < line.Y2)
                //     {
                //         // 7,7 -> 9,9 or 9,9 -> 7,7 => goes from top left to bottom right
                //         var max = line.X1 > line.X2 ? line.X1 : line.X2; // 9
                //         var min = line.X1 < line.X2 ? line.X1 : line.X2; // 7
                //
                //         var current = 0;
                //         while (current + min <= max)
                //         {
                //             if (map.TryGetValue((min + current, min + current), out int val))
                //             {
                //                 map[(min + current, min + current)] = val + 1;
                //             }
                //             else
                //             {
                //                 map[(min + current, min + current)] = 1;
                //             }
                //
                //             current++;
                //         }
                //     }
                //     else
                //     {
                //         // goes from bottom left to upper right, 7,9 => 9,7
                //         var maxX = line.X1 > line.X2 ? line.X1 : line.X2; // 9
                //         var minX = line.X1 < line.X2 ? line.X1 : line.X2; // 7
                //
                //         var current = 0;
                //         while (maxX - current >= minX)
                //         {
                //             if (map.TryGetValue((maxX - current, minX + current), out int val))
                //             {
                //                 map[(maxX - current, minX + current)] = val + 1;
                //             }
                //             else
                //             {
                //                 map[(maxX - current, minX + current)] = 1;
                //             }
                //             
                //             current++;
                //         }
                //
                //
                //     }
                // }
                else if (line.IsSlash())
                {
                    (int X, int Y) bottomLeft;
                    (int X, int Y) topRight;
                    // find bottom left corner
                    if (line.X1 < line.X2)
                    {
                        bottomLeft = (line.X1, line.Y1);
                        topRight = (line.X2, line.Y2);
                    }
                    else
                    {
                        topRight= (line.X1, line.Y1);
                        bottomLeft = (line.X2, line.Y2);
                    }
                    
                    // going from bottomLeft to topRight we increment X and decrement Y
                    var current = 0;
                    while (bottomLeft.X + current <= topRight.X)
                    {
                        if (map.TryGetValue((bottomLeft.X + current, bottomLeft.Y - current), out int value))
                        {
                            map[(bottomLeft.X + current, bottomLeft.Y - current)] = value + 1;
                        }
                        else
                        {
                            map[(bottomLeft.X + current, bottomLeft.Y - current)] = 1;
                        }
                        current++;
                    }


                }
                else // diagonal backslash shape
                {
                    (int X, int Y) topLeft;
                    (int X, int Y) bottomRight;
                    // find top left corner
                    if (line.X1 < line.X2)
                    {
                        topLeft = (line.X1, line.Y1);
                        bottomRight = (line.X2, line.Y2);
                    }
                    else
                    {
                        bottomRight = (line.X1, line.Y1);
                        topLeft = (line.X2, line.Y2);
                    }
                    
                    // going from topLeft to bottomRight we increment X and increment Y
                    var current = 0;
                    while (topLeft.X + current <= bottomRight.X)
                    {
                        if (map.TryGetValue((topLeft.X + current, topLeft.Y + current), out int value))
                        {
                            map[(topLeft.X + current, topLeft.Y + current)] = value + 1;
                        }
                        else
                        {
                            map[(topLeft.X + current, topLeft.Y + current)] = 1;
                        }
                        current++;
                    }
                }
            }



            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (map.TryGetValue((j, i), out var res))
                        Console.Write($"{res} ");
                    else 
                        Console.Write(". ");
                }

                Console.WriteLine();
            }

            var total = 0;
            
            foreach (var kv in map)
            {
                if (kv.Value >= 2) total++;
            }

            Console.WriteLine(total);
        }


        public class Line
        {
            public int X1 { get; set; }
            public int Y1 { get; set; }
            public int X2 { get; set; }
            public int Y2 { get; set; }

            public static Line ToLine(string line)
            {
                var fromTo = line.Split(" -> ");
                var from = fromTo.First().Trim().Split(",");
                var to = fromTo.Last().Trim().Split(",");

                return new Line()
                {
                    X1 = int.Parse(from.First()),
                    Y1 = int.Parse(from.Last()),
                    X2 = int.Parse(to.First()),
                    Y2 = int.Parse(to.Last())
                };
            }

            public bool IsHorizontal() => Y1 == Y2;

            public bool IsVertical() => X1 == X2;

            public bool IsSlash() // "/" shape
            {
                return (X1 > X2 && Y1 < Y2) ||
                       (X1 < X2 && Y1 > Y2);
            }
        }

    }
}