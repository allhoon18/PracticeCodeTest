using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = NSquaredArraySlice.Solution(3,2,5);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}