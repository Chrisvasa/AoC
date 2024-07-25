namespace AoC.Day2;

public static class Day2
{
    public static void ParseFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Could not find file.");
            return;
        }

        StreamReader sr = new StreamReader(path);
        string? line;
        int sum = 0;
        int sumPower = 0;

        while ((line = sr.ReadLine()) != null)
        {
            string[] set = line.Split(':', ';');
            int gameID = int.Parse(set[0].Substring(4));
            bool isValid = true;
            int[] setValues = {0, 0, 0};
            
            for (int i = 1; i < set.Length; i++)
            {
                string[] values = set[i].Split(',');
                foreach (string val in values)
                {
                    // if (!isValid)
                    //     break;
                    
                    string[] c = val.Split(' ');
                    int v = int.Parse(c[1]);

                    switch (c[2])
                    {
                        case "red" when v > 12:
                        case "green" when v > 13:
                        case "blue" when v > 14:
                            isValid = false;
                            break;
                    }
                    
                    switch (c[2])
                    {
                        case "red" when v > setValues[0]:
                            setValues[0] = v;
                            break;
                        case "green" when v > setValues[1]:
                            setValues[1] = v;
                            break;
                        case "blue" when v > setValues[2]:
                            setValues[2] = v;
                            break;
                    }
                }

            }
            if (isValid)
            {
                sum += gameID;
            }
            sumPower += (setValues[0] * setValues[1] * setValues[2]);
            Console.WriteLine($"sumPower is: {sumPower}\nAnd we just multiplied {setValues[0]} * {setValues[1]} * {setValues[2]}");
        }
        Console.WriteLine($"Part 1: {sum}");
        Console.WriteLine($"Part 2: {sumPower}");
        sr.Close();
    }
}