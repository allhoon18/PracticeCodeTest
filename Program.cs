using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        int[] result = AddElementsToArray.Solution([6, 6]);

        foreach (int i in result)
        {
            Console.Write(i + ", ");
        }
    }
}