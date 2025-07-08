using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = ArraySlicer.Solution([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], [7, 2, 3, 0]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}