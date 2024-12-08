using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC.Day_5;

public class Solution
{
    public static void Run()
    {
        var lines = File.ReadAllLines("input.txt");

        var index = 0;
        while (!lines[index].StartsWith(" 1 "))
        {
            index++; 
        }

        var n = int.Parse(lines[index].Split().Last(s => !string.IsNullOrWhiteSpace(s)).Trim());
        var stacks = new Stack<char>[n];
        for (int i = 0; i < n; i++)
        {
            stacks[i] = new Stack<char>();
        }
        
        for (var i = index; i >= 0; i--)
        {
            var line = lines[i];
            var stackIndex = 0;
            for (var j = 0; j < line.Length; j+=4)
            {
                var substring = line.Substring(j, 3);
                if (substring.Contains('['))
                {
                    stacks[stackIndex].Push(substring[1]);
                }

                stackIndex++;
            }
        }

        index += 2; // Skip empty line

        var regex = new Regex("move (\\d*) from (\\d*) to (\\d*)");
        for (int i = index; i < lines.Length; i++)
        {
            var matches = regex.Match(lines[i]).Groups.Values.ToList();
            var howMany = int.Parse(matches[1].Value);
            var from = int.Parse(matches[2].Value) - 1; // 0-based
            var to = int.Parse(matches[3].Value) - 1; // 0-based
            var tempStack = new Stack<char>(howMany);
            while (howMany-- > 0)
            {
                var popped = stacks[from].Pop();
                tempStack.Push(popped);
            }

            while (tempStack.Any())
            {
                stacks[to].Push(tempStack.Pop());
            }
        }

        var sb = new StringBuilder();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Pop());
        }

        Console.WriteLine(sb.ToString());
    }
}