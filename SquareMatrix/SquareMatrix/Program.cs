using System;
using System.IO;

namespace SquareMatrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            String input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The thing you've entered is invalid.\nAborting...");
                return;
            }

            int matrixSize = int.Parse(input);
            int[][] matrix = new int[matrixSize][];

            StreamReader sr =
                new StreamReader(
                    "/home/iccaka/Documents/programmingRelatedPrograms/riderProjects/MoodleProblemsPlayground/SquareMatrix/SquareMatrix/sampleText.txt");

            for (int i = 0; i <= (matrixSize * matrixSize) - 1; i++)
            {
                String[] commands;

                try
                {
                    commands = sr.ReadLine()?.Split(Convert.ToChar("\t"));

                    if (commands != null)
                    {
                        if (commands.Length < 3)
                        {
                            try
                            {
                                matrix[int.Parse(commands[0]) - 1][int.Parse(commands[1]) - 1] = -1;
                            }
                            catch (Exception e)
                            {
                                matrix[int.Parse(commands[0]) - 1] = new int[matrixSize];
                                matrix[int.Parse(commands[0]) - 1][int.Parse(commands[1]) - 1] = -1;
                            }
                        }
                        else
                        {
                            try
                            {
                                matrix[int.Parse(commands[0]) - 1][int.Parse(commands[1]) - 1] = int.Parse(commands[2]);
                            }
                            catch (Exception e)
                            {
                                matrix[int.Parse(commands[0]) - 1] = new int[matrixSize];
                                matrix[int.Parse(commands[0]) - 1][int.Parse(commands[1]) - 1] = int.Parse(commands[2]);
                            }
                        }
                    }
                }
                catch (NullReferenceException nre)
                {
                    throw new NullReferenceException();
                }
            }
            
            int evenNumsCount = 0;
            int oddNumsCount = 0;
            int evenRowsNumsCount = 0;
            int oddColumnsNumsCount = 0;
            
            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                for (int j = 0; j <= matrix.Length - 1; j++)
                {
                    if (matrix[i][j] % 2 == 0)
                    {
                        evenNumsCount += matrix[i][j];
                    }
                    else
                    {
                        oddNumsCount += matrix[i][j];
                    }

                    if (i % 2 != 0)
                    {
                        evenRowsNumsCount += matrix[i][j];
                    }

                    if (j % 2 == 0)
                    {
                        oddColumnsNumsCount += matrix[i][j];
                    }
                    
                    Console.Write(matrix[i][j] + "\t");
                }

                Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine("Even numbers count: " + evenNumsCount);
            Console.WriteLine("Odd numbers count: " + oddNumsCount);
            Console.WriteLine();
            Console.WriteLine("Numbers on even rows count: " + evenRowsNumsCount);
            Console.WriteLine("Numbers on odd columns count: " + oddNumsCount);
        }
    }
}