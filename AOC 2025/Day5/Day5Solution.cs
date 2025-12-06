using System.Text;

namespace AOC_2025;

public static class Day5Solution
{
    public static class part1
    {
        public static List<range> ranges = new();
        
        public static void main()
        {
            long freshIngredients = 0;
            
            StreamReader stream = new StreamReader(global.Path + "/Day5/source.txt", Encoding.UTF8);

            string line = stream.ReadLine();
            while (line != "")
            {
                addRange(new range(line));
                line = stream.ReadLine();
            }

            line = stream.ReadLine();
            
            while (line != null)
            {
                if (inRange(long.Parse(line))) freshIngredients++;
                
                line = stream.ReadLine();
            }

            Console.WriteLine($"total fresh ingredients: {freshIngredients}");
        }

        // makes sure the ranges' start id is in order for linear search
        public static void addRange(range range)
        {
            int i = 0;
            while (i < ranges.Count && ranges[i].start <= range.start)
            {
                i++;
            }
            
            ranges.Insert(i, range);
        }

        public static bool inRange(long id)
        {
            int i = 0;
            while (i < ranges.Count && ranges[i].end < id)
            {
                i++;
            }

            while (i < ranges.Count && ranges[i].start <= id)
            {
                if (ranges[i].inRange(id)) return true;
                i++;
            }

            return false;
        }

        public struct range
        {
            public long start { get; set; }
            public long end { get; set; }

            public range(string str)
            {
                int i = 0;
                string phrase = "";
                while (str[i] != '-')
                {
                    phrase += str[i];
                    i++;
                }

                start = long.Parse(phrase);

                i++;
                phrase = "";
                while (i < str.Length)
                {
                    phrase += str[i];
                    i++;
                }

                end = long.Parse(phrase);
            }

            public bool inRange(long num)
            {
                return start <= num && num <= end;
            }
        }
    }

    public static class part2
    {
        public static List<range> ranges = new();

        // broken as of now
        public static void main()
        {
            long totalIndices = 0;
            
            StreamReader stream = new StreamReader(global.Path + "/Day5/source.txt", Encoding.UTF8);

            string line = stream.ReadLine();
            while (line != "")
            {
                addRange(new range(line));
                line = stream.ReadLine();
            }

            int rangesRemoved = int.MaxValue;
            while (rangesRemoved > 0)
            {
                rangesRemoved = pass();
            }

            foreach (var range in ranges)
            {
                totalIndices += range.end - range.start + 1;
            }
            
            Console.WriteLine($"\ntotal indices: {totalIndices}");
        }

        public static int pass()
        {
            foreach (var range in ranges)
            {
                Console.WriteLine($"range {range.start}-{range.end}");
            }
            
            int removed = 0;
            
            for (int i = 0; i < ranges.Count - 1; i++)
            {
                if (ranges[i].end >= ranges[i + 1].start)
                {
                    ranges[i+1].start = ranges[i].start;

                    Console.WriteLine($"\tremoving index {i}");
                    ranges.RemoveAt(i);
                    removed++;
                }
            }
            
            Console.WriteLine("");

            return removed;
        }
        
        public static void addRange(range range)
        {
            int i = 0;
            while (i < ranges.Count && ranges[i].start <= range.start)
            {
                i++;
            }
            
            ranges.Insert(i, range);
        }

        public class range
        {
            public long start { get; set; }
            public long end { get; set; }

            public range(string str)
            {
                int i = 0;
                string phrase = "";
                while (str[i] != '-')
                {
                    phrase += str[i];
                    i++;
                }

                start = long.Parse(phrase);

                i++;
                phrase = "";
                while (i < str.Length)
                {
                    phrase += str[i];
                    i++;
                }

                end = long.Parse(phrase);
            }

            public bool inRange(long num)
            {
                return start <= num && num <= end;
            }
        }
    }
}