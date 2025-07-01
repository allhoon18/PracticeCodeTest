using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        int[,] commands = new int[3, 3] {
            { 2, 5, 3 },
            { 4, 4, 1 },
            { 1, 7, 3 }
        };

        int[] array = [9, 1, 8, 2, 7, 3, 6, 4, 5];

        int[,] commands2 = new int[3, 3]
        {
            { 1, 9, 5 },
            { 3, 7, 2 },
            { 2, 4, 1 }
        };
        
        int[] answer = KthNumber.Solution([1, 5, 2, 6, 3, 7, 4],commands);
        
        foreach (int i in answer)
        {
            Console.Write(i + " ,");
        }
    }
}