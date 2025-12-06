using System.Text;

namespace AOC_2025;

public static class Day4Solution
{
    public static class part1
    {
        public static string[] file;

        public const int width = 136;
        public const int height = 136;
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day4/source.txt", Encoding.UTF8);

            file = stream.ReadToEnd().Split('\n');

            int total = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    if (file[y][x] == '.') continue;

                    if (isAccessible(x, y)) total++;
                }
            }
            
            Console.WriteLine($"\ntotal accessible rolls of paper: {total}");
        }

        public static bool isAccessible(int x, int y)
        {
            List<(int, int)> neighbours = new ();

            bool left, top, right, bottom;
            left = top = right = bottom = true;
            
            switch (x)
            {
               case 0:
                   // left edge
                   switch (y)
                   {
                       case 0:
                           // top left corner
                           left = false;
                           top = false;
                           break;
                       default:
                           // left edge
                           left = false;
                           break;
                       case height - 1:
                           // bottom left corner
                           left = false;
                           bottom = false;
                           break;
                   }
                   break;
               default:
                   // not against any edge
                   switch (y)
                   {
                       case 0:
                           // top edge
                           top = false;
                           break;
                       case height - 1:
                           // bottom edge
                           bottom = false;
                           break;
                   }
                   break;
               case width - 1:
                   // right edge
                   switch (y)
                   {
                       case 0:
                           // top right corner
                           top = false;
                           right = false;
                           break;
                       default:
                           // right edge
                           right = false;
                           break;
                       case height - 1:
                           // bottom right corner
                           right = false;
                           bottom = false;
                           break;
                   }
                   break;
            }
            
            if (top && left) neighbours.Add((x - 1, y - 1));
            if (top && right) neighbours.Add((x + 1, y - 1));
            if (bottom && right) neighbours.Add((x + 1, y + 1));
            if (bottom && left) neighbours.Add((x - 1, y + 1));
            if (left) neighbours.Add((x - 1, y));
            if (top) neighbours.Add((x, y - 1));
            if (right) neighbours.Add((x + 1, y));
            if (bottom) neighbours.Add((x, y + 1));

            int inaccessibleNeighbours = 0;

            foreach (var neighbour in neighbours)
            {
                if (file[neighbour.Item2][neighbour.Item1] == '@')
                {
                    inaccessibleNeighbours++;
                }
            }

            return inaccessibleNeighbours < 4;
        }
    }

    public static class part2
    {
        public static string[] file;

        public const int width = 136;
        public const int height = 136;
        public static void main()
        {
            StreamReader stream = new StreamReader(global.Path + "/Day4/source.txt", Encoding.UTF8);

            file = stream.ReadToEnd().Split('\n');

            int recursions = 0;
            
            int total = 0;

            int removed = int.MaxValue;
            while (removed != 0)
            {
                removed = removePaperRolls();
                total += removed;
                recursions++;
            }
            
            Console.WriteLine($"\ntotal accessible rolls of paper: {total}, this took {recursions} recursions");
        }

        public static int removePaperRolls()
        {
            int removed = 0;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    if (file[y][x] == '.') continue;

                    if (isAccessible(x, y))
                    {
                        removed++;
                        file[y] = setIndex(file[y], x, '.');
                    }
                    
                }
            }

            return removed;
        }

        public static string setIndex(string str, int index, char c)
        {
            return (index > 0 ? str.Substring(0, index) : "") + c + (index < str.Length - 1 ? str.Substring(index + 1, str.Length - index - 1) : "");
        }

        public static bool isAccessible(int x, int y)
        {
            List<(int, int)> neighbours = new ();

            bool left, top, right, bottom;
            left = top = right = bottom = true;
            
            switch (x)
            {
               case 0:
                   // left edge
                   switch (y)
                   {
                       case 0:
                           // top left corner
                           left = false;
                           top = false;
                           break;
                       default:
                           // left edge
                           left = false;
                           break;
                       case height - 1:
                           // bottom left corner
                           left = false;
                           bottom = false;
                           break;
                   }
                   break;
               default:
                   // not against any edge
                   switch (y)
                   {
                       case 0:
                           // top edge
                           top = false;
                           break;
                       case height - 1:
                           // bottom edge
                           bottom = false;
                           break;
                   }
                   break;
               case width - 1:
                   // right edge
                   switch (y)
                   {
                       case 0:
                           // top right corner
                           top = false;
                           right = false;
                           break;
                       default:
                           // right edge
                           right = false;
                           break;
                       case height - 1:
                           // bottom right corner
                           right = false;
                           bottom = false;
                           break;
                   }
                   break;
            }
            
            if (top && left) neighbours.Add((x - 1, y - 1));
            if (top && right) neighbours.Add((x + 1, y - 1));
            if (bottom && right) neighbours.Add((x + 1, y + 1));
            if (bottom && left) neighbours.Add((x - 1, y + 1));
            if (left) neighbours.Add((x - 1, y));
            if (top) neighbours.Add((x, y - 1));
            if (right) neighbours.Add((x + 1, y));
            if (bottom) neighbours.Add((x, y + 1));

            int inaccessibleNeighbours = 0;

            foreach (var neighbour in neighbours)
            {
                if (file[neighbour.Item2][neighbour.Item1] == '@')
                {
                    inaccessibleNeighbours++;
                }
            }

            return inaccessibleNeighbours < 4;
        }
    }
}