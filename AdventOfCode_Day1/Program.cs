// Yeah, i can do this assignment in one function i know.
// I probably make a second version without creating my own
// datatype and all of this mess. But it works ¯\_(ツ)_/¯

using System;
using System.IO;

namespace AdventOfCode_Day1
{
    class Program
    {

        private static int SumAllNextMatchingDigits(int[] input)
        {
            CircularIntArray unsolvedCaptchaArray = new CircularIntArray(input);
            int solvedCaptcha = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (unsolvedCaptchaArray.Current() == unsolvedCaptchaArray.MoveNext())
                {
                    solvedCaptcha += unsolvedCaptchaArray.Current();
                }
            }

            return solvedCaptcha;       
        }

        private static int SkipAndSumMatchingDigits(int[] input, int skipAmount)
        {
            CircularIntArray unsolvedCaptchaArray = new CircularIntArray(input);
            int solvedCaptcha = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (unsolvedCaptchaArray.Current() == unsolvedCaptchaArray.SkipAndMoveNext(skipAmount))
                {
                    solvedCaptcha += unsolvedCaptchaArray.GetValueOfIndex(i); // I can't use .Current() because we are on next digit already :<
                }
            }

            return solvedCaptcha;
        }

        static void Main()
        {
            string unsolvedCaptcha = File.ReadAllText("input.txt");

            int arrayLength = unsolvedCaptcha.Length;
            int[] unsolvedCaptchaArray = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                unsolvedCaptchaArray[i] = Convert.ToInt32(Char.GetNumericValue(unsolvedCaptcha[i]));
            }

            Console.WriteLine("Part 1: {0}", SumAllNextMatchingDigits(unsolvedCaptchaArray));

            int skipAmount = arrayLength / 2;
            Console.WriteLine("Part 2: {0}", SkipAndSumMatchingDigits(unsolvedCaptchaArray, skipAmount));

            Console.ReadKey();
        }
    }
}
