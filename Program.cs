using PracticeCodeTest.Solutions;
public class MainClass
{
    static void Main(string[] args)
    {
        var arr = new int[,]{{4, 5}, {4, 8}, {10, 14}, {11, 13}, {5, 12}, {3, 7}, {1, 4}};
        
        Console.WriteLine(MissileInterceptor.Solution(arr));
    }
}