// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;

namespace HW5_Tasks;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Action<string> actionWithFileData = (string s) =>
        {
            lock (Console.Out)
            {
                FileData fileData = JsonSerializer.Deserialize<FileData>(s);
                Console.ForegroundColor = fileData.Color;
                Console.WriteLine("Row number: '{0}'; Color: {1}; Random number: {2}",
                    fileData.Message, fileData.Color.ToString(), fileData.RandomNumber);
                Console.ResetColor();
            }
        };
        List<Task<FileObject>> tasks = new List<Task<FileObject>>();
        FileObject file = await FileHelper.CreateFile().CreateData(100);
        FileObject file2 = await FileHelper.CreateFile().CreateData(1000);
        // tasks.Add(Task.Run(() =>file.ReadMyFileAsync(actionWithFileData)));
        // tasks.Add(Task.Run(() =>file2.ReadMyFileAsync(actionWithFileData)));

        CancellationTokenSource tokenSource = new CancellationTokenSource();        // what is CancellationTokenSource and CancellationToken
        CancellationToken token = tokenSource.Token;
        
        
        tasks.Add(Task.Run(() => file.ReadMyFileAsync(actionWithFileData, token)));
        tasks.Add(Task.Run(() => file2.ReadMyFileAsync(actionWithFileData, token))); // file2 is bigger

        await tasks[0];
        tokenSource.Cancel();
        
        //Task.WaitAll(tasks.ToArray());
        
        file.DeleteFile();
        file2.DeleteFile();
        Console.WriteLine("--- main ---");
    }
    
    

}