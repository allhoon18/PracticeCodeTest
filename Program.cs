using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var result = WithIntervalNumbers.Solution(-4, 2);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}