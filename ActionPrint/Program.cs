using System;

string[] names=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

Action<string[]> print = (strings)
    => Console.WriteLine(string.Join(Environment.NewLine, strings));

print(names);