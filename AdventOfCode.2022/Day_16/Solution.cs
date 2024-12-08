using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022.Day_16;

public class Solution
{
    private const int MaxLength = 30;

    public static void Run()
    {
        Dictionary<string, List<string>> neighbors = new();
        Dictionary<string, int> flowRates = new();
        File.ReadAllLines("input.txt").ToList().ForEach(l => Parse(l, neighbors, flowRates));

        // Approach1(neighbors, flowRates);

        var valvesWithPressure = flowRates
            .Where(kv => kv.Value > 0)
            .Select(kv => kv.Key)
            .ToList();

        var permutations = GetPermutations(valvesWithPressure);

        var start =  new List<string> { "SQ", "KI", "YB" };
        
        var max = int.MinValue;

        foreach (var permutation in permutations)
        {
            var root = "AA";
            var paths = new List<Path>();
            foreach (var target in permutation)
            {
                var path = BFS(root, target, neighbors);
                paths.Add(path);
                root = target;
            }

            var fullPath = paths.Aggregate(Path.Merge);
            
            // if (fullPath.ToString() != "AADDCCBBAAIIJJIIAADDEEFFGGHHGGFFEEDDCC") continue;

            var round = 30;
            var pathScore = 0;


            var targetIdx = 0;
            var nodes = fullPath.GetNodes();

            foreach (var node in nodes)
            {
                if (round <= 0) break; 
                
                if (node == permutation[targetIdx])
                {
                    var flowRate = flowRates[node];
                    round--; // we lose one minute to unlock the valve
                    pathScore += round * flowRate;
                    targetIdx++;
                }

                round--; // we lose one minute to go to the next node dd bb jj hh ee cc
            }
            
            // for (var i = 0; i < nodes.Count && round > 0; i++)
            // {
            //     if (currentNode == permutation[targetIdx])
            //     {
            //         var flowRate = flowRates[currentNode];
            //         round--; // we lose one minute to unlock the valve
            //         pathScore += round * flowRate;
            //         targetIdx++;
            //     }
            //
            //     currentNode++;
            //     round--; // we lose one minute to go to the next node dd bb jj hh ee cc
            // }

            if (pathScore > max)
                max = pathScore;
        }

        Console.WriteLine(max);
    }




    public static List<List<string>> GetPermutations(List<string> toPermutate)
    {
        if (toPermutate.Count == 1)
            return new List<List<string>> { toPermutate };

        var res = toPermutate.SelectMany(s =>
        {
            var otherPermutations = GetPermutations(toPermutate.Except(new[] { s }).ToList());
            otherPermutations.ForEach(p =>p.Add(s));
            return otherPermutations;
        }).ToList();
        return res;
    }

    public static void Approach1(Dictionary<string, List<string>> neighbors, Dictionary<string, int> flowRates)
    {
         var edges = neighbors["AA"]
            .Select(n => new Edge("AA", n))
            .Select(e => new Path(new List<Edge> { e }));
        
        var pathsToVisit = new Stack<Path>(edges);
        var pathsToSave = new List<Path>();
        while (pathsToVisit.Any())
        {
            var path = pathsToVisit.Pop();
            var current = path.Edges.Last();
            var toVisit = neighbors[current.To];
            if (path.Length == MaxLength)
            {
                pathsToSave.Add(path);
                continue;
            }

            var anyMovesAvailable = false;
            foreach (var n in toVisit)
            {
                var edge = new Edge(current.To, n);
                if (!path.Edges.Contains(edge))
                {
                    anyMovesAvailable = true;
                    pathsToVisit.Push(path.DuplicateWith(edge));
                }
            }
            
            if (!anyMovesAvailable)
                pathsToSave.Add(path);
        }
        
        var max = int.MinValue;
        foreach (var path in pathsToSave)
        {
            var first = path.Edges[0].To == "DD";
            var second = path.Edges[1].To == "CC";
            var third = path.Edges[2].To == "BB";
            var fourth = path.Edges[3].To == "AA";
            var fifth = path.Edges[4].To == "II";
            
            if (!(first && second && third && fourth && fifth && path.Length == 18))
                continue;

            var round = 30;
            var pathScore = 0;
            for (var i = 0; i < path.Edges.Count && round > 0; i++)
            {
                var edge = path.Edges[i];
                var flowRate = flowRates[edge.From];
                if (flowRate > 0)
                {
                    round--; // we lose one minute to unlock the valve
                    pathScore += round * flowRate;
                }

                round--; // we lose one minute to go to the next node
            }

            if (pathScore > max)
                max = pathScore;
        }

        Console.WriteLine(max);
    }

