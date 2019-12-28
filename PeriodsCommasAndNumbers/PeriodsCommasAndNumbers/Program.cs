using System;
using System.IO;

namespace PeriodsCommasAndNumbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int commaCount = 0;
            int periodCount = 0;
            int wholeNumCount = 0;

            // Default path: /home/iccaka/Documents/programmingRelatedPrograms/riderProjects/MoodleProblemsPlayground/PeriodsCommasAndNumbers/PeriodsCommasAndNumbers/sampleText.txt
            Console.WriteLine("File path:");
            String path = Console.ReadLine();
            StreamReader sr = new StreamReader(path);

            while (sr.Peek() >= 0)
            {
                String line = sr.ReadLine();

                try
                {
                    periodCount += line.Split(Convert.ToChar(".")).Length - 1;
                    commaCount += line.Split(Convert.ToChar(",")).Length - 1;
                }
                catch (NullReferenceException nre)
                {
                    throw new NullReferenceException();
                }

                int counter = 0;
                bool isOnNumber = false;

                while (counter <= line.Length - 1)
                {
                    if (isOnNumber)
                    {
                        if (line[counter] < 48 || line[counter] > 57)
                        {
                            isOnNumber = false;
                            wholeNumCount++;
                        }                        
                    }
                    if (line[counter] >= 48 && line[counter] <= 57)
                    {
                        isOnNumber = true;
                    }

                    counter++;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Commas: " + commaCount);
            Console.WriteLine("Periods: " + periodCount);
            Console.WriteLine("Numbers: " + wholeNumCount);
        }
    }
}