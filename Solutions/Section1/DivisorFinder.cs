﻿namespace PracticeCodeTest;

public class DivisorFinder
{
    /*
     * 정수 n이 매개변수로 주어질 때, n의 약수를
     * 오름차순으로 담은 배열을 return하도록 solution 함수를 완성해주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/120897
    
    public static int[] Solution(int n) 
    {
        List<int> divisors = new List<int>();

        for (int i = 1; i <= n; i++)
        {
            if(n % i == 0) divisors.Add(i);
        }
        
        int[] answer = divisors.ToArray();
        return answer;
    }
}