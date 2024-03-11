using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Lab2CSharp;


internal class Program
{
    static void Print(int[] a)
    {
        for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
        Console.WriteLine();
    }
    static void PrintMatrix(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    static int[] Create()
    {
        Console.WriteLine("Розмірність масиву: ");
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(Console.ReadLine());
        }
        return a;
    }
    static void task1()
    {
        int[] array;
        array = Create();
        Print(array);

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0 && array[i] % 3 != 0)
            {
                array[i] = -array[i];
            }
        }
        Print(array);
        Console.WriteLine();
        Console.WriteLine("Розмірність масиву: [n,m]");
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());


        int[,] matrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        PrintMatrix(matrix);
        Console.WriteLine("Змінена ");
        for (int i = 0; i < n; i++)
        {
           for(int j =0; j < m; j++)
            {
                if (matrix[i, j] < 0 && matrix[i, j] % 3 != 0)
                {
                    matrix[i, j] = -matrix[i, j];
                }
            }
        }
        PrintMatrix(matrix);
    }
    static void task2()
    {
        int[] array;
        array = Create();
        Print(array);
        int min = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min) min = array[i];
        }
        Console.WriteLine("Min element - " + min);
        // Заміна мінімальних елементів на протилежні
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == min)
            {
                array[i] = -min; // Заміна на протилежне число
            }
        }
        Print(array);
    }
    static void task3()
    {
        Console.Write("Введіть розмірність n для двовимірного масиву (n x n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        // Зчитуємо елементи масиву з консолі
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Введіть елемент [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        PrintMatrix(matrix);
        // Підрахунок середнього арифметичного ненульових елементів над побічною діагоналлю
        int sum = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] != 0)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }
        // Виведення результату
        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"Середнє арифметичне ненульових елементів над побічною діагоналлю: {average}");
        }
        else
        {
            Console.WriteLine("Немає ненульових елементів над побічною діагоналлю.");
        }
    }
    static void task4()
    {
        int[][] jaggedArray = CreateAndFillJaggedArray();

        // Виведення східчастого масиву
        Console.WriteLine("Східчастий масив:");
        PrintJaggedArray(jaggedArray);
        // Підрахунок сум від'ємних елементів для кожного стовпця
        int[] columnSums = CalculateNegativeColumnSums(jaggedArray);

        Console.WriteLine("\nСуми від'ємних елементів для кожного стовпця:");
        Print(columnSums);
    }
    static int[] CalculateNegativeColumnSums(int[][] jaggedArray)
    {
        int columns = jaggedArray.Max(row => row.Length);
        int[] columnSums = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (j < jaggedArray[i].Length && jaggedArray[i][j] < 0)
                {
                    columnSums[j] += jaggedArray[i][j];
                }
            }
        }

        return columnSums;
    }
    static int[][] CreateAndFillJaggedArray()
    {
        Console.Write("Введіть кількість рядків: ");
        int rows = int.Parse(Console.ReadLine());

        // Створення східчастого масиву
        int[][] jaggedArray = new int[rows][];

        // Введення та ініціалізація елементів масиву
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
            int columns = int.Parse(Console.ReadLine());

            jaggedArray[i] = new int[columns];

            Console.WriteLine($"Введіть елементи для рядку {i + 1}:");
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        return jaggedArray;
    }

    static void PrintJaggedArray(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Lab 2 CSharp");
        while (true)
        {
            Console.WriteLine("Введiть номер завдання:");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                case 4:
                    task4();
                    break;
                default:
                    Console.WriteLine("Не вiрно");
                    break;
            }
        }
    }
}
