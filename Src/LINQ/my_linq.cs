namespace Src.LINQ;

class MyLINQ
{
    public static void Run()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        foreach (var n in evenNumbers)
        {
            System.Console.WriteLine(n);
        }
    }
}