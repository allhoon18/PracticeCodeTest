using PracticeCodeTest.Solutions;
public class MainClass
{
    static void Main(string[] args)
    {
        var arr = HallOfFameManager.Solution(3, [10, 100, 20, 150, 1, 100, 200]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}