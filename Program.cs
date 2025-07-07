using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = DivisorFinder.Solution(24);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}