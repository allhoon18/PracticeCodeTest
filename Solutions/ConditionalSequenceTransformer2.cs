namespace PracticeCodeTest;

public class ConditionalSequenceTransformer2
{
    /*
     * 정수 배열 arr가 주어집니다.
     * arr의 각 원소에 대해 값이 50보다 크거나 같은 짝수라면 2로 나누고,
     * 50보다 작은 홀수라면 2를 곱하고 다시 1을 더합니다.
     *
     * 이러한 작업을 x번 반복한 결과인 배열을 arr(x)라고 표현했을 때,
     * arr(x) = arr(x + 1)인 x가 항상 존재합니다.
     * 이러한 x 중 가장 작은 값을 return 하는 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/181881

    public static int Solution(int[] arr)
    {
        int answer = 0;

        bool isChanged = false;

        do
        {
            arr = TransformArray(arr, out isChanged);
            answer++;
            
        } while (isChanged);

        return answer-1;
    }

    private static int[] TransformArray(int[] arr, out bool isChanged)
    {
        bool changed = false;
        isChanged = false;

        const int splitNumber = 50;

        arr = arr.Select(n =>
        {
            if (n % 2 == 0 && n >= splitNumber)
            {
                changed = true;
                return n / 2;
            }
            if (n % 2 == 1 && n < splitNumber)
            {
                changed = true;
                return (n * 2) + 1;
            }
            else
            {
                return n;
            }
        }).ToArray();

        isChanged = changed;

        return arr;
    }
}