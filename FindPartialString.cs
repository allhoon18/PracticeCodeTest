using System.Numerics;

namespace PracticeCodeTest;

public class FindPartialString
{
    /*숫자로 이루어진 문자열 t와 p가 주어질 때,
     t에서 p와 길이가 같은 부분문자열 중에서,
     이 부분문자열이 나타내는 수가 p가 나타내는 수보다
     작거나 같은 것이 나오는 횟수를 return하는 함수 solution을 완성하세요.*/
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/147355

    public static int Solution(string t, string p)
    {
        int answer = 0;

        bool isLong = false;

        long patLong = 0;

        if (!int.TryParse(p, out var patInt))
            if(long.TryParse(p, out patLong)) isLong = true;
        
        for (int i = 0; i < t.Length; i++)
        {
            int checkIndex = i + p.Length-1;
            
            if(t.Length <= checkIndex) break;
            
            string partialT = t.Substring(i, p.Length);

            if (isLong)
            {
                if(long.TryParse(partialT, out var partialTValue))
                    if (partialTValue <= patLong) answer++;
            }
            else
            {
                if(long.TryParse(partialT, out var partialTValue))
                    if (partialTValue <= patInt) answer++;
            }
            
            
        }
        
        return answer;
    }
}