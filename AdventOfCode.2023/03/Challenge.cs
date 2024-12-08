using System;
using System.Collections.Generic;

namespace advent_of_code._03;

public class Challenge : ChallengeBase
{
    public override void RunPart1()
    {
        var input = ReadTest();
        var numbers = new List<(int row, int from, int to)>();
        for (int i = 0; i < input.Length; i++)
        {
            int? currentFrom = null;
            
            for (int j = 0; j < input[i].Length; j++)
            {
                if ("0123456789".Contains(input[i][j]))
                {
                    if (currentFrom.HasValue) continue;
                    currentFrom = j;
                }
                else if (currentFrom.HasValue)
                {
                    numbers.Add((i, currentFrom.Value, j - 1));
                    currentFrom = null;
                }
            }
            
            var symbols = new List<(int row, int at)>();
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input[i].Length; y++)
                {
                    if (true)
                    {
                        
                    }
                }
            }
        }
    }

    public override void RunPart2()
    {
        throw new NotImplementedException();
    }
}