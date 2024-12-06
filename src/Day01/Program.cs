var lines = File.ReadAllLines("input.txt");

List<int> l1 = [];
List<int> l2 = [];

foreach (var item in lines)
{
    var arr = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    l1.Add(int.Parse(arr[0]));
    l2.Add(int.Parse(arr[1]));
}

l1.Sort();
l2.Sort();

int sum = 0;

for (int i = 0; i < l1.Count; i++)
{
    sum += Math.Abs(l1[i] - l2[i]);
}

Console.WriteLine("Parte 1: {0}", sum);

sum = 
    (
        from p in l1
        join q in l2 on p equals q
        group q by q
    ).Sum(p => p.Key * p.Count());

Console.WriteLine("Parte 2: {0}", sum);

Console.ReadLine();