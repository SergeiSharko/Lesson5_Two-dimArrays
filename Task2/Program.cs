// Задача 2: Задайте двумерный массив. Напишите программу, которая поменяет местами 
// первую и последнюю строку массива.
// Пример 
// 4 3 1   =>  4 6 2
// 2 6 9       2 6 9
// 4 6 2       4 3 1

int[,] mytdArray = CreateTwoDimArray();
FillTwoDimArrayRandomElements(mytdArray, 1, 9);
int[] rowsChanges = RowForChanges(mytdArray);
Console.WriteLine($"Исходный массив");
PrintTwodimArray(mytdArray, "  ");
Console.WriteLine($"Измененный массив");
ChangesRows(mytdArray, rowsChanges[0], rowsChanges[1]);
PrintTwodimArray(mytdArray, "  ");

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

int[] RowForChanges(int[,] matrix)
{
    while(true)
    {
        int[] rowForChanges = new int[2];
        Console.Write($"Введите строки, которые поменять местами, через пробел -> ");
        string[] rows = Console.ReadLine().Split(" ");
        rowForChanges[0] = Convert.ToInt32(rows[0]);
        rowForChanges[1] = Convert.ToInt32(rows[1]);
    
        if (rowForChanges[0] < matrix.GetLength(0) && rowForChanges[1] < matrix.GetLength(1))
        {
            return rowForChanges;
        }
        else
            Console.WriteLine($"Строки на перестановку введены неверно! Выход за пределы массива!");
    }
}

void ChangesRows(int[,] sourceMatrix, int firstRow, int secondRow)
{
    int tempElement;
    for (int j = 0; j < sourceMatrix.GetLength(1); j++)
    {
        tempElement = sourceMatrix[firstRow, j];
        sourceMatrix[firstRow, j] = sourceMatrix[secondRow, j];
        sourceMatrix[secondRow, j] = tempElement;
    }         
}