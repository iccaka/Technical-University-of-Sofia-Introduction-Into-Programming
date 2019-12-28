using System;
using System.IO;

namespace SquareMatrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixSize][];

            StreamReader sr =
                new StreamReader(
                    "/home/iccaka/Documents/programmingRelatedPrograms/riderProjects/MoodleProblemsPlayground/SquareMatrix/SquareMatrix/sampleText.txt");

            for (int i = 0; i <= matrixSize - 1; i++)
            {
                String[] commands = new String[]{""};
                
                try
                {
                    commands = sr.ReadLine().Split(Convert.ToChar("\t"));
                }
                catch (NullReferenceException nre)
                {
                    throw new NullReferenceException();
                }

                if (commands.Length < 3)
                {
                    matrix[int.Parse(commands[0])][int.Parse(commands[1])] = -1;
                }
                else
                {
                    matrix[int.Parse(commands[0])][int.Parse(commands[1])] = int.Parse(commands[2]);
                }
            }

            for (int i = 0; i <= matrixSize - 1; i++)
            {
                for (int j = 0; j <= matrixSize - 1; j++)
                {
                    Console.WriteLine(matrix[i][j]);
                }
            }
        }
    }
}