using System.Diagnostics;
using Timer = System.Timers.Timer;

var stopwatch = Stopwatch.StartNew();

AOC_2025.Day5Solution.part2.main();

stopwatch.Stop();

//Console.WriteLine(AOC_2025.Day4Solution.part2.setIndex("hello", 2, 'T'));

Console.WriteLine($"\nprogram took {stopwatch.ElapsedMilliseconds} milliseconds");