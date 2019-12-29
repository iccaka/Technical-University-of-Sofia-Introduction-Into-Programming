using System;
using System.Collections.Generic;
using System.IO;

namespace MatrixProcessingFromFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader sr =
                new StreamReader(
                    "/home/iccaka/Documents/programmingRelatedPrograms/riderProjects/MoodleProblemsPlayground/MatrixProcessingFromFile/MatrixProcessingFromFile/sampleText.txt");

            String firstLine = sr.ReadLine();
            String secondLine = sr.ReadLine();
            int matrixRows = 0;
            int matrixCols = 0;

            if (firstLine != null)
            {
                matrixRows = int.Parse(firstLine);
            }

            if (secondLine != null)
            {
                matrixCols = int.Parse(secondLine);
            }

            double[][] matrix = new double[matrixRows][];

            for (int i = 0; i <= matrixRows - 1; i++)
            {
                matrix[i] = new double[matrixCols];
                String[] nums = sr.ReadLine()?.Split(Convert.ToChar(" "));

                for (int j = 0; j <= matrixCols - 1; j++)
                {
                    try
                    {
                        if (nums != null)
                        {
                            matrix[i][j] = double.Parse(nums[j]);
                        }
                    }
                    catch (NullReferenceException nre)
                    {
                        throw new NullReferenceException();
                    }
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine();
            Console.WriteLine(CheckIdentity(matrix) ? "The matrix is diagonal." : "The matrix is not diagonal.");
            Console.WriteLine("The count of all negative numbers on the secondary diagonal: " +
                              SumNegativeOnAntiDiagonal(matrix));
            Console.WriteLine();
            PrintMatrix(NormalizeRows(matrix));
            Console.WriteLine();
            PrintMatrix(SortMatrix(matrix));
        }

        public static void PrintMatrix(double[][] matrix)
        {
            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                for (int j = 0; j <= matrix[i].Length - 1; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }

                Console.WriteLine();
            }
        }

        public static bool CheckIdentity(double[][] matrix)
        {
            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                for (int j = 0; j <= matrix[i].Length - 1; j++)
                {
                    if (j == i)
                    {
                        if ((matrix[i][j] + "").Length > 1)
                        {
                            return false;
                        }
                        else
                        {
                            if (matrix[i][j] != 1)
                            {
                                return false;
                            }
                        }

                        continue;
                    }

                    if ((matrix[i][j] + "").ToString().Length > 1)
                    {
                        return false;
                    }
                    else
                    {
                        if (matrix[i][j] != 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static double SumNegativeOnAntiDiagonal(double[][] matrix)
        {
            double result = 0;

            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                if (matrix[i][matrix[i].Length - 1 - i] < 0)
                {
                    result += matrix[i][matrix[i].Length - 1 - i];
                }
            }

            return result;
        }

        public static double[][] NormalizeRows(double[][] matrix)
        {
            double[][] resultMatrix = matrix;

            for (int i = 0; i <= matrix.Length - 1; i++)
            {
                double rowResult = 0;

                for (int j = 0; j <= matrix[i].Length - 1; j++)
                {
                    rowResult += Math.Pow(matrix[i][j], 2);
                }

                double squareRootOfRowResult = Math.Sqrt(rowResult);

                for (int k = 0; k <= resultMatrix[i].Length - 1; k++)
                {
                    resultMatrix[i][k] /= squareRootOfRowResult;
                }
            }

            return resultMatrix;
        }

        public static double[][] SortMatrix(double[][] matrix)
        {
            double[][] transposeMatrix = new double[matrix[0].Length][];

            for (int i = 0; i <= transposeMatrix.Length - 1; i++)
            {
                transposeMatrix[i] = new double[matrix.Length];
                
                for (int j = 0; j <= transposeMatrix[i].Length - 1; j++)
                {
                    transposeMatrix[i][j] = matrix[j][i];
                }
            }

            double[][] resultMatrix = transposeMatrix;

            for (int k = 0; k <= resultMatrix.Length - 1; k++)
            {
                double[] rowOfNums = resultMatrix[k];

                if (k % 2 == 0)
                {
                    bool isSorted = false;
                    
                    while (!isSorted)
                    {
                        isSorted = true;

                        for (int l = 0; l <= rowOfNums.Length - 2; l++)
                        {
                            if (rowOfNums[l] > rowOfNums[l + 1])
                            {
                                isSorted = false;
                                
                                double temporaryNum = rowOfNums[l + 1];
                                rowOfNums[l + 1] = rowOfNums[l];
                                rowOfNums[l] = temporaryNum;
                            }
                        }
                    }
                }
                else
                {
                    bool isSorted = false;
                    
                    while (!isSorted)
                    {
                        isSorted = true;

                        for (int l = 0; l <= rowOfNums.Length - 2; l++)
                        {
                            if (rowOfNums[l] < rowOfNums[l + 1])
                            {
                                isSorted = false;
                                
                                double temporaryNum = rowOfNums[l + 1];
                                rowOfNums[l + 1] = rowOfNums[l];
                                rowOfNums[l] = temporaryNum;
                            }
                        }
                    }
                }

                resultMatrix[k] = rowOfNums;
            }
            
            double[][] transposeResultMatrix = new double[resultMatrix[0].Length][];

            for (int m = 0; m <= transposeResultMatrix.Length - 1; m++)
            {
                transposeResultMatrix[m] = new double[resultMatrix.Length];
                
                for (int n = 0; n <= transposeResultMatrix[m].Length - 1; n++)
                {
                    transposeResultMatrix[m][n] = resultMatrix[n][m];
                }
            }
            
            return transposeResultMatrix;
        }
    }
}