using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day_13;

public class Solutio
{
    public static void Run()
    {
        var lines = File.ReadAllLines("input.txt");
        Element element;
        var index = 0;
        var packetIndex = 1;
        var results = new List<int>();
        var elements = new List<Element>();
        while (index < lines.Length)
        {
            var left = lines[index++];
            var right = lines[index++];
            index++;

            var (lElem, _) = Parse(left, 0);
            var (rElem, _) = Parse(right, 0);

            Console.WriteLine($"Packet Index: {packetIndex}");
            var res = lElem.CompareWithRight(rElem);
            if (res == 1)
            {
                results.Add(packetIndex);
            }
            
            elements.Add(lElem);
            elements.Add(rElem);

            Console.WriteLine();
            Console.WriteLine();
            
            packetIndex++;
        }

        var (elem2, _) = Parse("[[2]]", 0);
        elem2.IsDivider = true;
        var (elem6, _) = Parse("[[6]]", 0);
        elem6.IsDivider = true;
        elements.Add(elem2);
        elements.Add(elem6);
        
        elements.Sort(new MyComparer());
        var prod = 1;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].IsDivider)
                prod *= (i + 1);
        }
        
        
        
        Console.WriteLine(string.Join(",", results));
        Console.WriteLine(results.Sum());
        
        Console.WriteLine($"part2: {prod}");
    }
    
    private class MyComparer: IComparer<Element>
    {

        public int Compare(Element? x, Element? y)
        {
            return y.CompareWithRight(x);
        }
    }

    
    static (Element element, int index) Parse(string line, int from)
    {
        var element = new Element() { Type = ElementType.List };
        for (int i = from; i < line.Length; )
        {
            if (line[i] == '[')
            {
                var (list, index) = Parse(line, i+1);
                element.Elements.Add(list);
                i = index;
            }
            else if (line[i] == ']')
            {
                return (element, i+1);
            }
            else if (line[i] == ',')
            {
                i++;
            }
            else
            {
                int value = line[i] - '0';
                // quick hack to allow for '10' 
                if (line[i] == '1' && i + 1 < line.Length && line[i + 1] == '0')
                {
                    i++;
                    value = 10;
                }

                element.Elements.Add(new Element() { Type = ElementType.Int, Value = value});
                i++;
            }
        }

        return (element, line.Length + 1);
    }
}

public class Element
{
    public ElementType Type { get; set; }
    public int? Value { get; set; }
    public List<Element> Elements { get; set; } = new();

    public bool IsDivider { get; set; }

    public int CompareWithRight(Element right)
    {
        if (this.Type == ElementType.Int && right.Type == ElementType.Int)
        {
            if (this.Value.Value < right.Value.Value)
            {
                Console.WriteLine($"{this.Value.Value} < {right.Value.Value}");
                Console.WriteLine("ordered");

                return 1;
            }

            if (this.Value.Value == right.Value.Value)
            {
                return 0;
            }

            Console.WriteLine($"{this.Value.Value} > {right.Value.Value}");
            Console.WriteLine("unordered");

            return -1;
        }

        if (this.Type == ElementType.Int)
        {
            var newElem = new Element() { Type = ElementType.List };
            newElem.Elements.Add(new Element() { Type = ElementType.Int, Value = this.Value});
            return newElem.CompareWithRight(right);
        }

        if (right.Type == ElementType.Int)
        {
            var newElem = new Element() { Type = ElementType.List };
            newElem.Elements.Add(new Element() { Type = ElementType.Int, Value = right.Value});
            return CompareWithRight(newElem);
            // right.Type = ElementType.List;
            // right.Elements.Add(new Element() { Type = ElementType.Int, Value = right.Value});
            // right.Value = null;
            // return CompareWithRight(right);
        }

        // both are lists
        // If both values are lists, compare the first value of each list, then the second value, and so on.
        // If the left list runs out of items first, the inputs are in the right order.
        // If the right list runs out of items first, the inputs are not in the right order.
        // If the lists are the same length and no comparison makes a decision about the order,
        // continue checking the next part of the input.
        
        // unsure about this one

        for (int i = 0; i < Elements.Count && i < right.Elements.Count; i++)
        {
            var comparison = Elements[i].CompareWithRight(right.Elements[i]);
            if (comparison != 0)
            {
                return comparison;
            }
        }

        if (Elements.Count < right.Elements.Count)
        {
            Console.WriteLine($"{string.Join(",", Elements)} count ({Elements.Count}) < {string.Join(",", right.Elements)} count ({right.Elements.Count})");
            Console.WriteLine("ordered");
            return 1;
        }
        if (Elements.Count > right.Elements.Count)
        {
            Console.WriteLine($"{string.Join(",", Elements)} count ({Elements.Count}) > {string.Join(",", right.Elements)} count ({right.Elements.Count})");
            Console.WriteLine("unordered");
            return -1;
        }
        return 0;

    }
}

public enum ElementType
{
    Int, List
}