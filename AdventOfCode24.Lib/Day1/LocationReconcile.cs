using AdventOfCode24.Lib.Shared;

namespace AdventOfCode24.Lib.Day1;

public class Location()
{
    public string? InputFilePath { get; set; }
    private readonly List<int> _locationsG1 = [];
    private readonly List<int> _locationsG2 = [];

    /// <summary>
    ///  Reconcile location distances between the finding of both groups
    /// </summary>
    /// <returns>Number representing distance gap</returns>
    /// <exception cref="NotImplementedException"></exception>
    public int Reconcile()
    {
        if (string.IsNullOrEmpty(InputFilePath))
            throw new InvalidOperationException("Input file path is empty");
        if (!File.Exists(InputFilePath))
            throw new FileNotFoundException("Input file not found", InputFilePath);
        
        var input = Common.ReadInputFile(InputFilePath);
        
        if (input == null)
            throw new ArgumentException("Invalid Input string");
        
        ProcessInput(input);

        if ( _locationsG1.Count == 0 || _locationsG2.Count == 0 || _locationsG1.Count != _locationsG2.Count)
            throw new Exception("Group locations is mismatched");
        
        return CalculateDistance();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int GetSimilarityScore() => _locationsG1.Select(g1 =>  g1 * _locationsG2.Count(g2 => g2 == g1)).Sum();
    
    /// <summary>
    ///  Calculates the disparity of each index pair locations between 2 groups
    /// </summary>
    /// <returns>The sum of disparity of locations</returns>
    private int CalculateDistance()
    {
        // Sort both group data
        _locationsG1.Sort();
        _locationsG2.Sort();
        
        // Process each index row - Assumption is that both have the same amount of rows
        return _locationsG1.Select((t, i) => Math.Abs(t - _locationsG2[i])).Sum();
    }
    
    public void Clear()
    {
        _locationsG1.Clear();
        _locationsG2.Clear();
    }

    /// <summary>
    /// Reads the input and splits the 2 column of strings
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="Exception"></exception>
    private void ProcessInput(IEnumerable<string> input)
    {
        var enumerable = input as string[] ?? input.ToArray();
        
        foreach (var i in enumerable)
        {
            var pair = i.Trim().Split("  ");
            
            if (pair.Any(string.IsNullOrWhiteSpace))
                throw new Exception("Missing location ID");
            
            _locationsG1.Add(int.Parse(pair.First()));
            _locationsG2.Add(int.Parse(pair.Last()));
        }
    }
}