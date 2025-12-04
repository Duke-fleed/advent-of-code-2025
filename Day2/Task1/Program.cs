var text = await File.ReadAllTextAsync("../input.txt");

var ranges = text.Split(',');
long sum = 0;

foreach (var range in ranges)
{
    var bounds = range.Split('-').Select(long.Parse).ToArray();
    var start = bounds[0];
    var end = bounds[1];

    for (var i = start; i <= end; i++)
    {
        var iString = i.ToString();
        if (iString.Length % 2 == 1)
            continue;
        var splitiString = iString.Chunk(iString.Length / 2).ToArray();
        var number1 = long.Parse(splitiString[0]);
        var number2 = long.Parse(splitiString[1]);
        if (number1 == number2)
        {
            sum += i;
        }
    }
}

Console.WriteLine(sum);
