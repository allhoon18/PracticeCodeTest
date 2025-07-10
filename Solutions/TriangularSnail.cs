namespace PracticeCodeTest.Solutions;

public class TriangularSnail
{
    /*
     * 정수 n이 매개변수로 주어집니다.
     * 다음 그림과 같이 밑변의 길이와 높이가 n인 삼각형에서
     * 맨 위 꼭짓점부터 반시계 방향으로 달팽이 채우기를 진행한 후,
     * 첫 행부터 마지막 행까지 모두 순서대로 합친 새로운 배열을 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/68645

    public static int[] Solution(int n)
    {
        int length = 0;

        for (int i = n; i > 0; i--)
        {
            length += n;
        }
        
        int[] answer = new int[length];
        
        
        return answer;
    }
}