using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.tasks
{
    public static class Task2
    {
        public static void run(double[,] array)
        {
            Console.WriteLine("массив до:");
            PrintArray(array);

            double maxElement = double.MinValue;
            int maxColumnIndex = -1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > maxElement)
                    {
                        maxElement = array[i, j];
                        maxColumnIndex = j;
                    }
                }
            }

            List<double> maxColumnIndexs = new List<double>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxElement)
                    {
                        maxColumnIndexs.Add(j);
                    }
                }
            }

            maxColumnIndexs.Reverse();
            maxColumnIndexs.ForEach(item => Console.WriteLine(item));
            double[,] newArray = array;
            for (int i = 0; i < maxColumnIndexs.Count; i++)
            {
                newArray = RemoveColumn(newArray, maxColumnIndex);
            }


            Console.WriteLine("\nМассив после:");
            PrintArray(newArray);
        }

        static double[,] RemoveColumn(double[,] array, int columnIndex)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            if(cols == 1)
            {
                return new double[0, 0];
            }
            double[,] newArray = new double[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j < columnIndex)
                    {
                        newArray[i, j] = array[i, j];
                    }
                    else if (j > columnIndex)
                    {
                        newArray[i, j - 1] = array[i, j];
                    }
                }
            }

            return newArray;
        }

        static void PrintArray(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}











/*
         static int FindMaxColumnIndex(double[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            double maxElement = double.MinValue;
            int maxColumnIndex = -1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > maxElement)
                    {
                        maxElement = array[i, j];
                        maxColumnIndex = j;
                    }
                }
            }

            return maxColumnIndex;
        }
 */