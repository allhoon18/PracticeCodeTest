﻿namespace PracticeCodeTest;

public class ArraySlicer
{
    /*
     * 정수 배열 arr와 query가 주어집니다.
     * query를 순회하면서 다음 작업을 반복합니다.
     * - 짝수 인덱스에서는 arr에서 query[i]번 인덱스를 제외하고 배열의 query[i]번 인덱스 뒷부분을 잘라서 버립니다.
     * - 홀수 인덱스에서는 arr에서 query[i]번 인덱스는 제외하고 배열의 query[i]번 인덱스 앞부분을 잘라서 버립니다.
     *
     * 위 작업을 마친 후 남은 arr의 부분 배열을 return 하는 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/181893

    public static int[] Solution(int[] arr, int[] query)
    {
        List<int> arrList = arr.ToList();
        
        for (int i = 0; i < query.Length; i++)
        {
            //짝수 인덱스일 경우
            if (i % 2 == 0)
            {
                //arrList = arrList.Slice(0, query[i]+1);
                arrList = SliceList(arrList,0,query[i]);
            }
            //홀수 인덱스일 경우
            else
            {
                //arrList = arrList.Slice(query[i],arrList.Count-query[i]);
                arrList = SliceList(arrList,query[i],arrList.Count-1);
            }
        }

        return arrList.ToArray();
    }

    private static List<int> SliceList(List<int> arrList, int start, int end)
    {
        List<int> result = new List<int>();

        for (int i = start; i <= end; i++)
        {
            result.Add(arrList[i]);
        }
        
        return result;
    }
}