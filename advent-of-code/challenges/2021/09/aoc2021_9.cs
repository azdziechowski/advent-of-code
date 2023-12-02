using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kattis
{
    public class aoc2021_9
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt")
                .Select(l => l.Trim())
                .Select(l => "9" + l + "9")
                .ToList();
            
            var linesBuffered = new List<string> { new string('9', lines.First().Length) };
            linesBuffered.AddRange(lines);
            linesBuffered.Add(new string('9', lines.First().Length));
            
            var points = new Dictionary<(int, int), Point>();
            
            for (var i = 1; i < linesBuffered.Count-1; i++)
            {
                var line = linesBuffered[i];
                var previousLine = linesBuffered[i - 1];
                var nextLine = linesBuffered[i + 1];
                for (var innerIndex = 1; innerIndex < line.Length - 1; innerIndex++)
                {
                    var point = points.TryGetValue((i, innerIndex), out var existing)
                        ? existing
                        : new Point() { Value = line[innerIndex], Visited = false };

                    var right = points.TryGetValue((i, innerIndex + 1), out var existingRight)
                        ? existingRight
                        : new Point() { Value = line[innerIndex + 1], Visited = false };

                    points[(i, innerIndex + 1)] = right; 
                    
                    var left = points.TryGetValue((i, innerIndex - 1), out var existingLeft)
                        ? existingLeft
                        : new Point() { Value = line[innerIndex - 1], Visited = false };

                    points[(i, innerIndex - 1)] = left;

                    var top = points.TryGetValue((i - 1, innerIndex), out var existingTop)
                        ? existingTop
                        : new Point() { Value = previousLine[innerIndex], Visited = false };

                    points[(i - 1, innerIndex)] = top;
                    
                    var bottom = points.TryGetValue((i + 1, innerIndex), out var existingBottom)
                        ? existingBottom
                        : new Point() { Value = nextLine[innerIndex], Visited = false };

                    points[(i + 1, innerIndex)] = bottom;
                    
                    point.Neighbors.AddRange(new []{left, right, top, bottom});
                    points[(i, innerIndex)] = point;
                }
            }

            var counter = 0;

            var pointsList = points.Values.ToList();
            
            void Visit(Point point, int cnt)
            {
                if (point.Visited)
                    return;

                point.Visited = true;

                if (point.Value == '9')
                    return;
                
                point.K = cnt;
                
                foreach (var neighbor in point.Neighbors.Where(p => p.Value != '9' && !p.Visited))
                {
                    Visit(neighbor, cnt);
                }
            }
            
            foreach (var p in pointsList)
            {
                Visit(p, counter++);
            }
            
            var biggestGroups = pointsList
                .GroupBy(p => p.K)
                .Where(g => g.Key != -1)
                .Select(g => g.ToList().Count)
                .OrderByDescending(c => c)
                .Take(3)
                .ToList();
            
            Console.WriteLine(biggestGroups[0] * biggestGroups[1] * biggestGroups[2]);
        }

        public class Point
        {
            public char Value { get; set; }
            public bool Visited { get; set; }

            public int K { get; set; } = -1;

            public List<Point> Neighbors { get; set; } = new List<Point>();
        }
        
    }
}