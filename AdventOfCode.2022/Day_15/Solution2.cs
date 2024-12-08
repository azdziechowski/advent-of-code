using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day_15;

// attempt2
public class Solution2
{
    private const int maxRow = 4000000;
    
    private const int maxCol = 4000000;

    private const int multiplier = 4000000;
    public static void Run()
    {
        var sensors = File.ReadAllLines("input.txt").Select(Parse).ToList();
        var sensorAndBeaconDictionary = new Dictionary<(int, int), object>();

        foreach (var sensor in sensors)
        {
            sensorAndBeaconDictionary[(sensor.X, sensor.Y)] = sensor;
            sensorAndBeaconDictionary[(sensor.Beacon.X, sensor.Beacon.Y)] = sensor.Beacon;
        }

        for (int row = 0; row < maxRow; row++)
        {
            var ranges = new List<Range>();
            foreach (var k in sensorAndBeaconDictionary.Keys)
            {
                if (k.Item2 == row)
                {
                    ranges.Add(new Range(null, (k.Item1, row), (k.Item1, row)));
                }
            }
            
            foreach (var sensor in sensors)
            {
                var manhattanDistance = (Math.Abs(sensor.X - sensor.Beacon.X) + Math.Abs(sensor.Y - sensor.Beacon.Y));

                var residue = manhattanDistance - Math.Abs(sensor.Y - row);
                if (residue < 0) continue; // too far to affect the Row
            
                (int x, int y) from = (sensor.X - residue, row);
                (int x, int y) to = (sensor.X + residue, row);

                from.x = Math.Min(Math.Max(0, from.x), maxCol);
                to.x = Math.Min(Math.Max(0, to.x), maxCol);
                
                // if (sensorAndBeaconDictionary.ContainsKey(from))
                //     from.x += 1;
                //
                // if (sensorAndBeaconDictionary.ContainsKey(to))
                //     to.x -= 1;

                if (to.x < from.x)
                    continue;

                ranges.Add(new Range(sensor, from, to));
            }
            
            var part1 = ranges
                .Where(rng => rng.From.y == row)
                .OrderBy(rng => rng.From.x)
                .ThenBy(rng => rng.GetLength(0))

                // .Select(rng => rng.GetLength(0))
                .ToList();

            var readUntil = -1;
            var length = 0L;
            foreach (var range in part1)
            {
                if (range.From.x > readUntil)
                {
                    if (range.From.x - readUntil > 1)
                    {
                        Console.WriteLine($"Col: {readUntil + 1}, Row: {row}, freq: {(readUntil + 1)*multiplier + row}");
                        return;
                    }

                    length += range.GetLength(0);
                }
                else
                {
                    var overlap = Math.Abs(range.From.x - readUntil) + 1;
                    length += Math.Max(range.GetLength(0) - overlap, 0);
                }

                readUntil = Math.Max(readUntil, range.To.x);
            }

            // if (length != maxCol + 1)
            // {
            //     
            // }
        }
        



        // for (var i = -manhattanDistance; i <= 0; i++)
        // {
        //     for (var j = -manhattanDistance; j <= manhattanDistance; j++)
        //     {
        //         if (Math.Abs(i) + Math.Abs(j) != manhattanDistance)
        //             continue;
        //         
        //         var from = (sensor.X + i, sensor.Y + j);
        //         var to = (sensor.X - i, sensor.Y + j);
        //         if (sensorAndBeaconDictionary.ContainsKey(from))
        //             from.Item1 += 1;
        //         if (sensorAndBeaconDictionary.ContainsKey(to))
        //             to.Item1 -= 1;
        //         
        //         if (to.Item1 < from.Item1)
        //             continue;
        //
        //         ranges.Add(new Range(sensor, from, to));
        //     }
        // }



        // Console.WriteLine(length);

        //
        // var resultPart1 = sensorAndBeaconDictionary
        //     .Where(kv => kv.Value is NoBeacon)
        //     .Count(kv => kv.Key.Item2 == 2000000);

        // Console.WriteLine(part1);
    }

    public class Range
    {
        public (int x, int y) From { get; set; }
        public (int x, int y) To { get; set; }

        public Sensor Sensor { get; set; }
        
        public Range(Sensor s, (int x, int y) from, (int x, int y) to)
        {
            Sensor = s;
            From = from;
            To = to;
        }

        public long GetLength(int dim)
        {
            if (dim == 0)
                return Math.Abs(To.x - From.x) + 1;
            if (dim == 1)
                return To.y - From.y + 1;
            throw new ArgumentException();
        }

    }

    public class NoBeacon
    {
    }


    public static Sensor Parse(string line)
    {
        var sensorBeacon = line.Split(":").ToArray();
        
        var sensor = new String(sensorBeacon[0].Skip("Sensor at x=".Length).ToArray()).Split(", y=").ToArray();
        var beacon = new string(sensorBeacon[1].Skip(" closest beacon is at x=".Length).ToArray()).Split(", y=")
            .ToArray();

        var sX = int.Parse(sensor[0]);
        var sY = int.Parse(sensor[1]);
        var bX = int.Parse(beacon[0]);
        var bY = int.Parse(beacon[1]);

        var newBeacon = new Beacon() { X = bX, Y = bY };
        var newSensor = new Sensor() { X = sX, Y = sY, Beacon = newBeacon };

        return newSensor;
    }

    public class Sensor
    {
        public int X {  get; init; }
        public int Y {  get; init; }
        
        public Beacon Beacon { get; set; }
    }

    public class Beacon
    {
        public int X {  get; init; }
        public int Y {  get; init; }
    }
}