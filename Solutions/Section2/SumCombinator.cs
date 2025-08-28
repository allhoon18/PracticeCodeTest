namespace PracticeCodeTest.Solutions;

public class SumCombinator
{
    /*
     * 정수 배열 numbers가 주어집니다.
     * numbers에서 서로 다른 인덱스에 있는 두 개의 수를 뽑아
     * 더해서 만들 수 있는 모든 수를 배열에
     * 오름차순으로 담아 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/68644

    public static int[] Solution(int[] numbers)
    {
        List<int> sums = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int sum = numbers[i] + numbers[j];
                
                if(!sums.Contains(sum))
                    sums.Add(sum);
            }
        }
        
        sums.Sort();
        
        return sums.ToArray();
    }
    
    public static int[] Solution2(int[] numbers)
    {
        HashSet<int> sums = new HashSet<int>();
        
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int sum = numbers[i] + numbers[j];
                
                sums.Add(sum);
            }
        }
        
        List<int> result = sums.ToList();
        result.Sort();
        
        return result.ToArray();
    }
}