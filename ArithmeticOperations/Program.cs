using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToList();

Func<string, List<int>, List<int>> Caclculate = (command, numbers) =>
{
    switch(command)
    {
        case "add":
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] += 1;
            }
            break;
        case "multiply":
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *=2;
            }
            break;
        case "subtract":
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }
            break;
    }
    return numbers;
};

string input = String.Empty;
while ((input=Console.ReadLine())!="end")
{
    if(input=="print")
    {
        Console.WriteLine(String.Join(" ", numbers));
    }
    else
    {
        numbers = Caclculate(input, numbers);
    }
}