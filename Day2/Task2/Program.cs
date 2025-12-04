var text = await File.ReadAllTextAsync("../input.txt");

var ranges = text.Split(',');
long sum = 0;
System.Console.WriteLine(ranges.Length);
foreach (var range in ranges)
{
    var bounds = range.Split('-').Select(long.Parse).ToArray();
    var start = bounds[0];
    var end = bounds[1];

    for (var i = start; i <= end; i++)
    {
        var iString = i.ToString();
        for (var n = 0; n < iString.Length/2; n++)
        {
            var substring1 = iString.Substring(0, n+1);
        }
    }
}

Console.WriteLine(sum);
