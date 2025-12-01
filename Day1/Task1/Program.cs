var currentPosition = 50;
var zeroOccurences = 0;

var lines = File.ReadLinesAsync("../input.txt");

await foreach (var line in lines)
{
    var direction = line[0];
    var number = Convert.ToInt32(line[1..]);
    var factor = direction == 'R' ? 1 : -1;
    currentPosition += number*factor;
    currentPosition = (100 + currentPosition)%100;

    if (currentPosition==0)
        zeroOccurences++;
}

Console.WriteLine(zeroOccurences);

