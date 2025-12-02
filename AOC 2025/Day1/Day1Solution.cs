using System.Text;

namespace AOC_2025;

public static class global
{
    public static string Path = "/Users/lawriefoy/Library/CloudStorage/OneDrive-GlowScotland/Computing Science/CS higher/Advent Of Code/AOC 2025/AOC 2025";
}

public static class Day1Solution
{
    private static int numZeros = 0;
    
    public static void main()
    {
        StreamReader stream = new StreamReader(global.Path + "/Day1/source.txt", Encoding.UTF8);

        int total = 50;

        string? line = stream.ReadLine();
        while (line != null)
        {
            total += new Operation(line);

            line = stream.ReadLine();
        }
        
        Console.WriteLine($"The final amount of 0's was: {numZeros}");
    }
    
    public enum direction: byte
    {
        Right,
        Left
    }

    public struct Operation
    {
        public direction Direction;
        public int amount;

        public Operation(string str)
        {
            Direction = str[0] == 'R' ? direction.Right : direction.Left;
            
            amount = int.Parse(str.Substring(1));
        }

        public static int operator +(int left, Operation right)
        {
            if (right.Direction == direction.Left)
            {
                int val = left - right.amount;
                if (val < 0)
                {
                    if (left == 0)
                    {
                        numZeros += (int)Math.Floor(val / -100f);
                        //Console.WriteLine($"Moving left from {left} by {right.amount} to get {val + Math.Ceiling(val / -100f) * 100}({val}), increased zeros by {Math.Floor(val / -100f)}, dont worry though i knew val was 0");
                    }
                    else
                    {
                        numZeros += (int)Math.Floor(val / -100f) + 1;
                        //Console.WriteLine($"Moving left from {left} by {right.amount} to get {val + Math.Ceiling(val / -100f) * 100}({val}), increased zeros by {Math.Floor(val / -100f) + 1}");
                    }
                    
                    val = (int)(val + Math.Ceiling(val / -100f) * 100);
                }
                else if (val == 0)
                {
                    numZeros += 1;
                    //Console.WriteLine($"Moving left from {left} by {right.amount} to get {val}, increased zeros by 1");
                }
                else
                {
                    //Console.WriteLine($"moving left from {left} by {right.amount} to get {val}");
                }
                
                return val;
            }
            else
            {
                // direction is right
                int val = left + right.amount;
                if (val > 99)
                {
                    if (left == 0)
                    {
                        numZeros += (int)Math.Floor(val / 100f);
                        //Console.WriteLine($"Moving right from {left} by {right.amount} to get {val % 100}({val}), increased zeros by {Math.Floor(val / 100f)}");
                    }
                    else
                    {
                        numZeros += (int)Math.Floor(val / 100f);
                        //Console.WriteLine($"Moving right from {left} by {right.amount} to get {val % 100}({val}), increased zeros by {Math.Floor(val / 100f)}");
                    }
                    
                    val = val % 100;
                }
                else if (val == 0)
                {
                    numZeros += 1;
                    //Console.WriteLine($"Moving right from {left} by {right.amount} to get {val}, increased zeros by 1");
                }
                else
                {
                    //Console.WriteLine($"moving right from {left} by {right.amount} to get {val}");
                }

                return val;
            }

        }
    }
}