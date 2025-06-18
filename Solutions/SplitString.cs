namespace PracticeCodeTest;

public class SplitString
{
    /*
     * 문자열 s가 입력되었을 때 다음 규칙을 따라서 이 문자열을 여러 문자열로 분해하려고 합니다.
     * 먼저 첫 글자를 읽습니다. 이 글자를 x라고 합시다.
     * 이제 이 문자열을 왼쪽에서 오른쪽으로 읽어나가면서, x와 x가 아닌 다른 글자들이 나온 횟수를 각각 셉니다.
     * 처음으로 두 횟수가 같아지는 순간 멈추고, 지금까지 읽은 문자열을 분리합니다.
     * s에서 분리한 문자열을 빼고 남은 부분에 대해서 이 과정을 반복합니다. 남은 부분이 없다면 종료합니다.
     * 만약 두 횟수가 다른 상태에서 더 이상 읽을 글자가 없다면, 역시 지금까지 읽은 문자열을 분리하고, 종료합니다.
     * 문자열 s가 매개변수로 주어질 때, 위 과정과 같이 문자열들로 분해하고, 분해한 문자열의 개수를 return 하는 함수 solution을 완성하세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/140108
    
    public static int Solution(string s) {
        int answer = 1;

        CheckSplit(s, s[0], ref answer);
        
        return answer;
    }

    private static void CheckSplit(string s, char c, ref int answer)
    {
        int countSame = 0;
        int countDifferent = 0;

        int outPoint = 0;
        
        if(s.Length <= 1) return;
        
        for (int i = 0; i < s.Length; i++)
        {
            if(c == s[i]) countSame++;
            else countDifferent++;

            if (countSame == countDifferent)
            {
                if(s.Length == i+1) return;
                
                answer++;
                //Console.WriteLine(i+1);
                //Console.WriteLine(s.Substring(i+1));
                //Console.WriteLine(s[i+1]);
                outPoint = i + 1;
                break;
            }
        }
        
        if(outPoint != 0)
            CheckSplit(s.Substring(outPoint), s[outPoint], ref answer);
    }
}