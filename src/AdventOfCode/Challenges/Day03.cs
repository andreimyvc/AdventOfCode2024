using System.Linq;

namespace Day01.Challenges;
public partial class Challege
{
    public static void Day03()
    {
        var data = File.ReadAllText("inputs/day03.txt");

        Console.WriteLine($"Parte 1: {Part1(data)}");
        Console.ReadLine();

        int Part1(string data)
        {
            var lista = Parser(data);
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
        
    }
}

/*
 
 what(){mul(697,542)/>why(479,94)mul(995,893)why()]%?:]select()%}mul(408,907),{from()$&&/mul(893,282)[#%@(who()what()!~mul(313,566)
 
 */
