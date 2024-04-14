
using AdventOfCode23.Utils;
using System.Reflection;

namespace AdventOfCode23.DayThree;

public static class DayThree
{
    private const string _fileName = @"Input\Day3Input.txt";

    public static int PartOne()
    {
        char[,] schematic = FileManagement.ConvertInputTo2DArray(_fileName);

        ProcessSchematic processor = new(schematic);

        Console.WriteLine(processor.GetLength());

        return 1;
    }
}
