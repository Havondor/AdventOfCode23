

namespace AdventOfCode23.Utils;

public static class FileManagement
{
    public static List<string> ConvertInputFileToStringList(string FileName)
    {
        string filePath = GetFilePath(FileName);
        return [.. File.ReadAllLines(filePath)];
    }

    public static char[,] ConvertInputTo2DArray(string FileName)
    {
        string filePath = GetFilePath(FileName);

        string input = File.ReadAllText(filePath);

        string[] rows = input.Split('\n');

        int rowCount = rows.Length - 1;
        int columnCount = 0;

        foreach (var row in rows) 
        { 
            if(row.Length > columnCount)
            {
                columnCount = row.Length;
            }
        }

        int i = 0, j = 0;
        char[,] result = new char[rowCount, columnCount];

        foreach (var row in rows)
        {
            j = 0;

            foreach (var col in row)
            {
                result[i, j] = col;
                j++;
            }
            i++;
        }

        return result;
    }

    private static string GetFilePath(string FileName)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string combinedFileName = Path.Combine(currentDirectory, FileName);
        return Path.GetFullPath(combinedFileName);
    }

    

}
