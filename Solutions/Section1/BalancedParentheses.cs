namespace PracticeCodeTest.Solutions;

public class BalancedParentheses
{
    /*
     * 괄호가 바르게 짝지어졌다는 것은 '(' 문자로 열렸으면 반드시 짝지어서 ')' 문자로 닫혀야 한다는 뜻입니다.
     * '(' 또는 ')' 로만 이루어진 문자열 s가 주어졌을 때,
     * 문자열 s가 올바른 괄호이면 true를 return 하고,
     * 올바르지 않은 괄호이면 false를 return 하는 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/12909

    public static bool Solution(string s)
    {
        int parenthesesOpenCount = 0;
        bool isOpen = false;
        
        const char open = '(';
        const char close = ')';

        foreach (char c in s)
        {
            if (c == open)
            {
                parenthesesOpenCount++;
                isOpen = true;
            }
            else if (c == close && isOpen)
            {
                parenthesesOpenCount--;
                
                if(parenthesesOpenCount == 0)
                    isOpen = false;
            }
            else if (c == close && !isOpen)
                return false;
                
        }
        
        return parenthesesOpenCount == 0;
    }
}