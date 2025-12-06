using System.Text;

namespace AOC_2025;

public static class Day3Solution
{
    public static class part1
    {
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day3/source.txt", Encoding.UTF8);

            int total = 0;

            var line = stream.ReadLine();

            while (line != null)
            {
                total += getHighestJoltage(line);
                line = stream.ReadLine();
            }
            
            Console.WriteLine($"total joltage: {total}");
        }

        public static int getHighestJoltage(string str)
        {
            if (str.Length == 0) throw new Exception("string was too short :(");
            
            int index1 = 0;
            char max1 = char.MinValue;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] > max1)
                {
                    max1 = str[i];
                    index1 = i;
                }
            }

            int index2 = 0;
            char max2 = char.MinValue;
            for (int i = index1 + 1; i < str.Length; i++)
            {
                if (str[i] > max2)
                {
                    max2 = str[i];
                    index2 = i;
                }
            }

            Console.WriteLine($"the highest joltage in string {str} was {str[index1]}{str[index2]} ({index1} & {index2})");

            return int.Parse(str[index1].ToString() + str[index2]);
        }
    }
    
    public static class part2
    {
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day3/source.txt", Encoding.UTF8);

            long total = 0;

            var line = stream.ReadLine();

            while (line != null)
            {
                total += getHighestJoltage(line);
                line = stream.ReadLine();
            }
            
            Console.WriteLine($"total joltage: {total}");
        }

        public static long getHighestJoltage(string str)
        {
            if (str.Length == 0) throw new Exception("string was too short :(");

            int lowestIndex = -1;
            string joltage = "";
            for (int digit = 11; digit >= 0; digit--)
            {
                lowestIndex = maxAfter(str, lowestIndex + 1, str.Length - digit);
                joltage += str[lowestIndex];
            }
            
            //Console.WriteLine($"the highest joltage in string {str} was {joltage})");

            return long.Parse(joltage);
        }

        public static int maxAfter(string str, int index, int end)
        {
            int maxIndex = 0;
            char max = char.MinValue;
            for (int i = index; i < end; i++)
            {
                if (str[i] > max)
                {
                    max = str[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}