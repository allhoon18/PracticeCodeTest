using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var result = CarpetCounting.Solution(8, 1);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}