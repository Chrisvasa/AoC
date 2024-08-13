namespace AoC._2021.Day3;

public class Day3
{
    public void BinaryDiagnostic(string path)
    {
        string[] lines = ReadFile(path);

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