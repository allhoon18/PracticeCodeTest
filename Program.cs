using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;
using PracticeCodeTest.Solutions.Section2;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = RaceRankManager.Solution(["mumu", "soe", "poe", "kai", "mine"], ["kai", "kai", "mine", "mine"]);
        
        foreach (var item in arr)
            {
            Console.WriteLine(item);
            }
    }
}