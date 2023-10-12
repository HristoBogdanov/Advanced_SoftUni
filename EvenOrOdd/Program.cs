using System.Collections.Generic;
using System;
using System.Linq;

int[] borders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();

List<int> numbers = new();

for (int i = borders[0]; i <= borders[1]; i++)
{
    numbers.Add(i);
}

Predicate<int> match;

bool isEven = Console.ReadLine() == "even";

if (isEven)
{
    match = number => number % 2 == 0;
}
else
{
    match = number => number % 2 != 0;
}

List<int> result = new();

foreach (var number in numbers)
{
    if (match(number))
    {
        result.Add(number);
    }
}

Console.WriteLine(string.Join(" ", result));