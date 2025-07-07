namespace PracticeCodeTest;

public class GCDLCMCalculator
{
    /*
     * 두 수를 입력받아 두 수의 최대공약수와 최소공배수를 반환하는 함수,
     * Solution을 완성해 보세요.
     * (배열의 맨 앞에 최대공약수, 그다음 최소공배수를 넣어 반환)
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/12940
    
    public static int[] Solution(int n, int m) {
        
        int smallNum = n <= m ? n : m;
        int largeNum = n >= m ? n : m;

        int greatestCommonDivisor = 0;
        int leastCommonMultiple = 0;

        for (int i = smallNum; i > 1; i--)
        {
            if (n % i == 0 && m % i == 0)
            {
                greatestCommonDivisor = i;
                break;
            }
        }
        
        greatestCommonDivisor = greatestCommonDivisor == 0 ? 1 : greatestCommonDivisor;

        if (greatestCommonDivisor == smallNum)
        {
            leastCommonMultiple =  largeNum;
        }
        else
        {
            leastCommonMultiple = ((largeNum / greatestCommonDivisor)  * (smallNum / greatestCommonDivisor)) * greatestCommonDivisor;   
        }
        
        int[] answer = new int[] {greatestCommonDivisor, leastCommonMultiple};
        return answer;
    }
}