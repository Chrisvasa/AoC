using System.Threading.Channels;

namespace AoC.Day5;

public class Day5
{
    private static string[] lines;
    private static string[] seeds;
    private static List<long> locations = new List<long>();
    private static readonly Dictionary<int, List<string>> maps = new Dictionary<int, List<string>>()
    {
        { 0, new List<string>() },
        { 1, new List<string>() },
        { 2, new List<string>() },
        { 3, new List<string>() },
        { 4, new List<string>() },
        { 5, new List<string>() },
        { 6, new List<string>() }
    };
    
    public static void Fertilizer(string path)
    {
        ReadAndParseFile(path);
        ParseValuesToMaps();
        for (int i = 0; i < seeds.Length; i++)
        {
            long seed = long.Parse(seeds[i]);
            FindLowestLocationNumber(seed);
        }
    }

    private static void FindLowestLocationNumber(long seed)
    {
        long[] temp = new long[7];
        Array.Fill(temp, - 1);
        int index = 0;
        for (int i = 0; i < maps.Count; i++)
        {
            for (int j = 0; j < maps[i].Count; j++)
            {
                /*
                 - nums[0] = Destination range start
                 - nums[1] = Source range start
                 - nums[2] = range length
                */
                string[] nums = maps[i][j].Split(" ");
                if (seed >= long.Parse(nums[1]) && seed < long.Parse(nums[1]) + long.Parse(nums[2]))
                {
                    long test = long.Parse(nums[0]) - long.Parse(nums[1]);
                    temp[index] = seed + test;
                    break;
                }
                else
                {
                    if (temp[index] == -1 || temp[index] == seed)
                        temp[index] = seed;
                }
            }

            if (i == maps.Count - 1)
            {
                locations.Add(temp[index]);
            }
            seed = temp[index];
        }

        locations = locations.OrderBy(l => l).ToList();
        Console.WriteLine($"Shortest location is: {locations[0]}");
    }
    
    private static void ParseValuesToMaps()
    {
        int mapIndex = 0;
        // Start at 2 to skip seeds and first "map value"
        for (int i = 2; i < lines.Length; i++)
        {
            if (!char.IsDigit(lines[i][0]))
                mapIndex++;
            else
                maps[mapIndex].Add(lines[i]);
        }
    }
    
    private static void ReadAndParseFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Could not open file!");
            return;
        }
        
        lines = File.ReadAllLines(path)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        seeds = lines[0].Split(": ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }
}