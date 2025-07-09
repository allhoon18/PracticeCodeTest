namespace PracticeCodeTest;

public class ConditionalSequenceTransformer1
{
    /*
     * 정수 배열 arr가 주어집니다.
     * arr의 각 원소에 대해 값이 50보다 크거나 같은 짝수라면 2로 나누고,
     * 50보다 작은 홀수라면 2를 곱합니다.
     * 그 결과인 정수 배열을 return 하는 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/181882

    public static int[] Solution(int[] arr)
    {
        const int splitNumber = 50;
        
        //arr = arr.Where(n => n % 2 == 0 && n >= splitNumber).Select(n => n / 2).ToArray();
        //arr = arr.Where(n => n % 2 == 1 && n < splitNumber).Select(n => n * 2).ToArray();
        
        arr = arr.Select(n => {
            if (n % 2 == 0 && n >= splitNumber)
            {
                return n / 2;
            }
            else if (n % 2 == 1 && n < splitNumber)
            {
                return n * 2;
            }
            else
            {
                return n;
            }
        }).ToArray();
        
        return arr;
    }
}