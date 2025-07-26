using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = CustomStringSorter.Solution(["abce", "abcd", "cdx"], 2);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}