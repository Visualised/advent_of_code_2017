using System;
using System.IO;

namespace AdventOfCode_Day2
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("input.txt");
            
            string[] numbersInStringArray = sr.ReadToEnd()
                                              .Split(new String[] { "\r\n", "\t" }, 
                                                     StringSplitOptions.RemoveEmptyEntries);
            int x = 16, y = 16;
            int[,] spreadsheet = new int[x, y];
            spreadsheet = Fill2DIntArrayWithStringArray(numbersInStringArray, spreadsheet, x, y);


            Console.WriteLine("Checksum: {0}", ComputeChecksum(spreadsheet, x, y));
            Console.WriteLine("Evendly divisable numbers: {0}", EvenlyDivisableNumbers(spreadsheet, x, y));
            Console.ReadKey();
        }

        private static int[,] Fill2DIntArrayWithStringArray(string[] stringArray, 
                                                            int[,] int2DArray,
                                                            int x,
                                                            int y)
        {
            int stringArrayCounter = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int2DArray[i, j] = int.Parse(stringArray[stringArrayCounter]);
                    stringArrayCounter++;
                }
            }
            return int2DArray;
        }

        private static int ComputeChecksum(int[,] int2DArray,
                                           int x,
                                           int y)
        {
            int checksum = 0;
            for (int i = 0; i < x; i++)
            {
                int max = 0, min = 0;

                for (int j = 0; j < y; j++)
                {
                    int tempNumber = int2DArray[i, j];
                    if (max == 0 && min == 0)
                    {
                        max = tempNumber;
                        min = tempNumber;
                    }
                    else if (tempNumber > max)
                    {
                        if (max < min)
                            min = max;
                        max = tempNumber;
                    }
                    else if (tempNumber < min)
                    {
                        min = tempNumber;
                    }
                }
                checksum += (max - min);
            }
            return checksum;
        }

        private static int EvenlyDivisableNumbers(int[,] int2DArray,
                                                  int x,
                                                  int y)
        {
            int result = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y - 1; j++) // first number
                {
                    for (int k = j + 1; k < y; k++) // second number
                    {
                        int firstNumber = int2DArray[i, j];
                        int secondNumber = int2DArray[i, k];

                        if ((firstNumber % secondNumber) == 0)
                            result += (firstNumber / secondNumber);
                        else if (secondNumber % firstNumber == 0)
                            result += (secondNumber / firstNumber);
                    }
                }
            }

            return result;
        }
    }
}
