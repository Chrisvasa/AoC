namespace AoC._2021.Day1;

public class Day1
{
    public void SonarSweep(string path)
    {
        string[] lines = ReadFile(path);
        int incremented = 0;
        int largerSum = 0;
        
        for (int i = 0; i < lines.Length - 3; i++)
        {
            if (int.Parse(lines[i]) < int.Parse(lines[i + 1]))
                incremented++;
            int prevSum = int.Parse(lines[i]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
            int sum = int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]) + int.Parse(lines[i + 3]);

            if (prevSum < sum)
                largerSum++;
        }

        Console.WriteLine($"There are {largerSum} measurements larger than the previous measurement");
    }
    
    private string[] ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException("File not found.");
        }

        string[] lines = File.ReadAllLines(path);
        return lines;
    }
}