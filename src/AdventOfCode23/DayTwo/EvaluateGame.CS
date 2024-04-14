

namespace AdventOfCode23.DayTwo;
public class EvaluateGame(List<Game> games)
{
    private readonly List<Game> _games = games;

    public List<int> GetValidGameIDs(int maxBlue, int maxGreen, int maxRed)
    {
        List<int> validGameIDs = [];


        foreach (Game game in _games)
        {
            if (game.MaxBlue <= maxBlue && game.MaxGreen <= maxGreen && game.MaxRed <= maxRed)
            {
                validGameIDs.Add(game.GameID);
            }               
        }

        return validGameIDs;

    }

    public List<int> GetGamePowers()
    {
        List<int> gamePowers = [];

        foreach (Game game in _games) 
        {
            gamePowers.Add(game.Power);
        }

        return gamePowers;
    }
}
