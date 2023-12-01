// Задача 1: Напишите программу, которая на вход принимает позиции элемента
// в двумерном массиве, и возвращает значение этого элемента или же указание,
// что такого элемента нет.
// Пример
// 4 3 1   (1,2) => 9
// 2 6 9 

int[,] myTDArray = CreateTwoDimArray();
FillTwoDimArrayRandomElements(myTDArray, 1, 100);
ElementPosition(myTDArray);
Console.WriteLine();
PrintTwodimArray(myTDArray, "\t");

int[,] CreateTwoDimArray()
{
    Console.Write($"Введиет размеры двумерного массива через пробел -> ");
    string[] sizes = Console.ReadLine().Split(" ");
    int row = Convert.ToInt32(sizes[0]);
    int colomn = Convert.ToInt32(sizes[1]);
    int[,] TDArray = new int[row, colomn];
    return TDArray;
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

void PrintTwodimArray(int[,] twodimArray, string separator)
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

void ElementPosition(int[,] sourceTDArray)
{
    Console.Write($"Веедите позицию элемента через пробел -> ");
    string[] posElement = Console.ReadLine().Split(" ");
    int row = Convert.ToInt32(posElement[0]);
    int colomn = Convert.ToInt32(posElement[1]);

    if (row > sourceTDArray.GetLength(0) - 1 || row < 0 || colomn > sourceTDArray.GetLength(1) - 1 || colomn < 0)
        Console.WriteLine($"Такой позиции ({row},{colomn}) в массиве нет!");
    else
        Console.WriteLine($"В позиции ({row},{colomn}) находится элемент {sourceTDArray[row, colomn]}");

}