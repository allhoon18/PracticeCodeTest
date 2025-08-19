using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;
using PracticeCodeTest.Solutions.Section2;

public class MainClass
{
    static void Main(string[] args)
    {
        var arr = PrivacyPolicyValidator.Solution
        ("2022.05.19", 
            ["A 6", "B 12", "C 3"],
            ["2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C"]);
        
        foreach (var item in arr)
            {
            Console.WriteLine(item);
            }
    }
}