namespace PracticeCodeTest;

public class RepeatString
{
    /*
     * 문자열 str과 정수 n이 주어집니다.
     * str이 n번 반복된 문자열을 만들어 출력하는 코드를 작성해 보세요.
     * 입력 : string 5
     * 출력 : stringstringstringstringstring
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181950
    
    public static void Solution(string s, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(s);
        }
    }
}