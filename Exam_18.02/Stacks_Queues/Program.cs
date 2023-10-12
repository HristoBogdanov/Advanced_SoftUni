using System.Collections.Generic;
using System;
using System.Linq;



Queue<int> textile = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse));

Stack<int> medicaments = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse));


Dictionary<string, int> craftedItems = new();
craftedItems.Add("Patch", 0);
craftedItems.Add("Bandage", 0);
craftedItems.Add("MedKit", 0);


while (textile.Any() && medicaments.Any())
{
    int currentTextile = textile.Dequeue();
    int currentMedicament = medicaments.Pop();

    int sum = currentMedicament + currentTextile;

    if(sum==30)
    {
        craftedItems["Patch"]++;
    }
    else if(sum==40)
    {
        craftedItems["Bandage"]++;
    }
    else if(sum==100)
    {
        craftedItems["MedKit"]++;
    }
    else if(sum>100)
    {
        craftedItems["MedKit"]++;

        if(medicaments.Any())
        {
            int nextMedicament = medicaments.Pop();
            medicaments.Push(nextMedicament + (sum - 100));
        }

    } 
    else
    {
        medicaments.Push(currentMedicament + 10);
    }
}
if(!textile.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if(!textile.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else
{
    Console.WriteLine("Medicaments are empty.");
}

var sorted = craftedItems.OrderByDescending(x => x.Value).ThenBy(n=>n.Key).ToDictionary(x => x.Key, x => x.Value);

foreach (var kvp in sorted.Where(x=>x.Value>0))
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}

if(medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {String.Join(", ",medicaments)}");
}
if (textile.Any())
{
    Console.WriteLine($"Textiles left: {String.Join(", ", textile)}");
}
