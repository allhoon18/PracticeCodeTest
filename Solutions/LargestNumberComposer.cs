namespace PracticeCodeTest.Solutions;

public class LargestNumberComposer
{
    /*
     * 0 또는 양의 정수가 주어졌을 때, 정수를 이어 붙여 만들 수 있는 가장 큰 수를 알아내 주세요.
     * 예를 들어, 주어진 정수가 [6, 10, 2]라면 [6102, 6210, 1062, 1026, 2610, 2106]를 만들 수 있고,
     * 이중 가장 큰 수는 6210입니다.
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
                if (int.Parse(inputNumStr[i+1].ToString()) > topNum)
                    return true;
                else
                    return false;
            }
        }
        
        return true;
        
        // String.Compare를 사용하여 A+B와 B+A를 비교합니다.
        // 비교는 int.Parse()를 하지 않고 문자열 자체로 붙여서 하는 것이 중요합니다.
        // 예를 들어 "9"와 "90"이 있다면, "990" vs "909" 이므로 "9"가 먼저 옵니다.
        // 0의 경우도 마찬가지입니다. [0,0,0] -> "000" 이므로 결과가 "0"
        string str1 = topNumStr + inputNumStr; // 기존 숫자 + 새 숫자
        string str2 = inputNumStr + topNumStr; // 새 숫자 + 기존 숫자

        // str2가 str1보다 크면 (새 숫자를 먼저 붙인게 더 크면) true를 반환
        // 즉, 새 숫자를 topNumStr(기존 스택에 있던 값)보다 앞에 위치해야 함
        // 이것은 Push() 함수와는 반대 개념으로 작동합니다.
        // 만약 `sortedNums.Push(num.ToString());` 이 최종 결과의 뒤에서부터 쌓인다고 생각하면,
        // (A + B).CompareTo(B + A) < 0 일때, B가 앞에 와야 한다고 봐야 합니다.
        // 이 `TryPush`는 `inputNumStr`가 `topNumStr`의 "앞"으로 들어가야 하는지를 결정하는 함수로 이해됩니다.
        // 그렇다면 `inputNumStr + topNumStr` (새 값 먼저)이 더 크면 `true`를 반환하여
        // 기존 스택 값을 Pop 하여 새 값이 삽입될 자리를 만들어야 합니다.

        //return string.Compare(str2, str1) > 0; // str2가 str1보다 크면 true
    }
}