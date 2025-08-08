using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;
using PracticeCodeTest.Solutions.Section2;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = new int[,] {{60, 50}, {30, 70}, {60, 30}, {80, 40}};
        
        Console.WriteLine(MinimumBoundingBox.Solution(arr));
    }
}