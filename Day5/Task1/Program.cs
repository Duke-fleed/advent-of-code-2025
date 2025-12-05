var lines = File.ReadLinesAsync("../input.txt");

var ranges = new List<(long start, long end)>();
var idsToCheck = new List<long>();

await foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
        continue;

    if (line.Contains("-"))
    {
        var numbers =  line.Split('-');
        ranges.Add((long.Parse(numbers[0]), long.Parse(numbers[1])));
    }
    else
    {
        idsToCheck.Add(long.Parse(line));
    }
}

var count = 0;
foreach (var number in idsToCheck)
{
    if (ranges.Any(r => number >= r.start && number <= r.end))
    {
        count++;
    }
}
Console.WriteLine(count);