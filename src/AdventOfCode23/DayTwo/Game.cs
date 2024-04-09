
namespace AdventOfCode23.DayTwo;

public record Game
{
    public int GameID {  get; set; }
    public List<Turn> Turns { get; set; } = default!;
}

public record Turn
{
    public int Blue {  get; set; }
    public int Green { get; set; }
    public int Red { get; set; }
}

public enum BlockColors
{
    blue,
    green,
    red,
}