    public struct Path
    {
        public Path(List<Edge> edges)
        {
            Edges = edges;
        }

        public List<string> GetNodes()
        {
            var nodes = Edges.Select(e => e.From).ToList();
            nodes.Add(Edges.Last().To);
            return nodes;
        }

        public List<Edge> Edges { get;  }
        public int Length => Edges.Count;

        public static Path Merge(Path left, Path right)
        {
            if (left.Edges.Last().To != right.Edges.First().From)
                throw new Exception();

            var lEdges = left.Edges.Select(e => new Edge(e.From, e.To)).ToList();
            var rEdges = right.Edges.Select(e => new Edge(e.From, e.To));
            lEdges.AddRange(rEdges);

            return new Path(lEdges);
        }
        
        
        public Path DuplicateWith(Edge newEdge)
        {
            var edges = Edges
                .Select(edge => new Edge(edge.From, edge.To))
                .ToList();
            
            edges.Add(newEdge);
            return new Path(edges);
        }

        public override string ToString()
        {
            if (!Edges.Any()) return "<empty>";
            return Edges.First().From + string.Join("", Edges.Select(e => e.To));
        }
    }

    public struct Edge
    {
        public Edge(string from, string to)
        {
            From = from;
            To = to;
        }
        
        public string From { get; }
        public string To { get; }


        public override string ToString()
        {
            return $"{From}->{To}";

        }  


        private sealed class FromToEqualityComparer : IEqualityComparer<Edge>
        {
            public bool Equals(Edge x, Edge y)
            {
                return x.From == y.From && x.To == y.To;
            }

            public int GetHashCode(Edge obj)
            {
                return HashCode.Combine(obj.From, obj.To);
            }
        }

        public static IEqualityComparer<Edge> FromToComparer { get; } = new FromToEqualityComparer();
    }

    static Path BFS(string root, string goal, Dictionary<string, List<string>> neighbors)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        var parent = new Dictionary<string, string>();

        var pathBack = new Stack<string>();
        
        parent.Add(root, null);
        visited.Add(root);
        queue.Enqueue(root);
        while (queue.Any())
        {
            var v = queue.Dequeue();
            if (v == goal)
            {
                while (v is not null)
                {
                    pathBack.Push(v);
                    v = parent[v];
                }

                var list = new List<Edge>();
                var from = pathBack.Pop();
                while (pathBack.Any())
                {
                    var to = pathBack.Pop();
                    list.Add(new Edge(from, to));
                    from = to;
                }

                return new Path(list);
            }

            foreach (var neighbor in neighbors[v])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent.Add(neighbor, v);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new Path();
    }
    
    

    static void Parse(string line, Dictionary<string, List<string>> neighborsDict, Dictionary<string, int> flows)
    {
        var ab = line.Split("; ");
        var valveRate = ab.First().Replace("Valve ", string.Empty).Split(" has flow rate=").ToList();
        var valve = valveRate.First();
        var rate = int.Parse(valveRate.Last());

        var neighbors = ab.Last().Replace(ab.Last().Contains("valves") ? "tunnels lead to valves " : "tunnel leads to valve ", string.Empty);
        var neighborsList = neighbors.Split(", ").ToList();
        
        neighborsDict.Add(valve, neighborsList);
        flows.Add(valve, rate);
    }
}

/*
Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II
 */

