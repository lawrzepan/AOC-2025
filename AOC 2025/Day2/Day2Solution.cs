using System.Text;

namespace AOC_2025;

public static class Day2Solution
{
    public static class part1
    {
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day2/source.txt", Encoding.UTF8);

            string file = stream.ReadToEnd();

            stream.Close();

            long total = 0;

            int index = 0;
            while (index < file.Length)
            {
                string startID = "";

                while (index < file.Length && file[index] != '-')
                {
                    startID += file[index++];
                }

                index++;

                string endID = "";
                while (index < file.Length && file[index] != ',')
                {
                    endID += file[index++];
                }

                index++;

                for (long ID = long.Parse(startID); ID <= long.Parse(endID); ID++)
                {
                    long? testedID = checkRepetition(ID.ToString());
                    if (testedID != null) total += ID;
                }
            }

            Console.WriteLine($"Total of the invalid ID's was: {total}");
        }

        public static long? checkRepetition(string str)
        {
            if (str.Length % 2 == 1) return null; // if there is only an odd number of characters, string cannot only contain repeated phrases
            if (str.Length == 0) throw new Exception("string  cannot be length 0");

            int halfLength = str.Length / 2;

            string phrase = "";
            for (int letter = 0; letter < halfLength; letter++)
            {
                if (str[letter] != str[letter + halfLength])
                {
                    return null;
                }
                else
                {
                    phrase += str[letter];
                }
            }

            return long.Parse(phrase);
        }
    }

    public static class part2
    {
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day2/source2.txt", Encoding.UTF8);

            string file = stream.ReadToEnd();

            stream.Close();

            long total = 0;

            int index = 0;
            while (index < file.Length)
            {
                string startID = "";

                while (index < file.Length && file[index] != '-')
                {
                    startID += file[index++];
                }

                index++;

                string endID = "";
                while (index < file.Length && file[index] != ',')
                {
                    endID += file[index++];
                }

                index++;

                for (long ID = long.Parse(startID); ID <= long.Parse(endID); ID++)
                {
                    long? testedID = checkRepetition(ID.ToString());
                    if (testedID != null) total += ID;
                }
            }

            Console.WriteLine($"Total of the invalid ID's was: {total}");
        }

        public static long? checkRepetition(string str)
        {
            if (str.Length == 0) throw new Exception("string  cannot be length 0");

            for (int groupSize = 1; groupSize <= (int)Math.Floor(str.Length / 2f); groupSize++)
            {
                if (str.Length % groupSize > 0) continue; // string is not divisible into chunks of size groupSize

                bool notRepeated = false;
                
                int i = 0;
                while (i < str.Length)
                {
                    for (int letter = 0; letter < groupSize; letter++)
                    {
                        if (str[i + letter] != str[letter])
                        {
                            notRepeated = true;
                            break;
                        }
                    }

                    if (notRepeated) break;

                    i += groupSize;
                }

                if (!notRepeated)
                {
                    //Console.WriteLine($"invalid id {str} with group size {groupSize}");
                    return long.Parse(str);
                }
            }

            //Console.WriteLine($"valid id {str}");
            return null;
        }
    }
}