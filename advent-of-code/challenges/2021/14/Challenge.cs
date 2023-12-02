using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace advent_of_code.challenges._2021._14
{
    public class Challenge : ChallengeBase
    {
        static Dictionary<(char, char, int), Dictionary<char, long>> lookup = new();

        private static ImmutableDictionary<(char, char), char> insertions;
        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt");
            var template = lines.First();
            insertions = lines.Skip(2)
                .Select(l => l.Split(" -> "))
                .Select(arr => (arr.First(), arr.Last()))
                .ToImmutableDictionary(tpl => (tpl.Item1.First(), tpl.Item1.Last()), tpl => tpl.Item2.Single());

            
            var pairs = new List<(char, char)>();
            for (int i = 0; i < template.Length - 1; i++)
            {
                pairs.Add((template[i], template[i + 1]));
            }

            var totalResult = new Dictionary<char, long>();
            for (int i = 0; i < pairs.Count; i++)
            {
                Dictionary<char, long> result = Transform(pairs[i].Item1, pairs[i].Item2, 40);
                totalResult = MergeDictionaries(totalResult, result);
            }
            
            for (var i = 1; i < pairs.Count; i++)
            {
                totalResult[pairs[i].Item1]--;
            }

            var resultsOrdered = totalResult.OrderBy(kv => kv.Value).ToList();

            Console.WriteLine(resultsOrdered.Last().Value - resultsOrdered.First().Value);




            // var pairs = new List<(char, char)>();
            // for (int i = 0; i < template.Length - 1; i++)
            // {
            //     pairs.Add((template[i], template[i + 1]));
            // }
            //
            // var lists = new List<List<char>>();
            // for (int i = 0; i < pairs.Count; i++)
            // {
            //     var result = Transform(pairs[i].Item1, pairs[i].Item2, 40);
            //     lists.Add(result);
            // }
            //
            // // var lists = pairs.Select(pair => Transform(pair.Item1, pair.Item2, 10)).ToList();
            // var firstList = lists.First();
            // for (var i = 1; i < lists.Count; i++)
            // {
            //     lists[i] = lists[i].Skip(1).ToList();
            //     firstList = firstList.Concat(lists[i]).ToList();
            // }
            // //
            // // var res = new string(firstList.ToArray());
            // // Console.WriteLine(res);
            //
            // var grouping = firstList.GroupBy(l => l).OrderBy(g => g.ToList().Count).ToList();
            // var smallest = grouping.First(); 
            // var biggest = grouping.Last();
            //
            // Console.WriteLine(biggest.ToList().Count - smallest.ToList().Count);


            // var list = new LinkedList<char>(template.ToCharArray());
            //
            // var myNodes = list.Select(n => new Node<char> { Value = n }).ToList();
            //
            // for (int i = 0; i < myNodes.Count - 1; i++)
            // {
            //     myNodes[i].Next = myNodes[i + 1];
            // }
            //
            //
            //
            // var head = myNodes.First();
            //
            // var iterations = 40;





            //
            // while (iterations-- > 0)
            // {
            //     var node = myNodes.First();
            //     while (node.Next is not null)
            //     {
            //         var next = node.Next;
            //         var left = node.Value;
            //         var right = node.Next.Value;
            //
            //         var toInsert = insertions[(left, right)];
            //         var newNode = new Node<char> { Value = toInsert, Next = next };
            //
            //         node.Next = newNode;
            //         
            //         node = next;
            //     }
            // }

            // var str = new string(list.ToArray());
            //
            // Console.WriteLine(str);
            //
            // var current = myNodes.First();
            // var ll = new LinkedList<char>();
            // while (current is not null)
            // {
            //     ll.AddLast(current.Value);
            //     current = current.Next;
            // }
            //

            // var grouping = ll.GroupBy(l => l).OrderBy(g => g.ToList().Count).ToList();
            // var smallest = grouping.First();
            // var biggest = grouping.Last();
            //
            // Console.WriteLine(biggest.ToList().Count - smallest.ToList().Count);
        }

        private static Dictionary<char, long> Transform(char left, char right, int iterations)
        {
            if (lookup.TryGetValue((left, right, iterations), out var value))
                return value;
            
            if (iterations == 0)
            {
                var dict = new Dictionary<char, long>();
                if (left == right)
                {
                    dict[left] = 2;
                }
                else
                {
                    dict[left] = 1;
                    dict[right] = 1;
                }

                return dict;
            }

            var toInsert = insertions[(left, right)];

            var leftDict = Transform(left, toInsert, iterations - 1);
            var rightDict = Transform(toInsert, right, iterations - 1);

            var result = MergeDictionaries(leftDict, rightDict);
            
            result[toInsert]--; 
            
            lookup[(left, right, iterations)] = result;
            return result;
        }

        private static Dictionary<char, long> MergeDictionaries(Dictionary<char, long> leftDict, Dictionary<char, long> rightDict)
        {
            long Sum(List<KeyValuePair<char, long>> kv)
            {
                long res = 0;
                for (var i = 0; i < kv.Count; i++)
                {
                    res += kv[i].Value;
                }

                return res;
            }

            return leftDict.Concat(rightDict).GroupBy(kv => kv.Key)
                .ToDictionary(g => g.Key, g => Sum(g.ToList()));
        }

        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
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