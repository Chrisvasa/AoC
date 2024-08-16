using AoC.Util;

namespace AoC._2023;

public readonly struct MapRange(long start, long end, long value)
{
    public long Start { get; } = start;
    public long End { get; } = end;
    public long Value { get; } = value;
}
public class Day5
{
    private static string[] seeds;
    private static List<long> locations = new List<long>();
    private static long length;
    private static readonly Dictionary<int, List<MapRange>> maps = new Dictionary<int, List<MapRange>>()
    {
        { 0, new List<MapRange>() },
        { 1, new List<MapRange>() },
        { 2, new List<MapRange>() },
        { 3, new List<MapRange>() },
        { 4, new List<MapRange>() },
        { 5, new List<MapRange>() },
        { 6, new List<MapRange>() }
    };
    
    private static Dictionary<int, string> mapDictionary = new Dictionary<int, string>()
    {
        { 0, "Soil" },
        { 1, "Fertilizer" },
        { 2, "Water" },
        { 3, "Light" },
        { 4, "Temperature" },
        { 5, "Humidity" },
        { 6, "Location" }
    };
    
    public static void Fertilizer()
    {
        FileManager fm = new FileManager("Day5", "2023");
        string[] lines = ReadAndParseFile(fm.FilePath);
        ParseValuesToMaps(lines);
        PartOne();
        PartTwo();
    }
    
    private static void PartOne()
    {
        for (int i = 0; i < seeds.Length; i++)
        {
            long seed = long.Parse(seeds[i]);
            FindLowestLocationNumber(seed);
        }

        locations = locations.OrderBy(l => l).ToList();
        Console.WriteLine($"Part 1: {locations[0]}");
        locations.Clear();
    }

    private static void PartTwo()
    {
        for (int i = 0; i < seeds.Length; i+=2)
        {
            long seed = long.Parse(seeds[i]);
            length = long.Parse(seeds[i + 1]);
            for (int j = 0; j < length; j++)
            {
                FindLowestLocationNumber(seed + j);
            }
        }

        locations = locations.OrderBy(l => l).ToList();
        Console.WriteLine($"Part 2: {locations[0]}");
    }
    
    
    private static void FindLowestLocationNumber(long seed)
    {
        // Console.WriteLine($"Seed: {seed}");
        for (int i = 0; i < maps.Count; i++)
        {
            foreach (var map in maps[i])
            {
                long start = map.Start;
                long end = map.End;
                long value = map.Value;

                if (seed >= start && seed <= end)
                {
                    seed = value + (seed - start);
                    break;
                }
            }
            // Console.WriteLine($"{mapDictionary[i]}: {seed}");
        }

        if (locations.Count > 0)
        {
            if (locations.Last() > seed)
                locations.Add(seed);
        }
        else
        {
            locations.Add(seed);
        }
    }
    
    private static void ParseValuesToMaps(string[] lines)
    {
        int mapIndex = 0;
        // Start at 2 to skip seeds and first "map value"
        for (int i = 2; i < lines.Length; i++)
        {
            if (!char.IsDigit(lines[i][0]))
            {
                mapIndex++;
            }
            else
            {
                ReadOnlySpan<char> line = lines[i].AsSpan().Trim();

                int first = line.IndexOf(' ');
                int second = line.Slice(first + 1).IndexOf(' ') + first + 1;
                if (first == -1 || second == -1) continue;
                
                long sourceFirst = long.Parse(line.Slice(0, first));
                long sourceLast = long.Parse(line.Slice(first + 1, second - first - 1));
                long offsetToApply = long.Parse(line.Slice(second + 1));

                MapRange mapRange = new MapRange(sourceLast, sourceLast + offsetToApply - 1, sourceFirst);
                // Console.WriteLine($"Added Range with: {mapRange.Start} to {mapRange.End} with the start value of {mapRange.Value}");
                maps[mapIndex].Add(mapRange);
            }
        }
    }
    
    private static string[] ReadAndParseFile(string path)
    {
        if (!File.Exists(path))
            throw new Exception("Could not open file.");
        
        string[] lines = File.ReadAllLines(path)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        seeds = lines[0].Split(": ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return lines;
    }
}