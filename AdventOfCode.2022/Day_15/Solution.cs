// namespace AoC.Day_15;
//
// public class Solution
// {
//     // static int MinX = Int32.MaxValue;
//     // static int MaxX = Int32.MinValue;
//     // static int MinY = Int32.MaxValue;
//     // static int MaxY = Int32.MinValue;
//
//     public static void Run()
//     {
//         var sensors = File.ReadAllLines("input.txt").Select(Parse).ToList();
//
//         // MinX -= 10000;
//         // MaxX += 10000;
//         // MinY -= 10000;
//         // MaxY += 10000;
//
//         int xTranslate = MinX < 0 ? -1 * MinX : 0;
//         int yTranslate = MinY < 0 ? -1 * MinY : 0;
//         
//         var dictionary = new object[MaxX - MinX + 1, MaxY - MinY + 1];
//         
//         // var ec = new EmptyCell();
//         // for (int i = MinX; i <= MaxX; i++)
//         // {
//         //     for (int j = MinY; j <= MaxY; j++)
//         //     {
//         //         dictionary.Add((i, j), ec);
//         //     }
//         // }
//
//         var uc = new UnavailableCell();
//         var sId = 0;
//         Console.WriteLine("sensors: {0}", sensors.Count);
//         foreach (var sensor in sensors)
//         {
//             Console.WriteLine(sId++);
//             dictionary[sensor.GetX(xTranslate), sensor.GetY(yTranslate)] = sensor;
//             dictionary[sensor.Beacon.GetX(xTranslate), sensor.Beacon.GetY(yTranslate)] = sensor.Beacon;
//             var manhattanDistance = Math.Abs(sensor.GetX(xTranslate) - sensor.Beacon.GetX(xTranslate)) + Math.Abs(sensor.GetY(yTranslate) - sensor.Beacon.GetY(yTranslate));
//             
//             // if (sensor.X != 8 || sensor.Y != 7) continue;
//
//             for (int i = sensor.GetX(xTranslate) - manhattanDistance; i <= sensor.GetX(xTranslate) + manhattanDistance; i++)
//             {
//                 for (int j = sensor.GetY(yTranslate) - manhattanDistance; j <= sensor.GetY(yTranslate) + manhattanDistance; j++)
//                 {
//                     if (i < 0 || i >= dictionary.GetLength(0) || j < 0 || j >= dictionary.GetLength(1)) continue;
//                     
//                     if (dictionary[i, j] is null || dictionary[i, j] is EmptyCell)
//                     {
//                         if (!IsWithinManhattanDistance(manhattanDistance, (sensor.GetX(xTranslate), sensor.GetY(yTranslate)), (i, j))) 
//                             continue;
//
//                         dictionary[i, j] = uc;
//                     }
//                 }
//             }
//         }
//
//         var ec = new EmptyCell();
//         for (int j = MinY + yTranslate; j <= MaxY + yTranslate; j++)
//         {
//             for (int i = MinX + xTranslate; i <= MaxX + xTranslate; i++)
//             {
//                 var obj = dictionary[i, j] ?? ec;
//
//                 var symbol = obj switch
//                 {
//                     EmptyCell => ".",
//                     UnavailableCell => "#",
//                     Beacon => "B",
//                     Sensor => "S",
//                     _ => throw new ArgumentOutOfRangeException()
//                 };
//                 Console.Write(symbol);
//             }
//
//             Console.WriteLine();
//         }
//
//         var count = 0;
//         for (int i = MinX + xTranslate; i < MaxX + xTranslate; i++)
//         {
//             var val = dictionary[i, 2000000 + yTranslate];
//             if (val is UnavailableCell)
//                 count++;
//         }
//
//         Console.WriteLine(count);
//     }
//
//     public class UnavailableCell
//     {
//     }
//
//     static bool IsWithinManhattanDistance(int manhattanDistance, (int x, int y) from, (int x, int y) to)
//     {
//         return manhattanDistance >= Math.Abs(from.x - to.x) + Math.Abs(from.y - to.y);
//     }
//
//     public class EmptyCell
//     {
//     }
//
//     public static Sensor Parse(string line)
//     {
//         var sensorBeacon = line.Split(":").ToArray();
//         var sensor = new String(sensorBeacon[0].Skip("Sensor at x=".Length).ToArray()).Split(", y=").ToArray();
//         var beacon = new string(sensorBeacon[1].Skip(" closest beacon is at x=".Length).ToArray()).Split(", y=").ToArray();
//
//         var sX = int.Parse(sensor[0]);
//         var sY = int.Parse(sensor[1]);
//         var bX = int.Parse(beacon[0]);
//         var bY = int.Parse(beacon[1]);
//
//         MinX = Math.Min(Math.Min(MinX, sX), bX);
//         MaxX = Math.Max(Math.Max(MaxX, sX), bX);
//
//         MinY = Math.Min(Math.Min(MinY, sY), bY);
//         MaxY = Math.Max(Math.Max(MaxY, sY), bY);
//         
//         var newBeacon = new Beacon() { X = bX, Y = bY };
//         var newSensor = new Sensor() { X = sX, Y = sY, Beacon = newBeacon };
//
//         return newSensor;
//     }
//
//     public class Sensor
//     {
//         public int X { private get; init; }
//         public int Y { private get; init; }
//
//         public int GetX(int translate)
//         {
//             return X + translate;
//         }
//
//         public int GetY(int translate)
//         {
//             return Y + translate;
//         }
//
//         public Beacon Beacon { get; set; }
//     }
//
//     public class Beacon
//     {
//         public int X { private get; init; }
//         public int Y { private get; init; }
//         
//         public int GetX(int translate)
//         {
//             return X + translate;
//         }
//
//         public int GetY(int translate)
//         {
//             return Y + translate;
//         }
//     }
// }