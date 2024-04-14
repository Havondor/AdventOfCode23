
using AdventOfCode23.Utils;

namespace AdventOfCode23.DayTwo;

public static class FileProcessor
{
    public static List<Game> GetGames(string FileName)
    {
        List<string> gameStrings = FileManagement.ConvertInputFileToStringList(FileName);
        List<Game> games = [];

        foreach (string gameString in gameStrings)
        {
            games.Add(ProcessGameString(gameString));
        }

        return games;
    }

    private static Game ProcessGameString(string gameString)
    {
        var token = gameString.Split(':');
        var gameHead = token[0].Split(' ');

        return new()
        {
            GameID = int.Parse(gameHead[1]),
            Turns = ProcessTurns(token[1]),
        };
    }

    private static List<Turn> ProcessTurns(string turnString) 
    {
        List<Turn> turns = [];

        foreach (var turn in turnString.Split(';'))
        {
            int blue = 0;
            int green = 0;
            int red = 0;

            foreach (var block in turn.Split(','))
            {
                var splitBlock = block.Trim().Split(' ');
                switch (splitBlock[1])
                {
                    case nameof(BlockColors.blue):
                        blue = int.Parse(splitBlock[0]);
                        break;
                    case nameof(BlockColors.green):
                        green = int.Parse(splitBlock[0]);
                        break;
                    case nameof(BlockColors.red):
                        red = int.Parse(splitBlock[0]);
                        break;
                    default: 
                        break;
                }
            }

            turns.Add(new()
            {
                Blue = blue,
                Green = green,
                Red = red,
            });
        }

        return turns;
    }

    
}
