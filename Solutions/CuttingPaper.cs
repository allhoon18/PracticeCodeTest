﻿namespace PracticeCodeTest.Solutions;

public class CuttingPaper
{
    /*
     * 이를 1 x 1 크기로 자르려고 합니다.
     * 예를 들어 2 x 2 크기의 종이를 1 x 1 크기로 자르려면 최소 가위질 세 번이 필요합니다.
     * 정수 M, N이 매개변수로 주어질 때,
     * M x N 크기의 종이를 최소로 가위질 해야하는 횟수를 return 하도록 solution 함수를 완성해보세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/120922
    
    public static int Solution(int M, int N) {
        int answer = 0;
        
        const int minSize = 1;

        if (M <= minSize && N <= minSize)
            return answer;

        answer = N - 1 + N * (M - 1);
        
        return answer;
    }

}