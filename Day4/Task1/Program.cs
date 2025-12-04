var lines = await File.ReadAllLinesAsync("../input.txt");

const short arrayLength = 135;
char[,] matrix = new char[arrayLength,arrayLength];

for(int i=0; i<lines.Length; i++)
{
    for(int j=0; j<lines[i].Length; j++)
    {
        matrix[i,j] = lines[i][j];
    }
}

var numberOfAccessibleRolls = 0;
for(int i=0; i<arrayLength; i++)
{
    for(int j=0; j<arrayLength; j++)
    {
        if (matrix[i,j] == '@')
        {
            if (FindAdjacentRolls(i,j,matrix,arrayLength) < 4)
            {
                numberOfAccessibleRolls++;
            }   
        }
    }
}

Console.WriteLine(numberOfAccessibleRolls);


short FindAdjacentRolls(int i, int j, char[,] matrix, short arrayLength)
{
    short numberOfRolls = 0;
    if (i+1 < arrayLength && matrix[i+1,j] == '@') numberOfRolls++;
    if (i-1 >= 0 && matrix[i-1,j] == '@') numberOfRolls++;
    if (j+1 < arrayLength && matrix[i,j+1] == '@') numberOfRolls++;
    if (j-1 >= 0 && matrix[i,j-1] == '@') numberOfRolls++;

    //Diagonals
    if (i+1 < arrayLength && j+1 < arrayLength && matrix[i+1,j+1] == '@') numberOfRolls++;
    if (i+1 < arrayLength && j-1 >= 0 && matrix[i+1,j-1] == '@') numberOfRolls++;
    if (i-1 >= 0  && j-1 >= 0 && matrix[i-1,j-1] == '@') numberOfRolls++;
    if (i-1 >= 0  && j+1 < arrayLength && matrix[i-1,j+1] == '@') numberOfRolls++;

    return numberOfRolls;
}