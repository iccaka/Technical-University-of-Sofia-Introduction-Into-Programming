using System;
using System.Collections.Generic;
using System.IO;

namespace OddEven
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();

            StreamReader sr =
                new StreamReader(
                    "/home/iccaka/Documents/programmingRelatedPrograms/riderProjects/MoodleProblemsPlayground/OddEven/OddEven/text.txt");

            while (sr.Peek() >= 0)
            {
                try
                {
                    String[] nums = sr.ReadLine().Split(null);
                    List<int> intList = new List<int>();
                    
                    for (int i = 0; i <= nums.Length - 1; i++)
                    {
                        try
                        {
                            intList.Add(int.Parse(nums[i]));
                        }
                        catch (ArgumentNullException ane)
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    
                    matrix.Add(intList);
                }
                catch (System.NullReferenceException nre)
                {
                    throw new NullReferenceException();
                }
            }

            Console.WriteLine(FindOddNumsSumOnEvenColumns(matrix));
            Console.WriteLine(FindEvenNumsSumOnOddRows(matrix));
        }

        public static int FindOddNumsSumOnEvenColumns(List<List<int>> matrix)
        {
            int result = 0;

            for (int i = 0; i <= matrix.Count - 1; i++)
            {
                for (int j = 0; j <= matrix[i].Count - 1; j++)
                {
                    if (j % 2 != 0)
                    {
                        if (matrix[i][j] % 2 != 0)
                        {
                            result += matrix[i][j];
                        }
                    }
                }
            }

            return result;
        }

        public static int FindEvenNumsSumOnOddRows(List<List<int>> matrix)
        {
            int result = 0;

            for (int i = 0; i <= matrix.Count - 1; i++)
            {
                for (int j = 0; j <= matrix[i].Count - 1; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (matrix[i][j] % 2 == 0)
                        {
                            result += matrix[i][j];
                        }
                    }
                }
            }

            return result;
        }
    }
}