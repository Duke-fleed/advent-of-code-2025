var lines = File.ReadLinesAsync("../input.txt");

//Task1
Console.WriteLine(await GetJoltage(2,lines));
//Task2
Console.WriteLine(await GetJoltage(12,lines));


static async Task<double> GetJoltage(short numberOfDigits, IAsyncEnumerable<string> lines)
{
    double sum = 0;
    await foreach (var line in lines)
    {
        var lineToSearchIn = line;
        for (int i=1; i<=numberOfDigits; i++)
        {
        var largestFirst = FindLargestInLine(lineToSearchIn,lineToSearchIn.Length-(numberOfDigits-i));
        lineToSearchIn = lineToSearchIn.Substring(largestFirst.index+1);
        sum += largestFirst.number*Math.Pow(10,numberOfDigits-i);   
        }
    }

    return sum;

    static (int number, int index) FindLargestInLine(string line, int endIndex)
    {
        var largest = Convert.ToInt16(line[0].ToString());
        var largestIndex = 0;
        for (var i=1; i<endIndex; i++)
        {
            var convertedNumber = Convert.ToInt16(line[i].ToString());
            if (convertedNumber > largest)
            {
                largest = convertedNumber;
                largestIndex = i;
                if (convertedNumber == 9)
                    break;
            }
        }
        return (largest, largestIndex);
    }
}
