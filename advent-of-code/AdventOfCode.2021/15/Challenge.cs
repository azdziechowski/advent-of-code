using advent_of_code.challenges;

namespace AdventOfCode._2021._2021._15;

public class Challenge : ChallengeBase
{
    static Dictionary<(int, int), Node> nodes = new();
    private static Dictionary<Node, decimal> costs = new();

    public static void Run()
    {
        var lines = File.ReadAllLines("input.txt");

        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                var node = new Node(i, j, lines[i][j] - 48);
                nodes.Add((i, j), node);
            }
        }

        var maxX = lines.Length;
        var maxY = lines.First().Length;
        
        nodes[(0, 0)].IsStart = true;
        nodes[(maxX - 1, maxY - 1)].IsEnd = true;
        
        foreach (var (_, node) in nodes)
        {
            var coords = GetAdjCoords(node, maxX, maxY);
            foreach (var coord in coords)
            {
                var neighbour = nodes[(node.X + coord.Item1, node.Y + coord.Item2)];
                node.Adj.Add(neighbour);
            }
        }

        var set = Explore(nodes[(0, 0)], nodes[(maxX - 1, maxY - 1)], new HashSet<Node>() {});

        Console.WriteLine(set.Sum(n => n.Value));
    }

    private static HashSet<Node> Explore(Node start, Node end, HashSet<Node> hashSet)
    {
        var cost = hashSet.Any() ? hashSet.Sum(n => n.Value) : 0;
        if (costs.TryGetValue(start, out var val))
        {
            if (val > cost)
            {
                costs[start] = cost;
            }

            else
            {
                return new HashSet<Node>();
            }
        }
        else
        {
            costs[start] = cost;
        }


        var endNode = start.Adj.SingleOrDefault(n => n == end);
        if (endNode is not null)
        {
            var returnSet = new HashSet<Node>(hashSet) { endNode };
            return returnSet;
        }
        
        var visitedWithCurrent = new HashSet<Node>(hashSet) { start };

        var results = new List<HashSet<Node>>();

        foreach (var neighbour in start.Adj.Where(n => !hashSet.Contains(n) && !n.IsStart))
        {
            results.Add(Explore(neighbour, end, visitedWithCurrent));
        }

        var best = results.Where(s => s.Any()).OrderBy(set => set.Sum(n => n.Value)).FirstOrDefault();
        return best ?? new HashSet<Node>();
    }

    static List<(int, int)> GetAdjCoords(Node node, int maxX, int maxY)
    {
        var coords = new List<(int, int)>()
        {
            // (-1, -1),
            (-1, 0),
            // (-1, 1),
            (0, -1),
            (0, 1),
            // (1, -1),
            (1, 0),
            // (1, 1)
        };

        return coords.Where(coord => 
                coord.Item1 + node.X >= 0 && 
                coord.Item1 + node.X < maxX && 
                coord.Item2 + node.Y >= 0 && 
                coord.Item2 + node.Y < maxY)
            .ToList();
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public bool IsEnd { get; set; } = false;
        public bool IsStart { get; set; } = false;

        public List<Node> Adj { get; set; } = new List<Node>();

        public Node(int x, int y, int val)
        {
            X = x;
            Y = y;
            Value = val;
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