using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = CustomProximitySorter.Solution([10000,20,36,47,40,6,10,7000], 30);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}