using System.IO;
using System.Linq;

namespace advent_of_code.challenges;

public abstract class ChallengeBase
{
    public abstract void RunPart1();
    public abstract void RunPart2();
    
    protected string[] ReadInput()
    {
        return Read("input.txt");
    }

    protected string[] ReadTest()
    {
        return Read("test.txt");
    }

    protected string[] Read(string filename)
    {
        var nms = GetType().Namespace! // advent_of_code.challenges._2023._01
            .Split(".") // [advent_of_code, challenges, _2023, _01]
            .Skip(1) // [challenges, _2023, _01]
            .Select(l => l.Replace("_", string.Empty)) // [challenges, 2023, 01]
            .ToArray();

        var path = Path.Combine(nms.Union(new[] { filename }).ToArray());
        return File.ReadAllLines(path)
            .Select(l => l.Trim())
            .ToArray();
    }
}