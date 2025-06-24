namespace PracticeCodeTest;

public class TriangleCondition
{
    /*
     * 선분 세 개로 삼각형을 만들기 위해서는 다음과 같은 조건을 만족해야 합니다.
     * - 가장 긴 변의 길이는 다른 두 변의 길이의 합보다 작아야 합니다.
     * 삼각형의 세 변의 길이가 담긴 배열 sides이 매개변수로 주어집니다.
     * 세 변으로 삼각형을 만들 수 있다면 1, 만들 수 없다면 2를 return하도록 solution 함수를 완성해주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/120889
    
    public static int Solution(int[] sides) {
        int answer = 0;
        
        int longestSide = 0;
        int sidesSum = 0;

        foreach (int side in sides)
        {
            if (side > longestSide)
                longestSide = side;
            
            sidesSum += side;
        }
        
        //전체 합에서 가장 긴 변의 길이를 뺀 값 = 나머지 두 변의 합
        //나머지 두 변의 길이의 합보다 가장 긴 변의 길이가 작을 때 삼각형이 만들어질 수 있음
        if (sidesSum - longestSide > longestSide)
            answer = 1;
        else
            answer = 2;
        
        
        return answer;
    }
}