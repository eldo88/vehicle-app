namespace vehicle_app;

public static class FileOperations
{
    public static void ReadDataFromFile(string filePath, List<string> targetList)
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
                    targetList.AddRange(values);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
    }

    public static void ReadModelDataIntoDict(string filePath, Dictionary<string, List<string>> targetDict)
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
                    targetDict.Add(makeVehicleTypeKey, modelList);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
    }
}