namespace AdventOfCode24.Lib.Shared;

public static class Common
{
    public static string[] ReadInputFile(string inputFilePath) => File.ReadAllLines(inputFilePath ?? string.Empty);
}