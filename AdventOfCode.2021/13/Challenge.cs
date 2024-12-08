using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021._13
{
    public class Challenge : ChallengeBase
    {
        private static List<int> countAtRow = new List<int>();

        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt");
            var index = 0;

            var points = new HashSet<(int, int)>();
            while (!string.IsNullOrEmpty(lines[index]))
            {
                var line = lines[index];
                var xy = line.Split(",").Select(x => x.Trim()).Select(int.Parse).ToList();
                points.Add((xy.First(), xy.Last()));
                index++;
            }

            index++;
            var folds = new List<(bool, int)>();
            for (var i = index; i < lines.Length; i++)
            {
                var line = lines[i].Substring("fold along ".Length);
                var axisAt = line.Split("=").Select(x => x.Trim()).ToList();
                var axis = axisAt.First();
                var at = axisAt.Last();

                var horizontal = axis == "y";
                folds.Add((horizontal, int.Parse(at)));
            }

            var maxX = points.Max(p => p.Item1);
            var maxY = points.Max(p => p.Item2);

            var grid = new List<List<bool>>();
            for (int rowPtr = 0; rowPtr <= maxY; rowPtr++)
            {
                var row = new List<bool>();
                for (int colPtr = 0; colPtr <= maxX; colPtr++)
                {
                    row.Add(points.Contains((colPtr, rowPtr)));
                }
                
                grid.Add(row);
            }

            // grid = grid.Take(1).ToList();


            var tempAt = 655;
            var totalCount = 0;
            
            foreach (var row in grid)
            {
                var left = row.Take(tempAt).ToList();
                var right = row.Skip(tempAt + 1).Reverse().ToList();
                var test = left.Zip(right).ToList();
                var count = left.Skip(1).Zip(right).Count(z => z.First || z.Second);
                if (left.First()) 
                    count += 1;
                
                countAtRow.Add(count);
                
                totalCount += count;
            }

            // Console.WriteLine("hack count: " + totalCount);
            
            foreach (var fold in folds)
            {
                grid = Fold(fold, grid);
            }


            var total = 0;
            foreach (var row in grid)
            {
                foreach (var b in row)
                {
                    if (b)
                        total++;
                }
            }

            Print(grid);
            
            Console.WriteLine(total);
        }

        private static void Print(List<List<bool>> grid)
        {
            foreach (var row in grid)
            {
                foreach (var b in row)
                {
                    Console.Write($"{(b ? "#" : ".")}");
                }

                Console.WriteLine();
            }
        }

        private static List<List<bool>> Fold((bool, int) fold, List<List<bool>> grid)
        {
            var horizontal = fold.Item1;
            var at = fold.Item2;

            return horizontal 
                ? FoldHorizontal(grid, at) 
                : FoldVertical(grid, at);
        }

        private static List<List<bool>> FoldHorizontal(List<List<bool>> grid, int at)
        {
            var top = grid.Take(at + 1).SkipLast(1).ToList();
            var bottom = grid.Skip(at).Reverse().SkipLast(1).ToList();

            var result = top.Count > bottom.Count
                ? top
                : bottom;
            
            var index = 0;
            while (top.Count - 1 - index >= 0 && bottom.Count - 1 - index >= 0)
            {
                var topIndex = top.Count - 1 - index;
                var bottomIndex = bottom.Count - 1 - index;

                var row = top[topIndex].Zip(bottom[bottomIndex]).ToList();

                result[result.Count - 1 - index] = row.Select(z => z.First || z.Second).ToList();
                index++;
            }

            return result;
        }

        private static List<List<bool>> FoldVertical(List<List<bool>> grid, int at)
        {
            var left = grid.Select(row => row.Take(at)).ToList();
            var right = grid.Select(row => row.Skip(at + 1)).Select(row => row.Reverse()).ToList();

            var result = left.First().Count() > right.First().Count()
                ? left
                : right;

            for (int rowIndex = 0; rowIndex < result.Count; rowIndex++)
            {
                var leftRev = left[rowIndex].Reverse();
                var rightRev = right[rowIndex].Reverse();
                var merged = leftRev.Zip(rightRev).Select(z => z.First || z.Second).ToList();

                var resRev = result[rowIndex].Reverse().ToList();
                
                for (var i = 0; i < merged.Count; i++)
                {
                    resRev[i] = merged[i];
                }

                resRev.Reverse();
                result[rowIndex] = resRev;

                // result[rowIndex] = resRev.Zip(merged).Select(m => m.First || m.Second).Reverse();
                var count = result[rowIndex].Count(r => r);
                if (count != countAtRow[rowIndex])
                {
                    Console.WriteLine($"count: {count} countatrow: {countAtRow[rowIndex]}, index: {rowIndex}");
                }
            }

            return result.Select(r => r.ToList()).ToList();
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