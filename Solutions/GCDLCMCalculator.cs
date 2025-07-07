namespace PracticeCodeTest;

public class GCDLCMCalculator
{
    public static int[] solution(int n, int m) {
        
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
            //Console.WriteLine(largeNum / greatestCommonDivisor);
            leastCommonMultiple = ((largeNum / greatestCommonDivisor)  * (smallNum / greatestCommonDivisor)) * greatestCommonDivisor;   
        }
        
        int[] answer = new int[] {greatestCommonDivisor, leastCommonMultiple};
        return answer;
    }
}