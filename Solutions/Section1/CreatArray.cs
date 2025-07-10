namespace PracticeCodeTest;

public class CreatArray
{
    /*
     * 정수 l과 r이 주어졌을 때, l 이상 r이하의 정수 중에서
     * 숫자 "0"과 "5"로만 이루어진 모든 정수를 오름차순으로 저장한 배열을 return 하는 solution 함수를 완성해 주세요.
     * 만약 그러한 정수가 없다면, -1이 담긴 배열을 return 합니다.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181921
    
    public static int[] Solution(int l, int r) {
        
        List<int> availableAnswers = new List<int>();

        for (int i = l; i <= r; i++)
        {
            string i_str = i.ToString();
            
            bool isAvailable = true;

            foreach (char c in i_str)
            {
                if (c != '0' && c != '5')
                {
                    isAvailable = false;
                    break;
                }
            }
            
            if(isAvailable)
                availableAnswers.Add(i);
        }
        
        int[] answer = availableAnswers.ToArray();

        if (answer.Length == 0)
        {
            answer = new int[] { -1 };
        }
        
        return answer;
    }
}