using System;

public class Program
{
    private static int DEFAULT_FIRST_NUMBER = 2;
    private static int DEFAULT_SECOND_NUMBER = 4;
    private static int DEFAULT_THIRD_NUMBER = 6;
    private static int[] numList;

    public static void Main()
    {
        Console.WriteLine("Enter a number:");

        int n = int.Parse(Console.ReadLine());
        numList = new int[n];

        numList[0] = DEFAULT_FIRST_NUMBER;
        numList[1] = DEFAULT_SECOND_NUMBER;
        numList[2] = DEFAULT_THIRD_NUMBER;

        Console.WriteLine("With recursion: " + findNthNumberWithRecursion(n));
        Console.WriteLine("Without recursion: " + FindNthNumberByDefault(n));
    }

    private static int findNthNumberWithRecursion(int n)
    {
        if (n <= 3 && n > 0)
        {
            switch (n)
            {
                case 1:
                    return DEFAULT_FIRST_NUMBER;
                case 2:
                    return DEFAULT_SECOND_NUMBER;
                case 3:
                    return DEFAULT_THIRD_NUMBER;
            }
        }

        if (n <= 0)
        {
            return 0;
        }

        return ((3 * findNthNumberWithRecursion(n - 3)) + (4 * findNthNumberWithRecursion(n - 2)) -
                (7 * findNthNumberWithRecursion(n - 1)));
    }

    private static int FindNthNumberByDefault(int n)
    {
        if (n <= 3 && n > 0)
        {
            return (int) numList[n - 1];
        }

        if (n <= 0)
        {
            return 0;
        }

        for (int i = 3; i < n; i++)
        {
            numList[i] = (3 * (int) numList[i - 3]) + (4 * (int) numList[i - 2]) - (7 * (int) numList[i - 1]);
        }

        return (int) numList[n - 1];
    }
}