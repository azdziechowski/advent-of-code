using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022.Day_14;

public class Solution
{
    public static void Run()
    {
        var lines = File.ReadAllLines("input.txt");
        var grid = new Tile[1000, 1000];
        foreach (var line in lines)
        {
            var coords = line
                .Split(" -> ")
                .Select(c => c.Split(",")
                    .Select(int.Parse)
                    .ToList())
                .ToList();
            
            var xCoord = coords[0][0];
            var yCoord = coords[0][1];
            grid[xCoord, yCoord] = Tile.Rock;
            
            var idx = 1;
            while (coords.Count > idx)
            {
                var newXCoord = coords[idx][0];
                var newYCoord = coords[idx][1];

                int xTranslate = 0, yTranslate = 0;
                if (xCoord > newXCoord)
                    xTranslate = -1;
                if (xCoord < newXCoord)
                    xTranslate = 1;
                if (yCoord > newYCoord)
                    yTranslate = -1;
                if (yCoord < newYCoord)
                    yTranslate = 1;

                while (true)
                {
                    xCoord += xTranslate;
                    yCoord += yTranslate;
                    grid[xCoord, yCoord] = Tile.Rock;
                    if (xCoord == newXCoord && yCoord == newYCoord)
                        break;
                }
                
                idx++;
            }
        }

        var maxDepth = -1;
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == Tile.Rock && j > maxDepth)
                    maxDepth = j;
            }
        }

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            grid[i, maxDepth + 2] = Tile.Rock;
        }
        
        var hitTop = false;
        var grainCounter = 0;
        while (true)
        {
            var sandX = 500;
            var sandY = -1;

            if (grid[500, 0] == Tile.Sand)
            {
                break;
            }

            var canMove = true;
            while (canMove)
            {
                if (grid[sandX, sandY + 1] == Tile.Air)
                {
                    if (sandY >= 0) // initial case
                        grid[sandX, sandY] = Tile.Air;

                    sandY += 1;
                    
                    grid[sandX, sandY] = Tile.Sand;
                }
                else if (sandX - 1 >= 0 && grid[sandX - 1, sandY + 1] == Tile.Air)
                {
                    if (sandY >= 0) // initial case
                        grid[sandX, sandY] = Tile.Air;

                    sandX -= 1;
                    sandY += 1;
                    grid[sandX, sandY] = Tile.Sand;
                }
                else if (sandX + 1 < grid.GetLength(0) && grid[sandX + 1, sandY + 1] == Tile.Air)
                {
                    if (sandY >= 0) // initial case
                        grid[sandX, sandY] = Tile.Air;

                    sandX += 1;
                    sandY += 1;
                    grid[sandX, sandY] = Tile.Sand;
                }
                else
                {
                    canMove = false;
                }
            }
            
            grainCounter++;
        }

        Console.WriteLine("grains of sand: {0}", grainCounter);
        
        // for (int i = 480; i < 520; i++)
        // {
        //     for (int j = 0; j < 20; j++)
        //     {
        //         Console.Write(GetSymbol(grid[i, j]));
        //     }
        //
        //     Console.WriteLine();
        // }

        // for (int j = 0; j < grid.GetLength(1); j++)
        // {
        //     for (int i = 480; i < grid.GetLength(0) - 50; i++)
        //     {
        //         // if (grid[i, j] == Tile.Rock)
        //         Console.Write(GetSymbol(grid[i, j]));
        //         // Console.WriteLine($"{i}:{j}");
        //     }
        //     Console.WriteLine();
        // }
    }
    
    public static char GetSymbol(Tile tile)
    {
        return tile switch
        {
            Tile.Air => '.',
            Tile.Rock => '#',
            Tile.Sand => 'o',
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}



public enum Tile
{
    Air, Sand, Rock
    
    
}
