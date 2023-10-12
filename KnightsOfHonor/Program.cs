
using System;

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[]> KnightNamePrint = (names) =>
{
	foreach (var name in names)
	{
		Console.WriteLine("Sir " + name);
	}
};

KnightNamePrint(names);
