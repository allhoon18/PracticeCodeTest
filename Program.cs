using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        int[] result = CreatArray.Solution(5, 555);

        foreach (int i in result)
        {
            Console.Write(i + ", ");
        }
    }
}