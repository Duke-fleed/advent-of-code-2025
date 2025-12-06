var lines = File.ReadLinesAsync("../input.txt");

var numbers = new List<List<long>>();
var operations = new List<string>();
var rowIndex = 0;
await foreach (var line in lines)
{
  if (rowIndex<4)
  {
   var lineNumbers = new List<long>();
   var splitNumbers = line.Split(" ")
    .Where(x=> !string.IsNullOrWhiteSpace(x))
    .Select(long.Parse)
    .ToList();
   numbers.Add(splitNumbers);
  }
  else 
  {
    operations = [.. line.Split(" ").Where(x=> !string.IsNullOrWhiteSpace(x))]; 
  }
  rowIndex ++;
}

long totalSum = 0;
for (int i=0; i<numbers[0].Count; i++){
  totalSum += operations[i] == "+" ? numbers[0][i] + numbers[1][i] + numbers[2][i] + numbers[3][i] : numbers[0][i] * numbers[1][i] * numbers[2][i] * numbers[3][i];
}

Console.WriteLine(totalSum);
