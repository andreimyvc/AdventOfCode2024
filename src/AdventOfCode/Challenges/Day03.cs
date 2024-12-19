using System.Linq;

namespace Day01.Challenges;
public partial class Challege
{
    public static void Day03()
    {
        var data = File.ReadAllText("inputs/day03.txt");

        Console.WriteLine($"Parte 1: {Part1(data)}");

        Console.WriteLine($"Parte 2: {Part2(data)}");
        Console.ReadLine();


        int Part1(string data)
        {
            var lista = Parser(data);
            return lista.Select(p => p.Split(',')).Select(p => int.Parse(p[0]) * int.Parse(p[1])).Sum();            
        }

        int Part2(string data)
        {
            var lista = Parser2(data);
            return lista.Select(p => p.Split(',')).Select(p => int.Parse(p[0]) * int.Parse(p[1])).Sum();
        }

        List<string> Parser(string data)
        {
            List<string> result = new();
            string temp = string.Empty;
            bool flag = false;

            int i = 0;

            while(i < data.Length)
            {

                if ((i + 3) < data.Length && $"{data[i]}{data[i + 1]}{data[i + 2]}{data[i + 3]}" == "mul(")
                {
                    flag = true;
                    
                    i += 4;

                    temp = string.Empty;
                }


                char c = data[i];

                if (flag)
                {

                    if (char.IsDigit(c) || c == ',')
                    {
                        temp += c;
                    }
                    else
                    {
                        flag = false;
                    }
                }

                if (c == ')' || temp.Length > 7)
                {
                    if (!string.IsNullOrWhiteSpace(temp) && temp.Length <= 7 && temp.Contains(','))
                    {
                        result.Add(temp);
                    }
                }
                
                if (!flag)
                {
                    temp = string.Empty;
                }

                i++;
            }

            return result;
        }

        List<string> Parser2(string data)
        {
            List<string> result = new();
            string temp = string.Empty;
            bool flag = false;
            bool enable = true;
            int i = 0;

            while (i < data.Length)
            {

                if ((i + 4) < data.Length && data.Substring(i, 4) == "mul(")
                {
                    flag = true;

                    i += 4;

                    temp = string.Empty;
                }

                if ((i + 7) < data.Length && data.Substring(i, 7) == "don't()")
                {
                    enable = false;
                    i += 7;
                }

                if ((i + 4) < data.Length && data.Substring(i, 4) == "do()")
                {
                    enable = true;
                    i += 4;
                    continue;
                }

                char c = data[i];

                if (flag)
                {
                    if (enable && c == ')' && temp.Length <= 7 && temp.Contains(','))
                    {
                        result.Add(temp);
                    }

                    if (char.IsDigit(c) || c == ',')
                    {
                        temp += c;
                    }
                    else
                    {
                        flag = false;
                    }
                } 
                else
                {
                    temp = string.Empty;
                }

                i++;
            }

            return result;
        }
    }
}