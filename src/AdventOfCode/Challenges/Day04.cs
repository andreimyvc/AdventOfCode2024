using System.Linq;

namespace Day01.Challenges;
public partial class Challege
{
    public static void Day04()
    {
        var data = File.ReadAllLines("inputs/day04.txt");

        Console.WriteLine($"Parte 1: {Part1(data)}");

        Console.WriteLine($"Parte 2: {Part2(data)}");

        Console.ReadLine();


        int Part1(string[] data)
        {
            int count = 0;

            for (int y = 0; y < data.Length; y++)
            {
                string line = data[y];

                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == 'X')
                    {
                        //Izquierda
                        if (x - 3 >= 0 && $"{line[x]}{line[x - 1]}{line[x - 2]}{line[x - 3]}" == "XMAS")
                        {
                            count++;
                        }

                        //Derecha
                        if (x + 3 < line.Length && $"{line[x]}{line[x + 1]}{line[x + 2]}{line[x + 3]}" == "XMAS")
                        {
                            count++;
                        }


                        //Up
                        if (y - 3 >= 0 &&  $"{line[x]}{data[y - 1][x]}{data[y - 2][x]}{data[y - 3][x]}" == "XMAS")
                        {
                            count++;
                        }

                        //Down
                        if (y + 3 < line.Length && $"{line[x]}{data[y + 1][x]}{data[y + 2][x]}{data[y + 3][x]}" == "XMAS")
                        {
                            count++;
                        }


                        //Diagonal Up Izquierda
                        if (y - 3 >= 0 && x - 3 >= 0 && $"{line[x]}{data[y - 1][x - 1]}{data[y - 2][x - 2]}{data[y - 3][x - 3]}" == "XMAS")
                        {
                            count++;
                        }

                        //Diagonal Up Derecha
                        if (y - 3 >= 0 && x + 3 < line.Length && $"{line[x]}{data[y - 1][x + 1]}{data[y - 2][x + 2]}{data[y - 3][x + 3]}" == "XMAS")
                        {
                            count++;
                        }

                        //Diagonal Down Izquierda
                        if (y + 3 < data.Length && x - 3 >= 0 && $"{line[x]}{data[y + 1][x - 1]}{data[y + 2][x - 2]}{data[y + 3][x - 3]}" == "XMAS")
                        {
                            count++;
                        }

                        //Diagonal Down Derecha
                        if (y + 3 < data.Length && x + 3 < line.Length && $"{line[x]}{data[y + 1][x + 1]}{data[y + 2][x + 2]}{data[y + 3][x + 3]}" == "XMAS")
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        int Part2(string[] data)
        {
            int count = 0;

            for (int y = 0; y < data.Length; y++)
            {
                string line = data[y];

                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == 'A' && y - 1 >= 0 && x - 1 >= 0 && y + 1 < data.Length && x + 1 < line.Length)
                    {
                        if (data[y - 1][x - 1] == 'S' && data[y - 1][x + 1] == 'S' && data[y + 1][x - 1] == 'M' && data[y + 1][x + 1] == 'M')
                        {
                            count++;
                        }
                        else if (data[y - 1][x - 1] == 'M' && data[y - 1][x + 1] == 'M' && data[y + 1][x - 1] == 'S' && data[y + 1][x + 1] == 'S')
                        {
                            count++;
                        }
                        else if (data[y - 1][x - 1] == 'S' && data[y - 1][x + 1] == 'M' && data[y + 1][x - 1] == 'S' && data[y + 1][x + 1] == 'M')
                        {
                            count++;
                        }
                        else if (data[y - 1][x - 1] == 'M' && data[y - 1][x + 1] == 'S' && data[y + 1][x - 1] == 'M' && data[y + 1][x + 1] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}