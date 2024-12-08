using System;
using System.Threading.Tasks;

// ReSharper disable All



var kuba = new Person();

while (true)
{
    if (DateTime.Now is { Month: 1, Day: 19 })
    {
        kuba.Age++;
        if (kuba.Age < 30)
            Console.WriteLine($"Wszystkiego Najlepszego z okazji {kuba.Age} urodzin Kubuś!");

        // don't remind him about the age
        else
            Console.WriteLine("Wszystkiego Najlepszego panie Noga");
    }

    await Task.Delay(TimeSpan.FromDays(1));
}


class Person
{
    public int Age { get; set; }
}


// Solution.Run();



