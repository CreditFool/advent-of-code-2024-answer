using System.Text.RegularExpressions;

static int CalculateValidMul(string input)
{
    string pattern = "mul\\([0-9]{1,3},[0-9]{1,3}\\)";
    var validMul = Regex.Matches(input, pattern);

    int result = 0;
    foreach (var mul in validMul)
    {
        var nums = $"{mul}".Replace("mul(", "").Replace(")", "").Split(",");
        result += int.Parse(nums[0]) * int.Parse(nums[1]);
    }

    return result;
}

static int CalculateValidMulWithEnabler(string input)
{
    string pattern = "mul\\([0-9]{1,3},[0-9]{1,3}\\)|do\\(\\)|don't\\(\\)";
    var instructions = Regex.Matches(input, pattern);

    bool isEnable = true;
    int result = 0;
    foreach (var instruction in instructions)
    {
        if ($"{instruction}".Equals("do()"))
        {
            isEnable = true;
        }
        else if ($"{instruction}".Equals("don't()"))
        {
            isEnable = false;
        }
        else
        {
            if (isEnable)
            {
                var nums = $"{instruction}".Replace("mul(", "").Replace(")", "").Split(",");
                result += int.Parse(nums[0]) * int.Parse(nums[1]);
            }
        }
    }

    return result;
}

string input;
try
{
    using StreamReader sr = new(File.OpenRead("/home/enigma/kodingan/project/advent-of-code-2024-code/Day 3/input.txt"));
    input = sr.ReadToEnd();
    Console.WriteLine($"Total Mul: {CalculateValidMul(input)}" );
    Console.WriteLine($"Total Mul with Enabler: {CalculateValidMulWithEnabler(input)}");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
