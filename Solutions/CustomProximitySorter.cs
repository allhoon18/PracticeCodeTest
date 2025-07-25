namespace PracticeCodeTest.Solutions;

public class CustomProximitySorter
{
    /*
     * 정수 n을 기준으로 n과 가까운 수부터 정렬하려고 합니다.
     * 이때 n으로부터의 거리가 같다면 더 큰 수를 앞에 오도록 배치합니다.
     * 정수가 담긴 배열 numlist와 정수 n이 주어질 때 numlist의 원소를 n으로부터
     * 가까운 순서대로 정렬한 배열을 return하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/120880

    public static int[] Solution(int[] numlist, int n)
    {
        Stack<int> sortedNums = new Stack<int>();
        Stack<int> stashedNums = new Stack<int>();

        foreach (int num in numlist)
        {
            if (sortedNums.Count <= 0)
            {
                sortedNums.Push(num);
                continue;
            }
                
            //num이 sortedNums의 마지막 숫자보다 앞에 있어야 하는지 확인
            while (TryPush(sortedNums.Peek(), num, n))
            {
                //앞에 있어야 한다면 기존에 sortedNums에 있던 숫자를 제거
                stashedNums.Push(sortedNums.Pop());
                
                if (sortedNums.Count <= 0)
                    break;
            }
            
            sortedNums.Push(num);

            while (stashedNums.Count > 0)
            {
                sortedNums.Push(stashedNums.Pop());
            }
        }


        int[] answer = sortedNums.Reverse().ToArray();
        return answer;
    }

    private static bool TryPush(int topOfStack, int valueToPush, int standard)
    {
        //두 숫자를 비교해 기준 숫자에서 뺀 절대값이 두번째 숫자가 더 크다면 해당 위치에서 숫자를 추가
        if (Math.Abs(topOfStack - standard) < Math.Abs(valueToPush - standard))
            return false;
        //만약 두 숫자가 같다면
        else if (Math.Abs(topOfStack - standard) == Math.Abs(valueToPush - standard))
        {
            //값을 비교해 두번째 숫자가 더 크다면 해당 위치에서 숫자를 추가
            if (topOfStack > valueToPush)
                return false;
        }
        
        return true;
    }
}