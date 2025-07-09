using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = ConditionalSequenceTransformer1.Solution([1, 2, 3, 100, 99, 98]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}