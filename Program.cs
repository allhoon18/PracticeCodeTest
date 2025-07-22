using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine(CollisionChecker.Solution
        (new[,] { { 3, 2 }, { 6, 4 }, { 4, 7 }, { 1, 4 } },
            new int[,] { { 4, 2 }, { 1, 3 }, { 4, 2 }, { 4, 3 } }));
    }
}