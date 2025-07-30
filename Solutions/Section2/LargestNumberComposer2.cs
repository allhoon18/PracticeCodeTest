namespace PracticeCodeTest.Solutions;

public class LargestNumberComposer2
{
    public static string Solution(int[] numbers)
    {
        // 1. int 배열을 string 배열로 변환
        // 예: [6, 10, 2] -> ["6", "10", "2"]
        string[] strNumbers = numbers.Select(n => n.ToString()).ToArray();

        // 2. 사용자 정의 비교자(Comparer)를 사용하여 정렬
        // Array.Sort는 기본적으로 오름차순 정렬을 수행하지만,
        // CustomNumberComparer는 가장 큰 수를 만들기 위한 특수한 "내림차순" 비교를 수행합니다.
        // 예를 들어 "10"과 "6"을 비교했을 때, "10"이 "6"보다 앞에 오도록 정렬됩니다.
        Array.Sort(strNumbers, new CustomNumberComparer());

        // 3. 엣지 케이스 처리: 모든 숫자가 0인 경우 ("0", "0", "0" -> "0")
        // 정렬 결과의 첫 번째 요소가 "0"이면, 모든 원소가 0이거나 (예: [0, 0, 0] -> ["0", "0", "0"])
        // 가장 큰 수가 0이라는 의미이므로, 최종 결과를 "0"으로 반환합니다.
        if (strNumbers[0] == "0")
        {
            return "0";
        }

        // 4. 정렬된 문자열들을 이어붙여서 최종 결과 반환
        // string.Join은 배열의 요소들을 특정 구분자 없이 하나의 문자열로 합쳐줍니다.
        return string.Join("", strNumbers);
    }
}

// 사용자 정의 비교자 클래스
// IComparer<string> 인터페이스를 구현하여 Array.Sort 등에서 사용될 수 있습니다.
public class CustomNumberComparer : IComparer<string>
{
    /// <summary>
    /// 두 문자열 x와 y를 비교하여 어떤 순서로 정렬될지 결정합니다.
    /// 이 비교자는 "x가 y보다 앞에 오면 -1", "같으면 0", "y가 x보다 앞에 오면 1"을 반환합니다.
    /// </summary>
    /// <returns>
    /// -1: x가 y보다 앞에 와야 함 (x + y가 y + x 보다 크거나 같음)
    ///  1: y가 x보다 앞에 와야 함 (y + x가 x + y 보다 큼)
    ///  0: x와 y의 순서가 같아도 무방 (y + x와 x + y가 동일)
    /// </returns>
    public int Compare(string x, string y)
    {
        // 핵심 비교 로직: (y+x)와 (x+y)를 비교합니다.
        // 예를 들어, x="6", y="10"
        // y + x = "10" + "6" = "106"
        // x + y = "6" + "10" = "610"
        // string.Compare("106", "610")은 "106"이 사전적으로 "610"보다 앞에 오므로, 음수(-1)를 반환합니다.
        // Array.Sort는 기본적으로 Compare 결과가 음수이면 x를 y보다 앞에 둡니다.
        // 즉, "10"이 "6"보다 앞에 오게 정렬됩니다. (올바른 순서)

        // 예를 들어, x="3", y="30"
        // y + x = "30" + "3" = "303"
        // x + y = "3" + "30" = "330"
        // string.Compare("303", "330")은 "303"이 사전적으로 "330"보다 앞에 오므로, 음수(-1)를 반환합니다.
        // 즉, "30"이 "3"보다 앞에 오게 정렬됩니다. (올바른 순서)
        
        // 최종적으로 String.Compare(y+x, x+y)를 반환하면
        // y+x가 더 크면 양수 반환 -> y가 x보다 앞에 온다.
        // x+y가 더 크면 음수 반환 -> x가 y보다 앞에 온다.
        // 이 Comparator는 가장 큰 수가 되도록 정렬합니다.
        return string.Compare(y + x, x + y);
    }
}