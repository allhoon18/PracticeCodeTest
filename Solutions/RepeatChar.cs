namespace PracticeCodeTest;

public class RepeatChar
{
    /*
     * 문자열 my_string과 정수 n이 매개변수로 주어질 때,
     * my_string에 들어있는 각 문자를 n만큼 반복한 문자열을
     * return 하도록 solution 함수를 완성해보세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/120825

    public static string Solution(string my_string, int n)
    {
        string answer = string.Empty;

        foreach (var c in my_string)
        {
            for (int i = 0; i < n; i++)
            {
                answer += c;
            }
        }
        
        return answer;
    }
}