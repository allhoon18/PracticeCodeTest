using PracticeCodeTest.Solutions;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr1 = new int[,] { { 1, 2 }, { 2, 3 } };
        var arr2 = new int[,] { { 3, 4 }, { 5, 6 } };

        Console.WriteLine(MatrixAdder.Solution(arr1, arr2));
    }
}