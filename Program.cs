using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = ConditionalArrayOperation.Solution([49, 12, 100, 276, 33], 27);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}