static void CountSafeReport()
{
    try
    {
        int result = 0;
        int resultWithTolerant = 0;

        using StreamReader sr = new(File.Open("/home/enigma/kodingan/project/advent-of-code-2024-code/Day 2/input.txt", FileMode.Open));
        String? line = sr.ReadLine();
        while (line != null && line != string.Empty)
        {
            if (IsSafe(line)) result++;
            if (IsSafe(line, 1)) resultWithTolerant++;
            line = sr.ReadLine();
        }

        Console.WriteLine($"Safe report: {result}");
        Console.WriteLine($"Safe report with 1 tolerant: {resultWithTolerant}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }

}

static bool IsSafe(string line, int tolerant = 0)
{
    bool? isAscend = null;
    int badLevel = 0;
    string[] levels = line.Split(" ");
    for (int i = 0; i < levels.Length - 1; i++)
    {
        int currLevel = int.Parse(levels[i]);
        int nextLevel = int.Parse(levels[i + 1]);
        int diff = Math.Abs(currLevel - nextLevel);

        if (isAscend == null)
        {
            if (diff < 1 || diff > 3) badLevel++;
            isAscend = currLevel < nextLevel;
        }
        else if (((bool)isAscend) && ((currLevel > nextLevel) || diff < 1 || diff > 3))
            badLevel++;

        else if ((!(bool)isAscend) && ((currLevel < nextLevel) || diff < 1 || diff > 3))
            badLevel++;

        if (badLevel > tolerant)
            return false;
    }
    return true;
}

CountSafeReport();
