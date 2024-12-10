namespace AdventOfCode._2024;

[TestFixture]
public class Day10
{
    private const string TestInput1 =
        """
        0123
        1234
        8765
        9876
        """;

    private const string TestInput2 =
        """
        89010123
        78121874
        87430965
        96549874
        45678903
        32019012
        01329801
        10456732
        """;

    private const string Input =
        """
        78434565658934341239890154327898789410169567876
        89125676543823430123763267016505654321678478965
        74034389012710569834354108987419783210501329450
        65985293405613478765587017096328798193432010321
        54876102564302349323498723165437689087589876501
        03123001273211058010567654232126575670670345432
        12054320985670769623458912343071464321561210894
        23065011234987878543467801056780352143254308743
        52176020143010987632966532963091243034165789652
        43982176542123676701876547872108389435045630001
        04343987233034565899892101543219474326554321100
        15458980154901454300765413256978365217893033234
        26967898067872343211234322107863210105676128744
        37810587120143443205895013278954306018985439653
        45721456431234556106786784567805217897851058912
        96012367589109667676632397876516986786542367803
        87183398676008768985541098923427875987034456934
        45698432195419878104323567012434564100124325965
        34787563084328769012013432100123473236787619876
        23456976176101098743100169981210984345894500761
        10067885105432345654221058974303876201903121450
        00198793234569854783334567565012565102812034321
        87235630321478345698448987545643476983456965410
        96544321410145430789567496538753985876589876521
        87875401521034521876321323429832104367674307834
        76965432690123670965410210018943011278765212985
        10126501785434987012124567877654780569890156676
        67635652376501456921023498965345698430732347787
        58548743210122357830010329453276582521231298898
        19989834543218766545689414340189891234560106787
        05678129670109658998776504276567760143671015890
        14329078786788347643210543183498452087982384321
        23010879895690210556987652092354301096543493430
        10123965654321987467878941001289212332102584321
        89854434365432176307650030110176565443001675610
        78765601278300045218941121230145896558903498701
        01251012369211234567132430548234787367812345672
        14344323054334565478012986699876572210787434987
        65689454120423672389873677780125601923896523654
        56788763201210981014564578456234892854589018743
        45697899854327872103434569327844763765474329012
        34307656761056932112363231218903454892365215603
        43218947892343341001454120305412178901054508763
        52107232103217654012360019456543065016543459454
        67800134564308567897871298787832104327872106563
        58910129875699430108998345690965432112967654312
        67623456766780123234567654321678987003458901203
        """;

    [TestCase(TestInput1, "1")]
    [TestCase(TestInput2, "36")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput2, "")]
    public void Part2(string input, string expectedOutput)
    {
        var testOutput = Solution2(input);
        Console.WriteLine($"{nameof(Part2)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution2(Input);
        Console.WriteLine($"{nameof(Part2)} actual result: {actualOutput}");
    }

    private static string Solution1(string input)
    {
        var map = input
            .Split("\n")
            .Select(line => line.Trim())
            .Select(line => line.ToCharArray())
            .ToArray();

        var total = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == '0')
                {
                    total += CalculateScore(map, i, j).Count;
                }
            }
        }

        return total.ToString();
    }

    private static List<(int, int)> Coords = new() { (1, 0), (0, 1), (0, -1), (-1, 0) };

    
    private static HashSet<(int, int)> CalculateScore(char[][] map, int i, int j)
    { 
        var currentLevel = map[i][j];
        if (currentLevel == '9') return [(i, j)];
        
        var total = new HashSet<(int, int)>();
        foreach (var coord in Coords.Select(c => (c.Item1 + i, c.Item2 + j)))
        {
            if (coord.Item1 < 0 || coord.Item2 < 0 || coord.Item1 >= map.Length || coord.Item2 >= map[0].Length)
            {
                continue;
            }

            if (map[coord.Item1][coord.Item2] == currentLevel + 1)
            {
                var result = CalculateScore(map, coord.Item1, coord.Item2);
                total = total.Union(result).ToHashSet();
            }
        }

        return total;
    }

    private static string Solution2(string input)
    {
        return "";
    }
}