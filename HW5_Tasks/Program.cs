// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;

namespace HW5_Tasks;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var actionWithFileData = (string s, FileObject mock) =>
        {
            lock (mock)
            {
                FileData fileData = JsonSerializer.Deserialize<FileData>(s);
                Console.ForegroundColor = fileData.Color;
                Console.WriteLine("Row number: '{0}'; Color: {1}; Random number: {2}",
                    fileData.Message, fileData.Color.ToString(), fileData.RandomNumber);
                Console.ResetColor();
            }
        };

        var file = await FileHelper.CreateFile().CreateData(100);
        var file2 = await FileHelper.CreateFile().CreateData(100);
        var file3 = await FileHelper.CreateFile().CreateData(100);
        var file4 = await FileHelper.CreateFile().CreateData(100);
        var file5 = await FileHelper.CreateFile().CreateData(100);

        await file.ReadMyFileAsync(actionWithFileData);
        await file2.ReadMyFileAsync(actionWithFileData);
        await file3.ReadMyFileAsync(actionWithFileData);
        await file4.ReadMyFileAsync(actionWithFileData);
        await file5.ReadMyFileAsync(actionWithFileData);
        

        
        Console.WriteLine("--- main ---");
    }
    
    

}