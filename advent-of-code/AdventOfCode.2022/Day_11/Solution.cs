// using AoC.Day_11.Part2;
//
// namespace AoC.Day_11;
//
// public class Formula 
// {
//     public bool IsDivisible(long divisor)
//     {
//         if (input.oper == '*')
//         {
//             
//         }
//
//         return (input.a % Divisor + input.b % Divisor) % Divisor;
//         
//         if (Type == OpType.mul)
//         {
//             return ((A % divisor) * (A % divisor)) % divisor;
//         }
//         else
//         {
//             
//         }
//     }
//
//     public MyNumber A { get; set; }
//     public MyNumber B { get; set; }
//     public OpType Type { get; set; }
//     
//     public enum OpType
//     {
//         mul,
//         sum
//     }
// }
//
// public class MyNumber
// {
//     public Operation Op { get; set; }
//     
// }
//
// public class Solution
// {
//     public static void Run()
//     {
//         var lines = File.ReadAllLines("test.txt");
//         var index = 0;
//         var dict = new Dictionary<long, Monke>();
//         while (index < lines.Length)
//         {
//             var monkeyIndex = lines[index++];
//             var startingItems = lines[index++];
//             var operation = new Operation(lines[index++]);
//             var test = lines[index++];
//             var ifTrue = lines[index++];
//             var ifFalse = lines[index++];
//             var monkeTest = new Test(test, ifTrue, ifFalse);
//
//             var monke = new Monke(monkeyIndex, startingItems, operation, monkeTest);
//             dict.Add(monke.Index, monke);
//             
//             index++; // skip empty line
//         }
//
//
//         for (long roundIndex = 0; roundIndex < 1000; roundIndex++)
//         {
//             foreach (var (_, monke) in dict.OrderBy(kv => kv.Key))
//             {
//                 monke.InspectAll(dict);
//             }
//         }
//
//         var idx = 0;
//         foreach (var kvpair in dict.OrderBy(kv => kv.Key))
//         {
//             Console.WriteLine($"Monke {idx++} : {kvpair.Value.Counter}");
//         }
//
//         var biggestCounters = dict.OrderByDescending(kv => kv.Value.Counter).Take(2).Select(kv => kv.Value.Counter).ToArray();
//         
//         Console.WriteLine(biggestCounters[0] * biggestCounters[1]);
//     }
// }
//
// public class Monke
// {
//     public Monke(string index, string startingItems, Operation operation, Test test)
//     {
//         Index = long.Parse(index.Replace(":", string.Empty).Split(" ").Last());
//         var items = startingItems.Replace("Starting items: ", string.Empty).Split(", ").Select(long.Parse).ToList();
//         Items = new Queue<long>(items);
//         Operation = operation;
//         Test = test;
//     }
//
//     public long Index { get; set; }
//     public Queue<long> Items { get; set; }
//     public Operation Operation { get; set; }
//     public Test Test { get; set; }
//
//     public long Counter { get; set; }
//
//     public void InspectAll(Dictionary<long, Monke> dictionary)
//     {
//         while (Items.Any())
//         {
//             Inspect(Items.Dequeue(), dictionary);
//         }
//     }
//
//     private void Inspect(Wrapper.Number item, Dictionary<long, Monke> dictionary)
//     {
//         Counter++;
//         var newWorryLevel = Operation.Apply(item);
//         // part1 only
//         // newWorryLevel = Convert.ToInt64(Math.Floor((double)newWorryLevel / 3));
//         var monkeyToThrowTo = Test.Apply(newWorryLevel);
//         dictionary[monkeyToThrowTo].Items.Enqueue(newWorryLevel);
//     }
// }
//
// public class Test
// {
//     public Func<long, bool> IsDivisible { get; set; }
//     
//     public long Divisor { get; set; }
//     public Func<bool, long> GetMonkeyToThrowTo { get; set; }
//     
//     public Test(string test, string ifTrue, string ifFalse)
//     {
//         var arg  = long.Parse(test.Split(" ").Last()); // the type is always 'is divisible'
//         IsDivisible = i => i % arg == 0;
//         Divisor = arg;
//
//         var throwIfTrue = long.Parse(ifTrue.Split(" ").Last());
//         var throwIfFalse = long.Parse(ifFalse.Split(" ").Last());
//         GetMonkeyToThrowTo = b => b ? throwIfTrue : throwIfFalse;
//     }
//
//     // part1
//     // public long Apply(long worryLevel)
//     // {
//     //     var isDivisible = IsDivisible(worryLevel);
//     //     return GetMonkeyToThrowTo(isDivisible);
//     // }
//     
//     // part2
//     public (long monkey, long worryLevel) Apply((long a, long b, char oper) input)
//     {
//         var iDivisible = IsDivisiblePart2(input);
//         return GetMonkeyToThrowTo(iDivisible);
//     }
//
//     // part2
//     public long IsDivisiblePart2((long a, long b, char oper) input)
//     {
//         if (input.oper == '*')
//         {
//             return ((input.a % Divisor) * (input.b % Divisor)) % Divisor;
//         }
//
//         return (input.a % Divisor + input.b % Divisor) % Divisor;
//     }
// }
//
// public class Operation
// {
//     // part1
//     // public Func<long, long> GetUpdatedWorryLevel { get; set; }
//     
//     // part2
//     public Func<Wrapper.Number, Wrapper.Number> GetUpdatedWorryLevel { get; set; }
//
//     // part1
//     // public Operation(string operation)
//     // {
//     //     bool withOld = operation.EndsWith("old");
//     //
//     //     
//     //     if (operation.Contains('*'))
//     //     {
//     //         if (!withOld)
//     //         {
//     //             var arg = long.Parse(operation.Split(" ").Last());
//     //             GetUpdatedWorryLevel = i => i * arg;
//     //         }
//     //         else
//     //         {
//     //             GetUpdatedWorryLevel = i => i * i;
//     //         }
//     //     }
//     //     else if (operation.Contains('+'))
//     //     {
//     //         if (!withOld)
//     //         {
//     //             var arg = long.Parse(operation.Split(" ").Last());
//     //             GetUpdatedWorryLevel = i => i + arg;
//     //         }
//     //         else
//     //         {
//     //             GetUpdatedWorryLevel = i => i + i;
//     //         }
//     //     }
//     //     else
//     //     {
//     //         throw new ArgumentOutOfRangeException();
//     //     }
//     // }
//
//     // par2
//     public Operation(string operation)
//     {
//         var oper = operation.Contains('*') ? '*' : '+';
//         
//         if (operation.EndsWith("old"))
//         {
//             GetUpdatedWorryLevel = l => new Wrapper.Number() { A = l, B = l, Operator = oper == '*' ? Wrapper.Operator.Mul : Wrapper.Operator.Add};
//         }
//         else
//         {
//             var arg = long.Parse(operation.Split(" ").Last());
//             var newNum = new Wrapper.Number() { Value = arg };
//             GetUpdatedWorryLevel = l => new Wrapper.Number() { A = l, B = newNum, Operator = oper == '*' ? Wrapper.Operator.Mul : Wrapper.Operator.Add};
//         }
//     }
//
//     public Wrapper.Number Apply(Wrapper.Number worryLevel)
//     {
//         return GetUpdatedWorryLevel(worryLevel);
//     }
//
//
//     // part1
//     // public long Apply(long worryLevel)
//     // {
//     //     return GetUpdatedWorryLevel(worryLevel);
//     // }
// }
//
//
// /*
// Monkey 0:
//   Starting items: 79, 98
//   Operation: new = old * 19
//   Test: divisible by 23
//     If true: throw to monkey 2
//     If false: throw to monkey 3
//  */