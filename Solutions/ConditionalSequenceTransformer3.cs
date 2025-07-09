namespace PracticeCodeTest;

public class ConditionalSequenceTransformer3
{
    /*
     * 정수 배열 arr와 자연수 k가 주어집니다.
     * 만약 k가 홀수라면 arr의 모든 원소에 k를 곱하고, k가 짝수라면 arr의 모든 원소에 k를 더합니다.
     * 이러한 변환을 마친 후의 arr를 return 하는 solution 함수를 완성해 주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181835
    
    public static int[] Solution(int[] arr, int k) 
    {
        bool isOddNumber = k % 2 == 1;

        if (isOddNumber)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= k;
            }
        }
        else
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += k;
            }
        }
        
        //bool isOddNumber = k % 2 == 1;
        
        //return isOddNumber ? arr.Select(x => x * k).ToArray() : arr.Select(x => x + k).ToArray();
        
        return arr;
    }
    
}