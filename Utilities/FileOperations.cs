namespace vehicle_app;

public static class FileOperations
{
    public static List<string> ReadDataFromFile(string filePath)
    {
        List<string> targetList = [];
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine($"{filePath} is empty or missing correct data format");
                }
                else
                {
                    var values = line.Split(',');
                    targetList.AddRange(values);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
        return targetList;
    }

    public static Dictionary<string, List<string>> ReadModelDataIntoDict(List<string> filePaths)
    {
        Dictionary<string, List<string>> targetDict = [];
        foreach (var filePath in filePaths)
        {
            if (File.Exists(filePath))
            {
                using StreamReader fileReader = new(File.OpenRead(filePath));
                while (!fileReader.EndOfStream)
                {
                    var makeVehicleTypeKey = fileReader.ReadLine();
                    var line = fileReader.ReadLine();

                    if (string.IsNullOrWhiteSpace(makeVehicleTypeKey) || string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine($"{filePath} is empty or missing correct data format");
                    }
                    else
                    {
                        var values = line.Split(',');
                        var modelList = new List<string>(values);
                    try
                    {
                        targetDict.Add(makeVehicleTypeKey, modelList);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            }
            else
            {
                Console.WriteLine($"File path {filePath} does not exist");
            }
        }
        return targetDict;
    }

    public static void ReadDataFromMockDbFile(string filePath, List<List<string>> targetList)
    {
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine($"{filePath} is empty or missing correct data format");
                }
                else
                {
                    var values = line.Split(',');
                    List<string> tempList = [];
                    tempList.AddRange(values);
                    targetList.Add(tempList);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
    }
}