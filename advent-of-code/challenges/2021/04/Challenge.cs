using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code.challenges._2021._04
{
    public class Challenge : ChallengeBase
    {
        public static void Run()
        {
            var input = File.ReadAllLines("input.txt");

            var order = input.First().Split(",").Select(num => num.Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            var boardsInput = input.Skip(2).ToList();
            
            var boards = new List<Board>();

            var temp = new Board();
            
            foreach (var t in boardsInput)
            {
                if (string.IsNullOrWhiteSpace(t))
                {
                    boards.Add(temp);
                    temp = new Board();
                    continue;
                }
                
                var row = t.Split().Select(num => num.Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
                temp.AddRow(row);
            }

            boards.Add(temp);


            var results = new List<(int, int, int)>();
            
            
            // part1
            // foreach (var o in order)
            // {
            //     foreach (var board in boards)
            //     {
            //         if (board.Mark(o) && board.ThatsABingo())
            //         {
            //             var sum = board.GetUnmarkedSum();
            //             Console.WriteLine(sum * o);
            //             return;
            //         }
            //     }
            // }
            
            // part2
            for (var boardIndex = 0; boardIndex < boards.Count; boardIndex++)
            {
                var board = boards[boardIndex];
                for (var i = 0; i < order.Length; i++)
                {
                    if (board.Mark(order[i]) && board.ThatsABingo())
                    {
                        var unmarked = board.GetUnmarkedSum();
                        results.Add((boardIndex, i, unmarked * order[i]));
                        break;
                    }
                }
            }

            var result = results.OrderByDescending(tuple => tuple.Item2).First().Item3;
            Console.WriteLine(result);


        }


        private class Board
        {
            public List<List<(int, bool)>> XY { get; set; } = new List<List<(int, bool)>>();

            public void AddRow(List<int> row)
            {
                var toAdd = row.Select(n => (n, false)).ToList();
                XY.Add(toAdd);
            }

            public bool Mark(int n)
            {
                for (var index = 0; index < XY.Count; index++)
                {
                    var row = XY[index];
                    for (var j = 0; j < row.Count; j++)
                    {
                        if (row[j].Item1 == n)
                        {
                            row[j] = (n, true);
                            return true;
                        }
                    }
                }

                return false;
            }

            public bool ThatsABingo()
            {
                foreach (var row in XY)
                {
                    if (row.All(val => val.Item2))
                    {
                        return true;
                    }
                }

                var columnCount = XY.First().Count;
                var rowCount = XY.Count;

                for (int i = 0; i < columnCount; i++)
                {
                    var isBingo = true;
                    for (int j = 0; j < rowCount; j++)
                    {
                        if (XY[j][i].Item2 == false)
                        {
                            isBingo = false;
                            break;
                        }
                    }

                    if (isBingo) return true;
                }

                // var firstDiagonalIsBingo = true;
                // for (int i = 0; i < XY.Count; i++)
                // {
                //     if (XY[i][i].Item2 == false)
                //     {
                //         firstDiagonalIsBingo = false;
                //         break;
                //     }
                // }
                //
                // if (firstDiagonalIsBingo) return true;
                //
                // var secondDiagonalIsBingo = true;
                // for (int i = 0; i < XY.Count; i++)
                // {
                //     if (XY[XY.Count - i - 1][i].Item2 == false)
                //     {
                //         secondDiagonalIsBingo = false;
                //         break;
                //     }
                // }
                //
                // if (secondDiagonalIsBingo) return true;

                return false;
            }

            public int GetUnmarkedSum()
            {
                var sum = 0;
                foreach (var row in XY)
                {
                    foreach (var val in row)
                    {
                        if (val.Item2 == false) sum += val.Item1;
                    }
                }

                return sum;
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