string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName ?? "", "input.txt");
var leftList = new List<int>();
var rightList = new List<int>();
var totalDistance = 0;

if (!File.Exists(filePath))
{
    Console.Write("File not found!");
    Console.ReadKey();
    return;
}

using var sr = new StreamReader(filePath);

while (!sr.EndOfStream)
{
    var line = sr.ReadLine() ?? "";
    var numbers = line.Split("   ");
    if (int.TryParse(numbers[0], out var leftNumber))
    {
        leftList.Add(leftNumber);
    }

    if (int.TryParse(numbers[1], out var rightNumber))
    {
        rightList.Add(rightNumber);
    }
}

leftList.Sort();
rightList.Sort();

//Part One

foreach (var (index, num) in leftList.Index())
{
    totalDistance += Math.Abs(num - rightList[index]);
}

Console.WriteLine($"Total Distance: {totalDistance}");

//Part Two

var dictionary = new Dictionary<int, int>();
var similarityScore = 0;

foreach (var num in leftList)
{
    var matches = rightList.FindAll(x => x == num);
    similarityScore += num * matches.Count;
}

Console.WriteLine($"Similarity Score: {similarityScore}");