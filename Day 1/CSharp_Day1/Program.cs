static List<int>[] ReadFile(string path)
{
    List<int> listA = [];
    List<int> listB = [];
    try
    {
        string? line;
        StreamReader sr = new(path);

        line = sr.ReadLine();
        while (line != null)
        {
            var data = line.Split(" ");

            listA.Add(int.Parse(data.First()));
            listB.Add(int.Parse(data.Last()));

            line = sr.ReadLine();
        }
    }
    catch (Exception e)
    {
        System.Console.WriteLine(e);
    }

    return [listA, listB];
}

static int CalculateDistance(List<int> listA, List<int> listB)
{
    listA.Sort();
    listB.Sort();

    int result = 0;
    for (int i = 0; i < listA.Count; i++)
    {
        result += Math.Abs(listA[i] - listB[i]);
    }

    return result;
}

static int CalculateSimiliarity(List<int> listA, List<int> listB)
{
    Dictionary<int, int> valueAppearence = [];

    foreach (int key in listA)
    {
        valueAppearence.Add(key, 0);
    }

    foreach (int key in listB)
    {
        if (valueAppearence.ContainsKey(key))
        {
            valueAppearence[key] += 1;
        }
    }

    int result = 0;
    foreach (int key in valueAppearence.Keys)
    {
        result += key * valueAppearence[key];
    }

    return result;
}

var input = ReadFile("/home/enigma/kodingan/project/advent-of-code-2024-code/Day 1/input.txt");
var distance = CalculateDistance(input[0], input[1]);
var similiarity = CalculateSimiliarity(input[0], input[1]);

Console.WriteLine($"Total distance: {distance}");
Console.WriteLine($"Total similiarity: {similiarity}");
