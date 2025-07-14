namespace PracticeCodeTest.Solutions;

public class FibonacciCalculator
{
    /*
     * 피보나치 수는 F(0) = 0, F(1) = 1일 때, 1 이상의 n에 대하여 F(n) = F(n-1) + F(n-2) 가 적용되는 수 입니다.
     * 2 이상의 n이 입력되었을 때, n번째 피보나치 수를 1234567으로 나눈 나머지를 리턴하는 함수, solution을 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/12945
    
    private const int DIVISOR = 1234567;
    
    public static int Solution(int n)
    {
        int answer = 0;
        
        Dictionary<int, int> cache = new Dictionary<int, int>();
        
        cache.Add(0, 0);
        cache.Add(1, 1);
        
        long result = CalculateFibonacci(n, cache);
        
        return (int)result;
    }

    private static int CalculateFibonacci(int n, Dictionary<int, int> cache)
    {
        if (cache.ContainsKey(n))
        {
            return cache[n];
        }
        
        int fibNMinus1 = CalculateFibonacci(n-1, cache);
        int fibNMinus2 = CalculateFibonacci(n-2, cache);
        
        int currentFib = (fibNMinus1 + fibNMinus2) % DIVISOR;
        
        cache.Add(n, currentFib);
        
        return currentFib;
    }
}