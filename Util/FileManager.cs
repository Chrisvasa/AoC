namespace AoC.Util;

public class FileManager
{
    private string? rootDirectoryPath;
    private string? filePath;

    public FileManager(string day, string year)
    {
        Initialize();
        GetFilePath(day, year);
    }

    public string? FilePath => filePath;
    
    private void Initialize()
    {
        string? currentDirectory = Environment.CurrentDirectory;
        rootDirectoryPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.Parent.FullName, "data");
        Console.WriteLine($"Root: {rootDirectoryPath}");
        if (rootDirectoryPath is null)
        {
            throw new InvalidOperationException("Cannot determine root directory path.");
        }
    }
    
    public void GetFilePath(string day, string year)
    {
        string workingDirectory = Path.Combine(rootDirectoryPath, $"{year}");
        Console.WriteLine($"Working directory: {workingDirectory}");
        if (!Directory.Exists(workingDirectory))
        {
            Console.WriteLine($"Creating {workingDirectory}");
            Directory.CreateDirectory(workingDirectory);
        }
        
        string[] textFiles = Directory.GetFiles(workingDirectory, "*.txt");
        foreach (var file in textFiles)
        {
            if (file.EndsWith($"{day}.txt"))
            {
                filePath = file;
                Console.WriteLine($"File Path: {filePath}");
            }
        }
    }
    
    public string[] ReadFileAndReturnArray()
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines;
    }
}