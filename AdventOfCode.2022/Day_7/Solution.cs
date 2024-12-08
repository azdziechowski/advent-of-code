using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022.Day_7;

public class Solution
{
    private static readonly Node RootNode = new Node("/", null);
    
    public static void Run()
    {
        var lines = System.IO.File.ReadAllLines("input.txt");
        
        CreateDirectoryTree(lines);
        var dict = new Dictionary<string, long>();
        CollectSizes(RootNode, dict);

        // part1
        var result = dict
            .Where(kv => kv.Value <= 100_000)
            .Sum(kv => kv.Value);
        
        // part2
        const int totalSize = 70_000_000;
        const int needed = 30_000_000;
        var used = RootNode.Size;
        var free = totalSize - used;
        var toDelete = needed - free;

        var result2 = dict.OrderBy(kv => kv.Value).First(kv => kv.Value >= toDelete).Value;

        Console.WriteLine($"Part2: {result2}");
    }
    

    private static void CollectSizes(Node parent, Dictionary<string,long> dict)
    {
        try
        {
            dict.Add(parent.FullName, parent.CalculateSize());
        }
        catch (Exception e)
        {
        }
        
        foreach (var child in parent.Children)
        {
            CollectSizes(child, dict);
        }
    }

    private static void CreateDirectoryTree(string[] lines)
    {
        var currentDir = RootNode;
        for (var index = 0; index < lines.Length; index++)
        {
            var line = lines[index];
            var op = Operation.Parse(line);
            if (op.Type is Operation.OperationType.cd)
            {
                currentDir = currentDir.Cd(op.Arg!);
            }
            else if (op.Type is Operation.OperationType.ls)
            {
                if (currentDir.Children.Any() || currentDir.Files.Any())
                {
                    // we have already been in this node, can't add the children/files again
                    // should have made it a dict instead
                    break;
                }

                while (true)
                {
                    index++;

                    if (index >= lines.Length)
                        break;

                    line = lines[index];
                    if (Operation.IsOperation(line))
                    {
                        // we read too much
                        index--;
                        break;
                    }

                    var lsResult = LsResult.Parse(line);
                    switch (lsResult.Type)
                    {
                        case FileType.dir:
                            currentDir.Children.Add(new Node(lsResult.Name, currentDir));
                            break;
                        case FileType.leaf:
                            currentDir.Files.Add(new File(lsResult.Name, lsResult.Size!.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum FileType
    {
        dir, leaf
    }

    public class LsResult
    {
        public LsResult(FileType type, string name, long? size = null)
        {
            Type = type;
            Name = name;
            Size = size;
        }

        public FileType Type { get; set; }
        public long? Size { get; set; }
        public string Name { get; set; }

        public static LsResult Parse(string line)
        {
            var split = line.Split(" ").ToArray();
            if (split.First() == "dir")
            {
                return new LsResult(FileType.dir, split[1]);
            }
            if (long.TryParse(split.First(), out var size))
            {
                return new LsResult(FileType.leaf, split[1], size);
            }
            
            throw new ArgumentOutOfRangeException();
        }
    }

    public class Operation
    {
        public Operation(OperationType type, string? arg = null)
        {
            Type = type;
            Arg = arg;
        }
        
        public OperationType Type { get; set; }
        public string? Arg { get; set; }

        public enum OperationType
        {
            cd, ls
        }

        public static bool IsOperation(string line)
        {
            return line.StartsWith("$");
        }

        public static Operation Parse(string line)
        {
            if (!IsOperation(line))
                throw new ArgumentException($"Cannot be converted to an op {line}");

            var split = line.Split(" ").ToArray();

            return split[1] switch
            {
                "cd" => new Operation(OperationType.cd, split[2]),
                "ls" => new Operation(OperationType.ls),
                _ => throw new ArgumentOutOfRangeException($"{split[1]} cannot be parsed")
            };
        }
    }

    public class Node
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public Node? Parent { get; set; }
        public List<Node> Children { get; set; } = new();
        public List<File> Files { get; set; } = new();
        
        public long? Size { get; set; }

        public override string ToString()
        {
            return Name + $" ({(Size is null ? "?" : Size)})";
        }

        public Node(string name, Node? parent)
        {
            Name = name;
            Parent = parent;

            if (parent is null)
            {
                FullName = name;
            }
            else
            {
                FullName = parent.FullName + name + "/";    
            }
        }

        public Node Cd(string arg)
        {
            return arg switch
            {
                ".." when Parent is not null => Parent,
                ".." when Parent is null => this,
                "/" => RootNode,
                { } s => Children.Single(c => c.Name == s),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public long CalculateSize()
        {
            Size = Files.Sum(f => f.Size) + Children.Select(c => c.CalculateSize()).Sum();
            return Size.Value;
        }
    }

    public class File
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public File(string name, long size)
        {
            Name = name;
            Size = size;
        }
    }
}