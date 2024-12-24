using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace AdventOfCode24.Lib.Day3;

public class MulInstructions(string[] inputContent)
{
    private string[] InputContent { get; set; } = inputContent;
    private const string PatternForFindingDo = @"do\(\)(.*?)(?=don't\(\)|$)";
    private const string PatternForExtractingMulNumber = @"mul\(\d+,\d+\)";

    private List<string> _instructions = [];

    public int CalculateMultiplications()
    {
        // TODO: To revisit this and handle the below hardcoded regex segment
        // Extract Mul keyword
        var instructionsGroup = ScanInput();
        instructionsGroup.Add("},;who()^>',mul(594,203)~  ~*$'*select()mul(693,99)*>&()+{%{mul(225,584)when()why()#]}&mul(287,918)<from(332,448)<^:mul(296,804)'@why()'when()");
        var total = 0;
        var groupIndex = 1;
        foreach (var group in instructionsGroup)
        {
            Console.WriteLine($"Group: {group} with Index {groupIndex}");
            var instruction = Matches(group, PatternForExtractingMulNumber).Select(m => m.Value).ToArray();
            var numberIndex = 1;
            foreach (var numbers in instruction)
            {
                Console.WriteLine($"Numbers: {numbers} with Index {numberIndex}");
                total += ExtractNumbers(numbers).Aggregate((x, y) => x * y);
                Console.WriteLine($"Total: {total}");
                numberIndex++;
            }
            
            groupIndex++;
        }
        
        return total;
    }

    private static int ParseNumber(Match m) => int.Parse(m.Value);
    private List<string> ScanInput() => Matches(string.Join("", InputContent), PatternForFindingDo).Select(m => m.Value).ToList();
    private int[] ExtractNumbers(string input) => Matches(input, @"\d{1,3}").Select(ParseNumber).ToArray();
}