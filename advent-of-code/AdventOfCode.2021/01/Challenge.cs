using advent_of_code.challenges;

namespace AdventOfCode._2021._2021._01
{
    public class Challenge : ChallengeBase
    {
        public static void Run()
        {
            var ops = File.ReadAllLines("input.txt").Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Split())
                .Select(
                    arr => new { op = arr.First(), val = int.Parse(arr.Last()) }).ToArray();

            var aim = 0;
            var ver = 0;
            var hor = 0;

            foreach (var op in ops)
            {
                switch (op.op)
                {
                    case "forward":
                        hor += op.val;
                        ver += aim * op.val;
                        break;
                    case "down":
                        aim += op.val;
                        break;
                    case "up":
                        aim -= op.val;
                        break;
                }
            }

            Console.WriteLine($"ver: {ver}, hor: {hor}, mult: {ver * hor}");
        
        
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