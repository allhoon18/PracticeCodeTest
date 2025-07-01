﻿namespace PracticeCodeTest;

public class KthNumber
{
    /*
     * 배열 array의 i번째 숫자부터 j번째 숫자까지 자르고 정렬했을 때, k번째에 있는 수를 구하려 합니다.
     * 예를 들어 array가 [1, 5, 2, 6, 3, 7, 4], i = 2, j = 5, k = 3이라면
     * array의 2번째부터 5번째까지 자르면 [5, 2, 6, 3]입니다.
     * 1에서 나온 배열을 정렬하면 [2, 3, 5, 6]입니다.
     * 2에서 나온 배열의 3번째 숫자는 5입니다.
     * 배열 array, [i, j, k]를 원소로 가진 2차원 배열 commands가 매개변수로 주어질 때,
     * commands의 모든 원소에 대해 앞서 설명한 연산을 적용했을 때 나온 결과를 배열에 담아 return 하도록 solution 함수를 작성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42748

    public static int[] Solution(int[] array, int[,] commands)
    {
        int commandsLength = commands.GetLength(0);
        
        int[][] answerSet = new int[commandsLength][];
        int[] answer = new int[commandsLength];
        for (int i = 0; i < commandsLength; i++)
        {
            int start = commands[i, 0];
            int end = commands[i, 1];
            int k = commands[i, 2];
            
            // Console.WriteLine("start : "+start);
            // Console.WriteLine("end : "+end);
            // Console.WriteLine("k : "+k);
            
            answerSet[i] = GetSubArray(array, start, end);
            answer[i] = answerSet[i][k-1];
        }
        
        return answer;
    }

    private static int[] GetSubArray(int[] array, int startIndex, int endIndex)
    {
        // startIndex와 endIndex는 1-based이므로, 0-based로 조정합니다.
        int actualStartIndex = startIndex - 1;
        int actualEndIndex = endIndex - 1;
    
        int length = actualEndIndex - actualStartIndex + 1;
        int[] subArray = new int[length];

        // Array.Copy를 사용하여 원본 array의 특정 부분을 subArray로 복사합니다.
        // 이렇게 하면 subArray는 원본 array와 독립적인 새로운 배열이 됩니다.
        Array.Copy(array, actualStartIndex, subArray, 0, length);
    
        // QuickSort.Sort는 이제 이 독립적인 subArray를 정렬합니다.
        int[] sortedSubArray = QuickSort.Sort(subArray);
    
        return sortedSubArray;
    }
}