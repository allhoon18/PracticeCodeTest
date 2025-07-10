namespace PracticeCodeTest;

public class ReceiveReportResult
{
    /*
     * 각 유저는 한 번에 한 명의 유저를 신고할 수 있습니다.
     * 신고 횟수에 제한은 없습니다. 서로 다른 유저를 계속해서 신고할 수 있습니다.
     * 한 유저를 여러 번 신고할 수도 있지만, 동일한 유저에 대한 신고 횟수는 1회로 처리됩니다.
     * k번 이상 신고된 유저는 게시판 이용이 정지되며, 해당 유저를 신고한 모든 유저에게 정지 사실을 메일로 발송합니다.
     * 유저가 신고한 모든 내용을 취합하여 마지막에 한꺼번에 게시판 이용 정지를 시키면서 정지 메일을 발송합니다.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/92334
    
    /*
     * 이용자의 ID가 담긴 문자열 배열 id_list,
     * 각 이용자가 신고한 이용자의 ID 정보가 담긴 문자열 배열 report,
     * 정지 기준이 되는 신고 횟수 k가 매개변수로 주어질 때,
     * 각 유저별로 처리 결과 메일을 받은 횟수를 배열에 담아 return 하도록 solution 함수를 완성해주세요.
     */
    
    public static int[] Solution(string[] id_list, string[] report, int k) {
        int[] answer = new int[id_list.Length];

        Dictionary<string, Tuple<List<string>, int>> reportData =  new Dictionary<string, Tuple<List<string>, int>>();

        foreach (string reportContent in report)
        {
            string userId = reportContent.Split(" ")[0];
            string reportId = reportContent.Split(" ")[1];
            //어떤 아이디를 어떤 유저가 신고했는지 + 신고 횟수 저장
            CheckReportData(userId, reportId, ref reportData);
        }
        
        List<string> bannedIds = new List<string>();
        
        for (int i = 0; i < id_list.Length; i++)
        {
            //신고된 아이디를 key 값으로 하는 reportData에서 아이디를 key 값으로 하는 값이 있는지 확인
            if (reportData.TryGetValue(id_list[i], out var reportContent))
            {
                Console.WriteLine();
                //아이디의 신고 횟수에 따라 정지 되었는지 여부를 판단
                //정지된 아이디를 bannedIds에 추가
                if(reportContent.Item2 >= k)
                    bannedIds.Add(id_list[i]);
            }
        }
        
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        foreach (string bannedId in bannedIds)
        {
            if (reportData.TryGetValue(bannedId, out var value))
            {
                foreach (var userId in value.Item1)
                {
                    if (result.ContainsKey(userId))
                    {
                        result[userId]++;
                    }
                    else
                    {
                        result.Add(userId, 1);
                    }
                }
            }
        }
        
        for (int i = 0; i < id_list.Length; i++)
        {
            if (result.TryGetValue(id_list[i], out int value))
            {
                answer[i] =  value;
            }
            else
                answer[i] = 0;
        }

        return answer;
    }

    private static void CheckReportData(string userId, string reportId,
        ref Dictionary<string, Tuple<List<string>, int>> reportData)
    {
        //Console.WriteLine(userId);
        //Console.WriteLine(reportId);
        
        if (reportData.ContainsKey(reportId))
        {
            if (!reportData[reportId].Item1.Contains(userId))
            {
                var tempList = reportData[reportId].Item1;
                tempList.Add(userId);
                var tempValue = reportData[reportId].Item2;
                tempValue++;

                Console.WriteLine($"{userId} report {reportId}");
                Console.WriteLine($"{reportId} reported {tempValue} times");
                reportData[reportId] = new Tuple<List<string>, int>(tempList, tempValue);
            }
        }
        else
        {
            reportData.Add(reportId, new Tuple<List<string>, int>(new List<string>() { userId }, 1));
        }
    }
    
}