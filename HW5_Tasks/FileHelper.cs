using System.Text;
using System.Text.Json;
using System;

namespace HW5_Tasks;

public static class FileHelper
{
    private static int _fileNameCounter = 1;
    public static string Path { get; set; } = "fiels/";

    #region CreateFile

    public static FileObject CreateFile()
    {
        var fileName = GetFileName();
        if (File.Exists(GetFileWithPath()))
        {
            GetNewFileName();
            return CreateFile();
        }
        else
        {
            return new FileObject()
            {
                Path = GetFileWithPath(),
                FileName = GetFileName(),
                FS = File.Create(GetFileWithPath())
            };
        }
    }
    public static async Task<FileObject> CreateData(this FileObject file, int rowsNumber = 10)
    {
        var stream = file.FS;
        List<FileData> fileDatas = new List<FileData>();
        var colorToSet = (ConsoleColor)Random.Shared.Next(1, 14);
        for (int i = 0; i < rowsNumber; i++)
        {
            fileDatas.Add(new FileData()
            {
                Color = colorToSet,
                Message = $"objectNum: {i}",
                RandomNumber = Random.Shared.Next(1000)
            });
        }
        var bytes = Encoding.UTF8.GetBytes(WriteJSONLineByLine(fileDatas));
        using (stream)
        {
            await stream.WriteAsync(bytes, 0,bytes.Length);
            Console.WriteLine("lines created");
        }

        await Task.Delay(1000);
        return file;
    }

    #endregion

    #region ReadFile

    public static async Task<FileObject> ReadMyFileAsync(this FileObject file, Action<string, FileObject> doAction)
    {
        using (StreamReader reader = new StreamReader(file.Path))
        {
            while (!reader.EndOfStream)
            {
                doAction(await reader.ReadLineAsync(), file);
            }
        }
        return file;
    }

    public static async Task<FileObject> ReadMyFileAsync(this FileObject file)
    {
        ReadMyFileAsync(file, (s, file) => Console.WriteLine(s));
        return file;
    }

    #endregion
    
    #region Helpers

    private static string GetFileName() => $"file{_fileNameCounter}.txt";
    private static string GetNewFileName() => $"file{_fileNameCounter++}.txt";
    private static string GetFileWithPath() => Path + $"file{_fileNameCounter}.txt";

    private static string WriteJSONLineByLine<T>(IEnumerable<T> listToJson)
    {
        StringBuilder json = new StringBuilder();
        foreach (var value in listToJson)
        {
            json.Append(JsonSerializer.Serialize(value) + "\n");
        }
        return json.ToString();
    }

    #endregion
    
}