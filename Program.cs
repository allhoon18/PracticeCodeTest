using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = TriangularSnail.Solution(6);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}