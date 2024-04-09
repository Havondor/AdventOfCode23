

namespace AdventOfCode23.Utils;

public static class FileManagement
{
    public static List<string> ReadInputFile(string FileName)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string combinedFileName = Path.Combine(currentDirectory, FileName);
        string filePath = Path.GetFullPath(combinedFileName);

        return [.. File.ReadAllLines(filePath)];
    }
}
