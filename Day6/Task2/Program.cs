var lines = await File.ReadAllLinesAsync("../input.txt");

ulong totalSum = 0;
var currentOperation = string.Empty;
var currentNumbers = new List<ulong>();
for (int i=0; i<lines[0].Length+1; i++)
{
    if (i==lines[0].Length || (lines[0][i] == ' ' && lines[1][i] == ' ' && lines[2][i] == ' ' && lines[3][i] == ' ' && lines[4][i] == ' '))
    {
        totalSum += currentOperation == "+" ? currentNumbers.Aggregate((x, y) => x + y) 
                  : currentNumbers.Aggregate((x, y) => x * y);
        currentOperation = string.Empty;
        currentNumbers.Clear();
    } else
    {
        if (string.IsNullOrWhiteSpace(currentOperation))
        {
            currentOperation = lines[4][i].ToString();
        }
        var currentNumber = lines[0][i].ToString() + lines[1][i].ToString() + lines[2][i].ToString() + lines[3][i].ToString();
        currentNumbers.Add(ulong.Parse(currentNumber.Trim()));
    }
}
System.Console.WriteLine(totalSum);