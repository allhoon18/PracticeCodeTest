﻿namespace PracticeCodeTest;

public class StringConditionChecker
{
    /*
     * 문자열에 따라 다음과 같이 두 수의 크기를 비교하려고 합니다.
     * 두 수가 n과 m이라면
     * ">", "=" : n >= m
     * "<", "=" : n <= m
     * ">", "!" : n > m
     * "<", "!" : n < m
     * 두 문자열 ineq와 eq가 주어집니다.
     * ineq는 "<"와 ">"중 하나고, eq는 "="와 "!"중 하나입니다.
     * 그리고 두 정수 n과 m이 주어질 때,
     * n과 m이 ineq와 eq의 조건에 맞으면 1을 아니면 0을 return하도록 solution 함수를 완성해주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181934
    
    public static int Solution(string ineq, string eq, int n, int m) {
        int answer = 0;

        switch (ineq)
        {
            case "<":
                switch (eq)
                {
                    case "=":
                        if (n <= m) return 1;
                        else return 0;
                    case "!":
                        if (n < m) return 1;
                        else return 0;
                }
                break;
            case ">":
                switch (eq)
                {
                    case "=":
                        if (n >= m) return 1;
                        else return 0;
                    case "!":
                        if (n > m) return 1;
                        else return 0;
                }
                break;
        }
        return answer;
    }
    
}