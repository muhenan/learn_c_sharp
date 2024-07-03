using Src.Async;
using Src.LINQ;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Hello, World!");

        // Synchronous method call
        // MySync.Run();
        // Asynchronous method call
        // await MyAsync.Run();


        MyLINQ.Run();
    }
}
