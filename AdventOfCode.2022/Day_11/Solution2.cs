using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2022.Day_11;

public class Wrapper
{
    private static readonly Dictionary<(Number, long), long> IsDivisibleCache = new();

    public enum Operator
    {
        Mul,
        Add
    }

    public class Number
    {
        public Number? A { get; set; }
        public Number? B { get; set; }
        public Operator? Operator { get; set; }
        public long? Value { get; set; }

        public long Modulo(long divisor)
        {
            if (IsDivisibleCache.TryGetValue((this, divisor), out var result))
            {
                return result % divisor;
            }

            if (A is null && B is null)
            {
                return Value!.Value % divisor;
            }

            return Operator switch
            {
                Wrapper.Operator.Mul => ((A.Modulo(divisor)) * (B.Modulo(divisor))) % divisor,
                Wrapper.Operator.Add => (A.Modulo(divisor) + B.Modulo(divisor)) % divisor,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public class Solution2
    {
        public static void Run2()
        {
            var lines = File.ReadAllLines("input.txt");
            var index = 0;
            var monkeDict = new Dictionary<int, Monke>();
            while (index < lines.Length)
            {
                var monkeyIndex = lines[index++];
                var startingItems = lines[index++];
                var operation = new Test.Operation2(lines[index++]);
                var test = lines[index++];
                var ifTrue = lines[index++];
                var ifFalse = lines[index++];
                var monkeTest = new Test(test, ifTrue, ifFalse);

                var monke = new Monke(monkeyIndex, startingItems, operation, monkeTest);
                monkeDict.Add(monke.Index, monke);

                index++; // skip empty line
            }


            for (long roundIndex = 0; roundIndex < 10000; roundIndex++)
            {
                foreach (var (_, monke) in monkeDict.OrderBy(kv => kv.Key))
                {
                    monke.InspectAll(monkeDict);
                }
            }

            var idx = 0;
            foreach (var kvpair in monkeDict.OrderBy(kv => kv.Key))
            {
                Console.WriteLine($"Monke {idx++} : {kvpair.Value.Counter}");
            }

            var biggestCounters = monkeDict.OrderByDescending(kv => kv.Value.Counter).Take(2)
                .Select(kv => kv.Value.Counter).ToArray();

            Console.WriteLine(biggestCounters[0] * biggestCounters[1]);
        }
    }

    public class Monke
    {
        public Monke(string index, string startingItems, Test.Operation2 operation, Test test)
        {
            Index = int.Parse(index.Replace(":", string.Empty).Split(" ").Last());
            var items = startingItems
                .Replace("Starting items: ", string.Empty)
                .Split(", ")
                .Select(long.Parse)
                .Select(l => new Number() { Value = l })
                .ToList();
            Items = new Queue<Number>(items);
            Operation = operation;
            Test = test;
        }

        public int Index { get; set; }
        public Queue<Number> Items { get; set; }
        public Test.Operation2 Operation { get; set; }
        public Test Test { get; set; }

        public long Counter { get; set; }

        public void InspectAll(Dictionary<int, Monke> dictionary)
        {
            while (Items.Any())
            {
                Inspect(Items.Dequeue(), dictionary);
            }
        }

        private void Inspect(Number item, Dictionary<int, Monke> dictionary)
        {
            Counter++;
            var newWorryLevel = Operation.Apply(item);
            // part1 only
            // newWorryLevel = Convert.ToInt64(Math.Floor((double)newWorryLevel / 3));
            var monkeyToThrowTo = Test.Apply(newWorryLevel);
            dictionary[monkeyToThrowTo].Items.Enqueue(newWorryLevel);
        }
    }

    public class Test
    {
        public Func<long, bool> IsDivisible { get; set; }

        public long Divisor { get; set; }
        public Func<bool, int> GetMonkeyToThrowTo { get; set; }

        public Test(string test, string ifTrue, string ifFalse)
        {
            var arg = long.Parse(test.Split(" ").Last()); // the type is always 'is divisible'
            IsDivisible = i => i % arg == 0;
            Divisor = arg;

            var throwIfTrue = int.Parse(ifTrue.Split(" ").Last());
            var throwIfFalse = int.Parse(ifFalse.Split(" ").Last());
            GetMonkeyToThrowTo = b => b ? throwIfTrue : throwIfFalse;
        }

        // part1
        // public long Apply(long worryLevel)
        // {
        //     var isDivisible = IsDivisible(worryLevel);
        //     return GetMonkeyToThrowTo(isDivisible);
        // }

        // part2
        public int Apply(Number newWorryLevel)
        {
            var iDivisible = IsDivisiblePart2(newWorryLevel);
            var monkeyToThrowTo = GetMonkeyToThrowTo(iDivisible);
            return monkeyToThrowTo;
        }

        // part2
        public bool IsDivisiblePart2(Number input)
        {
            if (IsDivisibleCache.TryGetValue((input, Divisor), out long modResult))
            {
                return modResult % Divisor == 0;
            }

            var result = input.Modulo(Divisor);
            IsDivisibleCache[(input, Divisor)] = result;
            return result % Divisor == 0;
        }

        public class Operation2
        {
            // part1
            // public Func<long, long> GetUpdatedWorryLevel { get; set; }

            // part2
            public Func<Number, Number> GetUpdatedWorryLevel { get; set; }

            // part1
            // public Operation(string operation)
            // {
            //     bool withOld = operation.EndsWith("old");
            //
            //     
            //     if (operation.Contains('*'))
            //     {
            //         if (!withOld)
            //         {
            //             var arg = long.Parse(operation.Split(" ").Last());
            //             GetUpdatedWorryLevel = i => i * arg;
            //         }
            //         else
            //         {
            //             GetUpdatedWorryLevel = i => i * i;
            //         }
            //     }
            //     else if (operation.Contains('+'))
            //     {
            //         if (!withOld)
            //         {
            //             var arg = long.Parse(operation.Split(" ").Last());
            //             GetUpdatedWorryLevel = i => i + arg;
            //         }
            //         else
            //         {
            //             GetUpdatedWorryLevel = i => i + i;
            //         }
            //     }
            //     else
            //     {
            //         throw new ArgumentOutOfRangeException();
            //     }
            // }

            // par2
             public Operation2(string operation)
             {
                 var oper = operation.Contains('*') ? '*' : '+';
                 
                 if (operation.EndsWith("old"))
                 {
                     GetUpdatedWorryLevel = l => new Wrapper.Number() { A = l, B = l, Operator = oper == '*' ? Wrapper.Operator.Mul : Wrapper.Operator.Add};
                 }
                 else
                 {
                     var arg = long.Parse(operation.Split(" ").Last());
                     var newNum = new Wrapper.Number() { Value = arg };
                     GetUpdatedWorryLevel = l => new Wrapper.Number() { A = l, B = newNum, Operator = oper == '*' ? Wrapper.Operator.Mul : Wrapper.Operator.Add};
                 }
             }

     public Wrapper.Number Apply(Wrapper.Number worryLevel)
     {
         return GetUpdatedWorryLevel(worryLevel);
     }


            // part1
            // public long Apply(long worryLevel)
            // {
            //     return GetUpdatedWorryLevel(worryLevel);
            // }
        }


        /*
        Monkey 0:
          Starting items: 79, 98
          Operation: new = old * 19
          Test: divisible by 23
            If true: throw to monkey 2
            If false: throw to monkey 3
         */
    }
}