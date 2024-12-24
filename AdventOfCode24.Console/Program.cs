using AdventOfCode24.Lib.Day1;
using AdventOfCode24.Lib.Day2;
using AdventOfCode24.Lib.Day3;
using AdventOfCode24.Lib.Shared;

#region Day 1
// var lr = new Location();
// lr.InputFilePath = @"C:\Users\kevin\RiderProjects\AdventOfCode24\AdventOfCode24.Lib\Day1\Input.txt";
// Console.WriteLine(lr.Reconcile());
// Console.WriteLine(lr.GetSimilarityScore());
// Console.ReadKey();
// lr.Clear();
// lr.InputFilePath = @"C:\Users\kevin\RiderProjects\AdventOfCode24\AdventOfCode24.Lib\Day1\Input_Reverse.txt";
// Console.WriteLine(lr.Reconcile());
// Console.WriteLine(lr.GetSimilarityScore());
// Console.ReadKey();
#endregion

#region Day 2
// var rv = new ReportValidator();
// rv.InputFilePath = @"C:\Users\kevin\RiderProjects\AdventOfCode24\AdventOfCode24.Lib\Day2\Input.txt";
// Console.WriteLine(rv.ValidateReport());
#endregion

#region Day 3

var MI = new MulInstructions(Common.ReadInputFile(@"C:\Users\kevin\RiderProjects\AdventOfCode24\AdventOfCode24.Lib\Day3\Input.txt"));

Console.WriteLine(MI.CalculateMultiplications());
Console.ReadKey();
#endregion

