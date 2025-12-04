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
        var repeteadSequence = iString[0].ToString();
        var j = 1;
        while (j < iString.Length && j+repeteadSequence.Length<= iString.Length)
        {
            if (iString.Substring(j,repeteadSequence.Length) == repeteadSequence)
            {
                j += repeteadSequence.Length;
            } 
            else
            {
                repeteadSequence = iString[..(j+1)];
                j++;
            }
        }

        if (repeteadSequence.Length < iString.Length && j >= iString.Length)
        {
            sum += i;
        }
    }
}

Console.WriteLine(sum);
