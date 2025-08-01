using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = MathProdigyFinder.Solution([1,3,2,4,2]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}