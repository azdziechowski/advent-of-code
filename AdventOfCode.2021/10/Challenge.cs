using advent_of_code.challenges;

namespace AdventOfCode._2021._2021._10
{
    public class Challenge : ChallengeBase
    {
        private static Dictionary<char, int> scores = new Dictionary<char, int>()
            { 
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137},
            };
        
        private static Dictionary<char, int> autocompleteScores = new Dictionary<char, int>()
            { 
                {')', 1},
                {']', 2},
                {'}', 3},
                {'>', 4},
            };

        public static void Run()
        {
            var lines = File.ReadAllLines("input.txt");

            #region part1
            // var total = 0;
            // foreach (var line in lines)
            // {
            //     Stack<char> stack = new Stack<char>();
            //     stack.Push(line.First());
            //     for (var i = 1; i < line.Length; i++)
            //     {
            //         if (IsClosingTag(line[i]))
            //         {
            //             var popped = stack.Pop();
            //             if (AreMatchingTags(popped, line[i]))
            //             {
            //                 continue;
            //             }
            //
            //             total += scores[line[i]];
            //             break;
            //         }
            //
            //         stack.Push(line[i]);
            //     }
            // }
            //
            // Console.WriteLine(total);
            #endregion

            var incompletes = new List<string>();
            foreach (var line in lines)
            {
                var corrupt = false;
                Stack<char> stack = new Stack<char>();
                stack.Push(line.First());
                for (var i = 1; i < line.Length; i++)
                {
                    if (IsClosingTag(line[i]))
                    {
                        var popped = stack.Pop();
                        if (AreMatchingTags(popped, line[i]))
                        {
                            continue;
                        }

                        corrupt = true;
                        break;
                    }
            
                    stack.Push(line[i]);
                }

                if (!corrupt)
                {
                    incompletes.Add(line);
                }
            }

            var scores = new List<long>();
            foreach (var incomplete in incompletes)
            {
                var toComplete = new List<char>();
                Stack<char> stack = new Stack<char>();
                stack.Push(incomplete.First());
                for (var i = 1; i < incomplete.Length; i++)
                {
                    if (IsClosingTag(incomplete[i]))
                    {
                        var popped = stack.Pop();
                        if (AreMatchingTags(popped, incomplete[i]))
                        {
                            continue;
                        }

                        throw new Exception("should not happen");
                    }
            
                    stack.Push(incomplete[i]);
                }

                while (stack.Any())
                {
                    var popped = stack.Pop();
                    var opposite = popped switch { 
                        '(' => ')',
                        '[' => ']',
                        '{' => '}',
                        '<' => '>',
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    
                    toComplete.Add(opposite);
                }

                long localTotal = 0;
                foreach (var c in toComplete)
                {
                    localTotal *= 5;
                    localTotal += autocompleteScores[c];
                }

                scores.Add(localTotal);
            }

            scores = scores.OrderBy(x => x).ToList();
            Console.WriteLine(scores[scores.Count / 2]);
        }

        public static bool IsClosingTag(char tag)
        {
            return ")]}>".Contains(tag);
        }

        public static bool AreMatchingTags(char tagLeft, char tagRight)
        {
            return tagLeft == '(' && tagRight == ')' ||
                   tagLeft == '[' && tagRight == ']' ||
                   tagLeft == '<' && tagRight == '>' ||
                   tagLeft == '{' && tagRight == '}';
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