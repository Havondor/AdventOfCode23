

namespace AdventOfCode23.DayTwo;

public static class DayTwo
{
    private const string _fileName = @"Input\Day2Input.txt";

    public static int PartOne(int maxBlue, int maxGreen, int maxRed)
    {
        var games = FileProcessor.GetGames(_fileName);

        EvaluateGame evaluateGame = new(games);

        return evaluateGame.GetValidGameIDs(maxBlue, maxGreen, maxRed).Sum();
    }

    public static int PartTwo()
    {
        var games = FileProcessor.GetGames(_fileName);

        EvaluateGame evaluateGame = new(games);

        return evaluateGame.GetGamePowers().Sum();

    }
}
