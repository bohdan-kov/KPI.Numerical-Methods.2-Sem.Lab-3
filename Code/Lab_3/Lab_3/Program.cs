using System;

class Program
{
    static void Main(string[] args)
    {
        double[,] A = {
            {2.0, 3.0, 0.0},
            {0.0, 1.0, 0.0},
            {1.0, 4.0, 5.0}
        };

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(A);

        Console.WriteLine("Приведение матрицы к ступенчатому виду:");
        FrobeniusNormalForm(A);
        PrintMatrix(A);

        Console.WriteLine("Приведение матрицы к нормальной форме Фробениуса:");
        FrobeniusNormalFormIntermediateSteps(A);
        PrintMatrix(A);
    }

    static void FrobeniusNormalForm(double[,] A)
    {
        int n = A.GetLength(0); // Получаем количество строк матрицы

        // Приводим матрицу к ступенчатому виду
        for (int i = 0; i < n; i++)
        {
            // Поиск ненулевого элемента в столбце
            int pivotRow = -1;
            for (int j = i; j < n; j++)
            {
                if (Math.Abs(A[j, i]) > double.Epsilon)
                {
                    pivotRow = j;
                    break;
                }
            }

            // Если не найден ненулевой элемент, пропускаем данный столбец
            if (pivotRow == -1)
                continue;

            // Обмен строк, чтобы ненулевой элемент стал главным
            if (pivotRow != i)
            {
                for (int k = 0; k < n; k++)
                {
                    double temp = A[i, k];
                    A[i, k] = A[pivotRow, k];
                    A[pivotRow, k] = temp;
                }
            }

            // Приводим остальные элементы в столбце к нулю
            for (int j = i + 1; j < n; j++)
            {
                double factor = A[j, i] / A[i, i];
                for (int k = i; k < n; k++)
                {
                    A[j, k] -= factor * A[i, k];
                }
            }
        }
    }

    static void FrobeniusNormalFormIntermediateSteps(double[,] A)
    {
        int n = A.GetLength(0); // Получаем количество строк матрицы

        // Приводим матрицу к ступенчатому виду
        for (int i = 0; i < n; i++)
        {
            // Поиск ненулевого элемента в столбце
            int pivotRow = -1;
            for (int j = i; j < n; j++)
            {
                if (Math.Abs(A[j, i]) > double.Epsilon)
                {
                    pivotRow = j;
                    break;
                }
            }

            // Если не найден ненулевой элемент, пропускаем данный столбец
            if (pivotRow == -1)
                continue;

            // Обмен строк, чтобы ненулевой элемент стал главным
            if (pivotRow != i)
            {
                for (int k = 0; k < n; k++)
                {
                    double temp = A[i, k];
                    A[i, k] = A[pivotRow, k];
                    A[pivotRow, k] = temp;
                }
            }

            // Приводим остальные элементы в столбце к нулю
            for (int j = i + 1; j < n; j++)
            {
                double factor = A[j, i] / A[i, i];
                for (int k = i; k < n; k++)
                {
                    A[j, k] -= factor * A[i, k];
                }
            }

            Console.WriteLine($"Шаг {i + 1}:");
            PrintMatrix(A);
        }
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
