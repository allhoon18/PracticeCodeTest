namespace PracticeCodeTest;

public class PrimeNumberFinder
{
    /*
     * 1부터 입력받은 숫자 n 사이에 있는 소수의 개수를 반환하는 함수, solution을 만들어 보세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/12921
    
    public static int Solution(int n) {
        int answer = 0;

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i)) answer++;
        }
        
        return answer;
    }

    private static bool IsPrime(int n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0) return false;
        }
        
        return true;
    }
    
    
}