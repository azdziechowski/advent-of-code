using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021._12
{
    public class Challenge : ChallengeBase
    {
        private static Dictionary<string, Node> nodes = new();

        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt").Select(l => l.Trim()).ToList();
            foreach (var line in lines)
            {
                var leftRight = line.Split("-");
                var left = leftRight.First();
                var right = leftRight.Last();

                if (!nodes.ContainsKey(left))
                    nodes.Add(left, new Node(left));
                
                if (!nodes.ContainsKey(right))
                    nodes.Add(right, new Node(right));
            }

            foreach (var line in lines)
            {
                var leftRight = line.Split("-");
                var left = nodes[leftRight.First()];
                var right = nodes[leftRight.Last()];
                
                left.Adj.Add(right);
                right.Adj.Add(left);
            }

            var start = nodes["start"];
            var visited = new List<Node>();

            var ways = Explore(start, visited);

            foreach (var way in ways)
            {
                var wayString = string.Join(",", way.Select(w => w.Name));
                Console.WriteLine(wayString);
            }
            
            Console.WriteLine(ways.Count);
        }

        private static List<List<Node>> Explore(Node start, List<Node> oldVisited)
        {
            var visited = new List<Node>(oldVisited) { start };

            // worked in part1
            // var visitedSmol = visited.Where(v => v.Type == Node.NodeType.Smol).ToHashSet();
            
            //part2
            
            var visitedSmol = visited
                .Where(v => v.Type == Node.NodeType.Smol)
                .GroupBy(v => v);
            var isThereSmallCaveAlreadyVisitedTwice = visitedSmol.Any(g => g.ToList().Count == 2);
            
            
            var bigAdj = start.Adj.Where(adj => adj.Type == Node.NodeType.Big).ToList();
            
            var smallAdj = start.Adj.Where(adj => adj.Type == Node.NodeType.Smol).ToList();

            var smallAdjToVisit = isThereSmallCaveAlreadyVisitedTwice
                ? smallAdj.Except(visited.Where(v => v.Type == Node.NodeType.Smol))
                    .ToList() // we already visited some small cave twice, so we cannot go back to any of the small caves we visited
                : smallAdj;


            var adjToVisit = new List<Node>(bigAdj);
            adjToVisit.AddRange(smallAdjToVisit);

            // var adjToVisit = start.Adj
            //     .Where(adj => !visitedSmol.Contains(adj))
            //     .Where(adj => adj.Type != Node.NodeType.Start)
            //     .ToList();

            var result = new List<List<Node>>();

            var end = start.Adj.SingleOrDefault(adj => adj == nodes["end"]);
            if (end is not null)
            {
                var path = new List<Node>();
                path.AddRange(visited);
                path.Add(end);
                result.Add(path);
            }

            foreach (var node in adjToVisit)
            {
                var temp = Explore(node, visited);
                result.AddRange(temp);
            }
            
            return result; 
        }

        public class Node
        {
            public string Name { get; }
            public NodeType Type { get; }

            public enum NodeType
            {
                Big, Smol, Start, End
            }

            public List<Node> Adj { get; } = new();

            public Node(string name)
            {
                Name = name;
                Type = GetType(name);
            }

            private NodeType GetType(string name)
            {
                return name switch {
                    "start" => NodeType.Start,
                    "end" => NodeType.End,
                    { } other when other.ToLower() == other => NodeType.Smol,
                    { } other when other.ToUpper() == other => NodeType.Big,
                    _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
                };
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