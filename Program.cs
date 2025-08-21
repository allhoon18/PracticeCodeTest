using PracticeCodeTest.Solutions;
public class MainClass
{
    static void Main(string[] args)
    {
        var arr = FeatureDeploymentManager.Solution([93, 30, 55], [1, 30, 5]);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}