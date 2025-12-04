using System.Diagnostics;
using Timer = System.Timers.Timer;

var stopwatch = Stopwatch.StartNew();

AOC_2025.Day3Solution.part2.main();

stopwatch.Stop();

Console.WriteLine($"\n program took {stopwatch.ElapsedMilliseconds} milliseconds");