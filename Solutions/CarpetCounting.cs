namespace PracticeCodeTest;

public class CarpetCounting
{
    /*
     * Leo는 카펫을 사러 갔다가 아래 그림과 같이 중앙에는 노란색으로 칠해져 있고 테두리 1줄은 갈색으로 칠해져 있는 격자 모양 카펫을 봤습니다.
     * Leo가 본 카펫에서 갈색 격자의 수 brown,
     * 노란색 격자의 수 yellow가 매개변수로 주어질 때
     * 카펫의 가로, 세로 크기를 순서대로 배열에 담아 return 하도록 solution 함수를 작성해주세요.
     * (카펫의 가로 길이는 세로 길이와 같거나, 세로 길이보다 깁니다.)
     */
    
    public static int[] Solution(int brown, int yellow) {
        //가로 크기, 세로 크기 순서
        int[] answer = new int[2];

        int width = 0;
        int height = 0;
        
        int sumOfArea = brown + yellow;
        
        //가로 세로 크기의 합 * 2 - 4 = brown 
        //가로 * 세로 = sumOfArea
        // 가로 = sumOfArea /세로
        // (height + sumOfArea / height) * 2 - 4 = brown
        // 2 * height + 2 * (sumOfArea / height) - 4 = brown
        // 2 * height ^ 2 + 2 * sumOfArea - 4 * height = brown * height
        // 2 * height ^ 2 - (brwon + 4) height + 2 * sumOfArea = 0
        
        height = CalculateHeight(sumOfArea, brown);
        
        if(height == -1)
            throw new Exception("Can not find correct height");
        
        width = CalculateWidth(sumOfArea, height);
        
        answer = [width, height];
        
        return answer;
    }

    private static int CalculateHeight(int sumOfArea, int brown)
    {
        // f(height) = A * height ^ 2 + B * height + C
        // A = 2
        // B = - (brwon + 4)
        // C = 2 * sumOfArea
        
        double discriminant = Math.Pow(4 + brown, 2) - (16 * sumOfArea);
        
        // 판별식이 음수이면 실근이 없으므로 유효한 해가 없습니다.
        if (discriminant < 0)
        {
            return -1; // 또는 예외 처리
        }
        
        double sqrtDiscriminant = Math.Sqrt(discriminant);
        
        double height1 = ((4 + brown) + sqrtDiscriminant) / 4.0;
        
        double height2 = ((4 + brown) - sqrtDiscriminant) / 4.0;
        
        if(height1 > height2)
            return (int)height2;
        else
            return (int)height1;
    }

    private static int CalculateWidth(int sumOfArea, int height)
    {
        return sumOfArea / height;
    } 
}