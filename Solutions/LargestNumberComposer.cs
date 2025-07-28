namespace PracticeCodeTest.Solutions;

public class LargestNumberComposer
{
    /*
     * 0 또는 양의 정수가 주어졌을 때, 정수를 이어 붙여 만들 수 있는 가장 큰 수를 알아내 주세요.
     * 예를 들어, 주어진 정수가 [6, 10, 2]라면 [6102, 6210, 1062, 1026, 2610, 2106]를 만들 수 있고, 이중 가장 큰 수는 6210입니다.
     * 0 또는 양의 정수가 담긴 배열 numbers가 매개변수로 주어질 때,
     * 순서를 재배치하여 만들 수 있는 가장 큰 수를 문자열로 바꾸어 return 하도록 solution 함수를 작성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42746

    public static string Solution(int[] numbers)
    {
        Stack<string> sortedNums = new Stack<string>();
        Stack<string> stashedNums = new Stack<string>();

        foreach (int num in numbers)
        {
            if (sortedNums.Count == 0)
            {
                sortedNums.Push(num.ToString());
                continue;
            }

            while (TryPush(sortedNums.Peek(), num.ToString()))
            {
                stashedNums.Push(sortedNums.Pop());

                if (sortedNums.Count == 0)
                    break;
            }

            sortedNums.Push(num.ToString());

            while (stashedNums.Count > 0)
                sortedNums.Push(stashedNums.Pop());
        }

        var arr = sortedNums.Reverse().ToArray();

        string answer = "";
        foreach (var numStr in arr)
        {
            //Console.WriteLine(numStr);
            answer += numStr;
        }

        return answer;
    }

    private static bool TryPush(string topNumStr, string inputNumStr)
    {
        int length = topNumStr.Length > inputNumStr.Length ? inputNumStr.Length : topNumStr.Length;

        for (int i = 0; i < length; i++)
        {
            int topNum = int.Parse(topNumStr[i].ToString());
            int inputNum = int.Parse(inputNumStr[i].ToString());

            //각각의 자리수를 비교
            //첫째 자리부터 비교했을때 첫째자리가 가장 큰 숫자가 제일 앞에 옴
            //첫째 자리가 같을 경우 다음 자리수를 비교해 더 큰 숫자가 앞에 와야함
            //기존에 있는 숫자의 자리수가 더 크면 기존 스택에서 빼는 것을 멈추고 새로운 숫자를 추가
            if (topNum > inputNum)
                return false;
            //해당 자리수의 숫자가 같으면서 새로 추가하려는 숫자의 자리수가 더 작으면 기존 숫자를 빼고 추가
            if (topNum == inputNum && topNumStr.Length < inputNumStr.Length)
            {
                if (int.Parse(inputNumStr[i+1].ToString()) > 0)
                    return true;
                else
                    return false;
            }
        }

        return true;
    }
}