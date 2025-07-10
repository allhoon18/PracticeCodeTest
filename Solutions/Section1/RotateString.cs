namespace PracticeCodeTest;

public class RotateString
{
    /*
     * 문자열 str이 주어집니다.
     * 문자열을 시계방향으로 90도 돌려서 아래 입출력 예와 같이 출력하는 코드를 작성해 보세요.
     * 입력 : abcde
     * 출력 :
     * a
     * b
     * c
     * d
     * e
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181945
    
    public static void Solution(string s)
    {
        foreach (char c in s)
        {
            Console.WriteLine(c);
        }
    }
}