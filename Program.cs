using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = StockPriceAnalyzer.Solution([1, 2, 3, 2, 3]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}