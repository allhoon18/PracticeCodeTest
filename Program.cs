using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;
using PracticeCodeTest.Solutions.Section2;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = new int[,] {{80,20}, {50,40}, {30,10}};
        
        Console.WriteLine(DungeonExplorationOptimizer.Solution(80,arr));
    }
}