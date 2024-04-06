using System.Text.RegularExpressions;

namespace AdventOfCode23.DayOne;

public static class DayOne
{
    private static readonly string _fileName = @"Input\Day1Input.txt";

    public static int PartOne()
    {
        return ReduceListToDigits([.. ReadInputFile().Values]).Sum();
    }

    public static int PartTwo()
    {
        Dictionary<int, string> calibrationValues = ReadInputFile();

        SwapAlphaToDigit<DigitNameCombos>(calibrationValues);
        SwapAlphaToDigit<DigitName>(calibrationValues);

        return ReduceListToDigits([.. calibrationValues.Values]).Sum();
    }

    private static List<int> ReduceListToDigits(List<string> OGList)
    {
        string pattern = @"([a-zA-Z])";
        string substitution = @"";

        Regex regex = new(pattern);

        return OGList.Select(x => regex.Replace(x, substitution))
                     .Select(s => int.Parse(string.Concat(s.First(), s.Last()))).ToList();
    }

    private static void SwapAlphaToDigit<T>(Dictionary<int, string> keyValuePairs) where T : Enum
    {
        foreach (var digit in Enum.GetValues(typeof(T)))
        {
            foreach (var cv in keyValuePairs.Where(x => x.Value.Contains(digit.ToString()!)))
            {
                keyValuePairs[cv.Key] = cv.Value.Replace(digit.ToString()!, ((int)digit).ToString());
            }
        }
    }

    private static Dictionary<int, string> ReadInputFile()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string combinedFileName = Path.Combine(currentDirectory, _fileName);
        string filePath = Path.GetFullPath(combinedFileName);

        return File.ReadAllLines(filePath)
                   .Select((v, k) => new { Key = k, Value = v })
                   .ToDictionary(o => o.Key, o => o.Value);
    }
}
