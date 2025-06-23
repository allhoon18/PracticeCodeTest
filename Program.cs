using PracticeCodeTest;

public class MainClass
{
    static void Main(string[] args)
    {
        string[] id_list = { "muzi", "frodo", "apeach", "neo" };
        string[] report = {"muzi frodo","apeach frodo","frodo neo","muzi neo","apeach muzi" };
        
        int[] result = ReceiveReportResult.Solution(id_list, report,2);

        foreach (int i in result)
        {
            Console.Write(i + ", ");
        }
    }
}