using AdventOfCode24.Lib.Shared;

namespace AdventOfCode24.Lib.Day2;

public class ReportValidator
{
    private int unsafeReports = 0;
    private int safeReports = 0;

    public string Validate()
    {
        var reports = Common.ReadInputFile(InputFilePath);

        // Logic for Determining Safe Unsafe
        // Condition is to check Levels increasing by 1 OR all increasing or decreasing
        foreach (var report in reports)
        {
            var levels = report.Split(" ");

            if (CheckAllSequence(levels) && CheckAdjacentValues(levels))
                safeReports++;
            else
                unsafeReports++;
        }

        return $"Total safe reports: {safeReports} | Total unsafe reports: {unsafeReports}";
    }

    private bool CheckAllSequence(string[] levels)
    {
        // Check if all increasing
        var increasingLevel = 0;
        var decreasingLevel = levels.Max(int.Parse) + 1;
        var isIncreasingOrder = true;
        var isDecreasingOrder = true;
        
        foreach (var level in levels)
        {
            var current = int.Parse(level);
            if (isIncreasingOrder)
                // Check for increasing order
                if (current > increasingLevel)
                    increasingLevel = current;
                else
                    isIncreasingOrder = false;
            if (!isDecreasingOrder) continue;
            // Check for increasing order
            if (current < decreasingLevel)
                decreasingLevel = current;
            else
                isDecreasingOrder = false;
        }
        
        // Check either is true
        return isIncreasingOrder || isDecreasingOrder;
    }

    private bool CheckAdjacentValues(string[] levels)
    {
        var isValidAdjacentValues = true;
        for (int i = 0; i < levels.Length - 1; i++)
        {
            if (!isValidAdjacentValues)
                break;
            if (!CompareAdjacentValues(int.Parse(levels[i]), int.Parse(levels[i + 1])))
                isValidAdjacentValues = false;
        }
        
        return isValidAdjacentValues;
    }

    private bool CompareAdjacentValues(int current, int next) => Math.Abs(current - next) is > 0 and < 4;
    
    public string? InputFilePath { get; set; }
}

enum ReportOutcome
{
    Safe,
    Unsafe
}