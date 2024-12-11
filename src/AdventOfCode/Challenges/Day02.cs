using System.Linq;

namespace Day01.Challenges;
public partial class Challege
{
    public static void Day02()
    {
        var lines = File.ReadAllLines("inputs/day02.txt")
            .Select(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)) .ToArray())
            .ToArray();

        var x = lines.Where(p => p[0] == p[1]);

        int count = 0;

        foreach (var line in lines)
        {
            count += IsSafe(line) ? 1 : 0;
        }

        Console.WriteLine("Parte 1: {0}", count);

        count = 0;

        foreach (var line in lines)
        {
            count += IsSafe2(line) ? 1 : 0;
        }

        Console.WriteLine("Parte 2: {0}", count);

        Console.ReadLine();

        bool IsSafe(int[]? line)
        {
            bool increassing = line![0] < line[1];

            for (int i = 0; i < line.Length - 1; i++)
            {
                int current = line[i];
                int next = line[i + 1];

                if (current == next)
                    return false;

                if (Math.Abs(current - next) > 3)
                    return false;

                if (increassing && current > next)
                    return false;

                if(increassing == false && current <  next)
                    return false;
            }

            return true;
        }

        bool IsSafe2(int[]? line)
        {
            var result = IsSafe(line);

            if (result)
                return result;

            for (int i = 0; i < line!.Length; i++)
            {
                result = IsSafe(RemoveElementAt(line, i));

                if (result)
                    return result;
            }

            return false;
        }

        int[] RemoveElementAt(int[]? array, int index)
        {
            int[]? result = new int[array!.Length - 1];
            int j = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != index)
                {
                    result[j] = array[i];
                    j++;
                }
            }

            return result;
        }
    }
}


