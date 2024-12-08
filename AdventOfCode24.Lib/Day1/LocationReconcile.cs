namespace AdventOfCode24.Lib.Day1;

public class LocationReconcile
{
    public LocationReconcile(string inputFilePath)
    {
        _inputFilePath = inputFilePath;
    }

    private readonly string _inputFilePath;
    private List<int> _locationsG1 = [];
    private List<int> _locationsG2 = [];

    /// <summary>
    ///  Reconcile location distances between the finding of both groups
    /// </summary>
    /// <returns>Number representing distance gap</returns>
    /// <exception cref="NotImplementedException"></exception>
    public int Reconcile()
    {
        if (string.IsNullOrEmpty(_inputFilePath))
            throw new InvalidOperationException("Input file path is empty");
        if (!File.Exists(_inputFilePath))
            throw new FileNotFoundException("Input file not found", _inputFilePath);
        
        var input = ReadInputFile();
        
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
    private int CalculateDistance()
    {
        // Sort both group data
        _locationsG1.Sort();
        _locationsG2.Sort();
        
        // Process each index row - Assumption is that both have the same amount of rows
        return _locationsG1.Select((t, i) => Math.Abs(t - _locationsG2[i])).Sum();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="Exception"></exception>
    private void ProcessInput(IEnumerable<string> input)
    {
        var enumerable = input as string[] ?? input.ToArray();
        
        foreach (var i in enumerable)
        {
            var pair = i.Split();
            
            if (string.IsNullOrEmpty(pair.First()) || string.IsNullOrEmpty(pair.Last()))
                throw new Exception("Missing location ID");
            
            _locationsG1.Add(int.Parse(pair.First()));
            _locationsG2.Add(int.Parse(pair.Last()));
        }
    }
    
    private string[] ReadInputFile() => File.ReadAllLines(_inputFilePath);
}