namespace PracticeCodeTest;

public class CaseConverter
{
    /*
     * 영어 알파벳으로 이루어진 문자열 str이 주어집니다.
     * 각 알파벳을 대문자는 소문자로 소문자는 대문자로 변환해서 출력하는 코드를 작성해 보세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181949

    public static string Solution(string s)
    {
        string answer = string.Empty;

        foreach (char c in s)
        {
            answer += Char.IsUpper(c)? c.ToString().ToLower() : c.ToString().ToUpper();
            
            // switch (Char.IsUpper(c))
            // {
            //     case true:
            //         answer += c.ToString().ToLower();
            //         break;
            //     case false:
            //         answer += c.ToString().ToUpper();
            //         break;
            // }
        }

        return answer;
    }
}