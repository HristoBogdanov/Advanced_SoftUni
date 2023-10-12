using System;
using System.Collections.Generic;
using System.Linq;

HashSet<int> numbers= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToHashSet();

Func<HashSet<int>, int> SmallestElement = (numbers) =>
{
    int min = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < min)
        {
            min = number;
        }
    }
    return min;
};

Console.WriteLine(SmallestElement(numbers));