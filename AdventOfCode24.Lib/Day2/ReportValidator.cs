using AdventOfCode24.Lib.Shared;

namespace AdventOfCode24.Lib.Day2;

public class ReportValidator
{
    private int unsafeReports = 0;
    private int safeReports = 0;

    public string ValidateReport()
    {
        var reports = Common.ReadInputFile(InputFilePath);
        // Logic for Determining Safe Unsafe
        // Condition is to check Levels increasing by 1 OR all increasing or decreasing
        foreach (var report in reports)
        {
            var dampenedReportValid = false;
            var levels = report.Split(" ").Select(int.Parse).ToArray();

            if (ValidateLevels(levels, out var problemLevelIndex))
            {
                safeReports++;
            }
            else {
                for (var i = 0; i < levels.Length; i++)
                {
                    var dampenedLevels = levels.ToList();
                    dampenedLevels.RemoveAt(i);
                    if (!ValidateLevels(dampenedLevels.ToArray(), out problemLevelIndex)) continue;
                    safeReports++;
                    dampenedReportValid = true;
                    break;
                }

                if(!dampenedReportValid)
                    unsafeReports++;
            }
        }
        return $"Total safe reports: {safeReports} | Total unsafe reports: {unsafeReports}";
    }

    private bool ValidateLevels(int[] levels, out int problemLevelIndex)
    {
        if (!CheckAllSequence(levels, out problemLevelIndex))
            return false;
        if (!CheckAdjacentValues(levels, out problemLevelIndex))
            return false;

        return true;
    }

    private int[] ApplyDampener(List<int> levels, int indexToRemove)
    {
        if (indexToRemove != -1)
            levels.RemoveAt(indexToRemove);
        return levels.ToArray();
    } 

    private bool CheckAllSequence(int[] levels, out int problemLevelIndex)
    {
        // Check if all increasing
        var increasingLevel = 0;
        var decreasingLevel = levels.Max() + 1;
        var isIncreasingOrder = true;
        var isDecreasingOrder = true;
        problemLevelIndex = -1;

        for (var i = 0; i < levels.Length; i++)
        {
            if (isIncreasingOrder)
                // Check for increasing order
                if (levels[i] > increasingLevel)
                    increasingLevel = levels[i];
                else
                {
                    isIncreasingOrder = false;
                    problemLevelIndex = i;
                }
            if (!isDecreasingOrder) continue;
            // Check for increasing order
            if (levels[i] < decreasingLevel)
                decreasingLevel = levels[i];
            else
            {
                isDecreasingOrder = false;
                problemLevelIndex = i;
            }
        }
        
        var isValidOrder = isIncreasingOrder || isDecreasingOrder;
        if (isValidOrder)
            problemLevelIndex = -1;
        
        // Check either is true
        return isValidOrder;
    }

    private bool CheckAdjacentValues(int[] levels, out int problemLevelIndex)
    {
        var isValidAdjacentValues = true;
        problemLevelIndex = -1;
        for (int i = 0; i < levels.Length - 1; i++)
        {
            if (!isValidAdjacentValues)
                break;
            if (!CompareAdjacentValues(levels[i], levels[i + 1]))
            {
                isValidAdjacentValues = false;
                problemLevelIndex = i + 1;
                break;
            }
        }
        
        return isValidAdjacentValues;
    }

    private bool CompareAdjacentValues(int current, int next) => Math.Abs(current - next) is > 0 and < 4;
    
    public string? InputFilePath { get; set; }
}
