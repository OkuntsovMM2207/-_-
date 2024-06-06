using System;

namespace MultiplicationMatrixApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число (x):");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("Некорректный ввод. Введите целое число.");
                return;
            }

            Console.WriteLine("Введите второе число (y):");
            if (!int.TryParse(Console.ReadLine(), out int y))
            {
                Console.WriteLine("Некорректный ввод. Введите целое число.");
                return;
            }

            int[,] matrix = new int[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    matrix[i, j] = (i + 1) * (j + 1);
                }
            }

            Console.WriteLine("Матрица умножения:");
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
