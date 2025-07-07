using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = GCDLCMCalculator.solution(24, 36);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}