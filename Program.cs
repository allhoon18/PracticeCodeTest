using PracticeCodeTest;
using PracticeCodeTest.Solutions;
using PracticeCodeTest.Solutions.Section1;
using PracticeCodeTest.Solutions.Section2;

public class MainClass
{
    static void Main(string[] args)
    {
        string[,] tickets = new string[,] 
            {
                { "ICN", "JFK" }, 
                { "HND", "IAD" }, 
                { "JFK", "HND" }, 
                
            };
        
        var arr = TravelCourseSelector.Solution(tickets);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}