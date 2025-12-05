var lines = File.ReadLinesAsync("../input.txt");

var ranges = new List<(long start, long end)>();

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
        break;
    }
}

var orderedRanges = ranges.OrderBy(r => r.start).ToList();

long maxNumberAdded = 0;
long freshIngredientsCount = 0;
foreach (var range in orderedRanges)
{
    if (range.end <= maxNumberAdded)
        continue;

    if (maxNumberAdded < range.start)
    {
        freshIngredientsCount += range.end - range.start + 1;
        maxNumberAdded = range.end;
    }
    if (maxNumberAdded >= range.start && maxNumberAdded < range.end)
    {
        freshIngredientsCount += range.end - maxNumberAdded;
        maxNumberAdded = range.end;
    }
}
Console.WriteLine(freshIngredientsCount);