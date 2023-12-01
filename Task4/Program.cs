// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. Напишите программу,
// которая удалит строку и столбец, на пересечении которых расположен наименьший
// элемент массива. Под удалением понимается создание нового двумерного массива 
// без строки и столбца.
// Пример
// 4 3 1 => 2 6
// 2 6 9    4 6
// 4 6 2

int[,] myTDArray = CreateTwoDimArray();
FillTwoDimArrayRandomElements(myTDArray, 0, 9);
Console.WriteLine($"Исходный массив");
PrintTwoDimArray(myTDArray, "  ");

int[] arrIndices = arrayIndices(myTDArray);

int[,] matrixCrossDell = TDArrayArterCrossDel(myTDArray, arrIndices[0], arrIndices[1]);

Console.WriteLine($"Первый минимальный элемент с индексом ({arrIndices[0]},{arrIndices[1]})");
Console.WriteLine($"Массив после удаления строки и столбца на пересечении минимального элемента");
PrintTwoDimArray(matrixCrossDell, "  ");

int[,] CreateTwoDimArray()
{
    Console.Write($"Введиет размеры двумерного массива через пробел -> ");
    string[] sizes = Console.ReadLine().Split(" ");
    int rows = Convert.ToInt32(sizes[0]);
    int colomns = Convert.ToInt32(sizes[1]);
    int[,] tdArray = new int[rows, colomns];
    return tdArray;
}

void FillTwoDimArrayRandomElements(int[,] twodimArray, int minValue, int maxValue)
{
    Random rand = new Random();
    for (int i = 0; i < twodimArray.GetLength(0); i++)
    {
        for (int j = 0; j < twodimArray.GetLength(1); j++)
        {
            twodimArray[i, j] = rand.Next(minValue, maxValue + 1);
        }
    }

}

void PrintTwoDimArray(int[,] twodimArray, string separator)
{
    for (int i = 0; i < twodimArray.GetLength(0); i++)
    {
        for (int j = 0; j < twodimArray.GetLength(1); j++)
        {
            Console.Write($"{twodimArray[i, j]}");
            if (j == twodimArray.GetLength(1) - 1) break;
            Console.Write(separator);
        }
        Console.WriteLine();
    }
}

int[] arrayIndices(int[,] matrix)
{
    int[] arrIndex = new int[2];
    int minElement = matrix[0,0];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (minElement > matrix[i, j])
            {
                minElement = matrix[i, j];
                arrIndex[0] = i;
                arrIndex[1] = j;
            }
        }
    }
    return arrIndex;
}

int[,] TDArrayArterCrossDel(int[,] sourceMatrix, int indexMinRow, int indexMinColomn)
{
    int[,] matrixCrossDel = new int[sourceMatrix.GetLength(0) - 1, sourceMatrix.GetLength(1) - 1];

    for (int i = 0, row = 0; i < sourceMatrix.GetLength(0); row++, i++)
    {
        if (indexMinRow == i)
        {
            row--;
            continue;
        }

        for (int j = 0, colomn = 0; j < sourceMatrix.GetLength(1); colomn++, j++)
        {
            if (indexMinColomn == j)
            {
                colomn--;
                continue;
            }
            matrixCrossDel[row, colomn] = sourceMatrix[i, j];
        }
    }
    return matrixCrossDel;
}