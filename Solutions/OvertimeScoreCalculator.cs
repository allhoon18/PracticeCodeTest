namespace PracticeCodeTest;

public class OvertimeScoreCalculator
{
    /*
     * 야근 피로도는 야근을 시작한 시점에서 남은 일의 작업량을 제곱하여 더한 값
     * N시간 동안 야근 피로도를 최소화하도록 하고자 할 때
     * 1시간 동안 작업량 1만큼을 처리할 수 있다고 할 때,
     * 퇴근까지 남은 N 시간과 각 일에 대한 작업량 works에 대해
     * 야근 피로도를 최소화한 값을 리턴하는 함수 solution을 완성해주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/12927
    
    public static long Solution(int n, int[] works) {
        long answer = 0;
        
        List<int> worksList = works.ToList();
        worksList.Sort();

        for (int i = 0; i < n; i++)
        {
            int lastIndex = worksList.Count - 1;
            
            worksList[lastIndex] = worksList[lastIndex] > 0 ? worksList[lastIndex]-1 : 0;
            
            worksList.Sort();
        }

        foreach (int i in worksList)
        {
            answer += (long)Math.Pow(i, 2);
        }
        
        return answer;
    }
    
}