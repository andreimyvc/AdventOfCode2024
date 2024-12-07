namespace Day01.Challenges;
public partial class Challege
{
    public static void Day02()
    {
        var lines = File.ReadAllLines("inputs/day02.txt")
            .Select(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)) .ToArray())
            .ToArray();

        int count = 0;

        foreach (var line in lines)
        {
            if (IsSafe(line))
            {
                count++;
            }

        }

        Console.WriteLine("Parte 1: {0}", count);

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
    }
}
