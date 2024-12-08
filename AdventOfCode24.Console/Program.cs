using AdventOfCode24.Lib.Day1;

#region Day 1
const string INPUT_FILE_PATH = @"C:\Users\kevin\RiderProjects\AdventOfCode24\AdventOfCode24.Lib\Day1\Input.txt"; 

var lr = new LocationReconcile(INPUT_FILE_PATH);

var distance = lr.Reconcile();
Console.WriteLine(distance);
Console.ReadKey();
#endregion

