using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code.challenges._2021._03
{
    public class Challenge : ChallengeBase
    {
        public static void Run()
        {
            var arrays = File.ReadAllLines("input.txt")
                .Select(t => t.Trim())
                .Select(l => l.ToCharArray())
                .ToList();

            var records = arrays.Count;

            var result = new char[arrays.First().Length];
            var inverseResult = new char[arrays.First().Length];

            var inputList = arrays;

            int val1 = -1;
            for (int i = 0; i < arrays.First().Length; i++)
            {
                var withOnes = new List<char[]>();
                var withZeroes = new List<char[]>();
                
                foreach (var arr in inputList)
                {
                    if (arr[i] == '1')
                        withOnes.Add(arr);
                    else 
                        withZeroes.Add(arr);
                }

                if (withOnes.Count > withZeroes.Count)
                {
                    inputList = withOnes;
                }
                else if (withZeroes.Count > withOnes.Count)
                {
                    inputList = withZeroes;
                }
                else
                {
                    inputList = withOnes;
                }

                if (inputList.Count == 1)
                {
                    val1 = Convert.ToInt32(new string(inputList.Single()), 2);
                    break;
                }
            }


            int val2 = -1;
            inputList = arrays;
            for (int i = 0; i < arrays.First().Length; i++)
            {
                var withOnes = new List<char[]>();
                var withZeroes = new List<char[]>();
                
                foreach (var arr in inputList)
                {
                    if (arr[i] == '1')
                        withOnes.Add(arr);
                    else 
                        withZeroes.Add(arr);
                }

                if (withOnes.Count < withZeroes.Count)
                {
                    inputList = withOnes;
                }
                else if (withZeroes.Count < withOnes.Count)
                {
                    inputList = withZeroes;
                }
                else
                {
                    inputList = withZeroes;
                }

                if (inputList.Count == 1)
                {
                    val2 = Convert.ToInt32(new string(inputList.Single()), 2);
                    break;
                }
            }
            
            // var resDec = Convert.ToInt32(new string(result), 2);
            // var invResDec = Convert.ToInt32(new string(inverseResult), 2);
            
            Console.WriteLine(val1);
            Console.WriteLine(val2);
            
            Console.WriteLine(val1 * val2);
            
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