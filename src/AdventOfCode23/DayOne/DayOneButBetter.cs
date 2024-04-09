using AdventOfCode23.Utils;
using System.Text.RegularExpressions;

namespace AdventOfCode23.DayOne;

public static class DayOneButBetter
{
    private static readonly string _fileName = @"Input\Day1Input.txt";

    public static int PartOne()
    {
        string pattern = @"(?=([1-9]))";
        List<string> calibrationValues = FileManagement.ReadInputFile(_fileName);
        return TransformCalibrationValues(calibrationValues, pattern).Sum();
    }

    public static int PartTwo()
    {
        List<string> calibrationValues = FileManagement.ReadInputFile(_fileName);
        string pattern = "(?=([1-9]|one|two|three|four|five|six|seven|eight|nine))";
        return TransformCalibrationValues(calibrationValues, pattern).Sum();
    }

    private static List<int> TransformCalibrationValues(List<string> calibrationValues, string pattern)
    {
        Regex regex = new(pattern);
        List<int> result = [];

        foreach (var calibrationValue in calibrationValues)
        {
            List<int> values = [];
            foreach (Match token in regex.Matches(calibrationValue).Cast<Match>())
            {
                values.Add(EvaluateToken(token.Groups[1].Value));
            }

            result.Add(int.Parse(string.Concat(values.First().ToString(),values.Last().ToString())));

        }

        return result;
    }

    private static int EvaluateToken(string token) => token switch
    {
        "1" or "one" => 1,
        "2" or "two" => 2,
        "3" or "three" => 3,
        "4" or "four" => 4,
        "5" or "five" => 5,
        "6" or "six" => 6,
        "7" or "seven" => 7,
        "8" or "eight" => 8,
        "9" or "nine" => 9,
        _ => throw new Exception("Not a Number")
    };

    
}
