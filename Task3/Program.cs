// Задача 3: Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.
// Пример
// 4 3 1 => Строка с индексом 0
// 2 6 9
// 4 6 2 

int[,] mytdArray = CreateTwoDimArray();
FillTwoDimArrayRandomElements(mytdArray, 1, 9);
PrintTwoDimArray(mytdArray, "  ");

Console.WriteLine($"Строка с минимальной суммой элементов c {IndexMinSumElemInRow(mytdArray)} индексом");

int[,] CreateTwoDimArray()
{
    Console.Write($"Введиет размеры двумерного массива через пробел -> ");
    string[] sizes = Console.ReadLine().Split(" ");
    int row = Convert.ToInt32(sizes[0]);
    int colomn = Convert.ToInt32(sizes[1]);
    int[,] tdArray = new int[row, colomn];
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
        Console.Write($"Индекс строки -> {i} <-\t");
        for (int j = 0; j < twodimArray.GetLength(1); j++)
        {
            Console.Write($"{twodimArray[i, j]}");
            if (j == twodimArray.GetLength(1) - 1) break;
            Console.Write(separator);
        }
        Console.WriteLine();
    }
}

int IndexMinSumElemInRow(int[,] twoDimArray)
{
    int indexRowWithMinSum = 0;
    int minSumElementsInRow = int.MaxValue;

    for (int i = 0; i < twoDimArray.GetLength(0); i++)
    {
        int sumElementsInRow = 0;
        for (int j = 0; j < twoDimArray.GetLength(1); j++)
        {
            sumElementsInRow += twoDimArray[i, j];
        }
       
        if (minSumElementsInRow > sumElementsInRow)
        {
            minSumElementsInRow = sumElementsInRow;
            indexRowWithMinSum = i;
        }
    }
    return indexRowWithMinSum;
}