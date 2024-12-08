using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day_10;

public class Solution
{
    public static void Run()
    {
        var ops = File
            .ReadAllLines("input.txt")
            .Select(Op.Parse)
            .ToArray();

        var cpu = new Cpu();
        foreach (var op in ops)
        {
            cpu.Execute(op);
        }

        // part1
        // var sum = 0L;
        // for (int i = 0; i < cpu.Values.Count; i++)
        // {
        //     if ((i + 1 + 20) % 40 == 0)
        //     {
        //         sum += (i+1) * cpu.Values[i];
        //     }    
        // }
        // Console.WriteLine(sum);
        
        foreach (var row in cpu.Crt.Pixels)
        {
            Console.WriteLine(new string(row));
        }
    }
}

public enum OpType
{
    noop,
    addx
}

public struct Op
{
    public static Op Parse(string line)
    {
        var split = line.Split(" ");
        return split.Length == 1 
            ? new Op() { Type = OpType.noop } 
            : new Op() { Type = OpType.addx, Value = int.Parse(split[1]) };
    }

    public OpType Type { get; set; }
    public int? Value { get; set; }
}

public class Cpu
{
    public int X { get; set; } = 1;
    public long Clock { get; set; } = 1;

    public Crt Crt { get; set; } = new Crt();

    public List<int> Values = new();

    public void Execute(Op op)
    {
        switch (op.Type)
        {
            case OpType.noop:
                ExecuteNoOp();
                break;
            case OpType.addx:
                ExecuteAddx(op.Value!.Value);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void IncrementClock()
    {
        Clock++;
        Crt.Draw(X);
        Values.Add(X);
    }

    public void ExecuteNoOp()
    {
        IncrementClock();
    }

    public void ExecuteAddx(int val)
    {
        IncrementClock();
        IncrementClock();
        X += val;
    }
}

public class Crt
{
    public char[][] Pixels { get; set; } = new char[Height][];

    private const int Width = 40;
    private const int Height = 6;
    
    public int I { get; set; } = 0;
    public int J { get; set; } = 0;

    public void Draw(int x)
    {
        if (J == x || J - 1 == x || J + 1 == x)
        {
            Pixels[I][J] = '#';
        }
        else
        {
            Pixels[I][J] = '.';
        }

        J = (J + 1) % Width;
        if (J == 0) I++;
    }

    public Crt()
    {
        for (var index = 0; index < Pixels.Length; index++)
        {
            Pixels[index] = new char[Width];
        }
    }
}