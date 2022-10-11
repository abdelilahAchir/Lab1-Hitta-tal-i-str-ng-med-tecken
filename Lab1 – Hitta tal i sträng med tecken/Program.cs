// See https://aka.ms/new-console-template for more information

//Lab1 – Abdelilah Achir

using Lab1___Hitta_tal_i_sträng_med_tecken;

string inputString = Console.ReadLine();
PrintSubstringsColored(inputString);

void PrintSubstringsColored(string inputString)
{
    if (inputString.Length > 1)
    {
        Console.Clear();
        substringIndexes[] subStrings = FindPositionAndLengh(inputString);
        bool stringNotEmpty;
        int beginingOfTheInputString = 0;
        for (int x = 0; x < subStrings.Count(); x++)
        {
            stringNotEmpty = subStrings[x].length != 0;
            if (stringNotEmpty)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(inputString.Substring(beginingOfTheInputString, subStrings[x].startIndex));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(inputString.Substring(subStrings[x].startIndex, subStrings[x].length));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(inputString.Substring(subStrings[x].length + subStrings[x].startIndex));
                Console.WriteLine();
            }
        }
    }
    else
    {
        Console.WriteLine("The input was empty or entered just one character");
    }

}


substringIndexes[] FindPositionAndLengh(string inputString)
{
    int start;
    int end;
    int length;
    bool isNotaNumber;
    bool startAndEndAreTheSame;
    substringIndexes[] subStrings = new substringIndexes[inputString.Length];

    double[] subStringsValues = new double[inputString.Length];
    for (int i = 0; i < inputString.Length; i++)
    {
        for (int x = i + 1; x < inputString.Length; x++)
        {
            start = i;
            end = x;
            isNotaNumber = !Char.IsDigit(inputString[x]);
            startAndEndAreTheSame = inputString[start] == inputString[end];
            if (isNotaNumber)
            {
                break;
            }
            else if (startAndEndAreTheSame)
            {
                length = end - start + 1;
                subStrings[i].startIndex = start;
                subStrings[i].length = length;
                subStringsValues[x] = double.Parse(inputString.Substring(i, length));
                break;
            }
        }
    }
    Console.WriteLine($"The sum of the found values is: {SumOfNumber(subStringsValues)}");
    return subStrings;
}

double SumOfNumber(double[] numbers)
{
    double totalSum = 0;
    foreach (var number in numbers)
    {
        totalSum += number;
    }
    return totalSum;
}

