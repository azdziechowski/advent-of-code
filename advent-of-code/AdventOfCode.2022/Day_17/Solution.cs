using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day_17;

public class Solution
{
    public static void Run()
    {
        var pattern = File.ReadAllLines("test.txt").Single();


        var board = new bool[5000, 7];
        var shape = new Shape(ShapeType.Minus, 0);
        Console.WriteLine(shape);

        // for (int i = 0; i < board.GetLength(0); i++)
        // {
        //     for (int j = 0; j < board.GetLength(1); j++)
        //     {
        //         board[i, j] = false;
        //     }
        // }



    }

    public class Shape
    {
        public ShapeType Type { get; set; }

        public List<(int, int)> ShapeBoard;
        
        
        public Shape(ShapeType type, int maxHeight)
        {
            Type = type;
            ShapeBoard = CreateShapeBoard(type).Select(t => (t.Item1 + maxHeight + 3, t.Item2)).ToList();
        }

        private List<(int, int)> CreateShapeBoard(ShapeType type)
        {
            return type switch
            {
                ShapeType.Minus => CreateMinus(),
                ShapeType.Plus => CreatePlus(),
                ShapeType.L => CreateL(),
                ShapeType.VertBar => CreateVertBar(),
                ShapeType.Square => CreateSquare(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private List<(int, int)> CreateL()
        {
            var list = new List<(int, int)>
            {
                (0, 2),
                (0, 3),
                (0, 4),
                (1, 4),
                (2, 4)
            };
            return list;
        }

        private List<(int, int)> CreateMinus()
        {
            var list = new List<(int, int)>
            {
                (0, 2), (0, 3), (0, 4), (0, 5)
            };
            return list;
        }
        
        private List<(int, int)> CreatePlus()
        {
            var list = new List<(int, int)>
            {
                (0, 3), (1, 2), (1, 3), (1, 4), (2, 3)
            };
            return list;
        }
        
        private List<(int, int)> CreateVertBar()
        {
            var list = new List<(int, int)>
            {
                (0, 2), (1, 2), (2, 2), (3, 2)
            };
            return list;
        }
        
        private List<(int, int)> CreateSquare()
        {
            var list = new List<(int, int)>
            {
                (0, 2), (0, 3), (1, 2), (1, 3)
            };
            return list;
        }
    }

    public enum ShapeType
    {
        Minus, Plus, L, VertBar, Square
    }
}

/*
####


...#.
..###
...#.

....#
....#
..###


..#
..#
..#
..#

..##
..##
*/