namespace PracticeCodeTest.Solutions;

public class ModeFinder
{
    /*
     * 최빈값은 주어진 값 중에서 가장 자주 나오는 값을 의미합니다.
     * 정수 배열 array가 매개변수로 주어질 때, 최빈값을 return 하도록 solution 함수를 완성해보세요.
     * 최빈값이 여러 개면 -1을 return 합니다.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/120812?language=csharp
    
    public static int Solution(int[] array)
    {
        Dictionary<int, int> modes = new Dictionary<int, int>();
        
        foreach (var value in array)
        {
            if (!modes.TryAdd(value, 1))
                modes[value]++;
        }
        
        int maxValue = modes.Values.Max();
        
        List<int> result = modes.Where(pair => pair.Value == maxValue).Select(pair => pair.Key).ToList();
        
        if (result.Count > 1)
            return -1;
        
        return result.First();
    }
}