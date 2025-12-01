var currentPosition = 50;
var zeroPasses = 0;

var lines = File.ReadLinesAsync("../input.txt");

await foreach (var line in lines)
{
    var trimmedline = line.Trim();
    var direction = trimmedline[0];
    var number = Convert.ToInt32(trimmedline[1..]);
    zeroPasses += number/100;
    number = number%100;
    if (direction == 'R')
    {
        currentPosition += number;
        zeroPasses += currentPosition/100;
        currentPosition %= 100;
    }
    else
    {
        if ((currentPosition<=number && currentPosition != 0) || currentPosition == number)
        {
            zeroPasses++;
        }
        currentPosition -= number;
        currentPosition = (100 + currentPosition)%100;
    }
}

Console.WriteLine(zeroPasses);

