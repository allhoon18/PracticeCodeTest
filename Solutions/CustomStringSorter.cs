namespace PracticeCodeTest.Solutions;

public class CustomStringSorter
{
    /*
     * 문자열로 구성된 리스트 strings와, 정수 n이 주어졌을 때,
     * 각 문자열의 인덱스 n번째 글자를 기준으로 오름차순 정렬하려 합니다.
     * 예를 들어 strings가 ["sun", "bed", "car"]이고 n이 1이면
     * 각 단어의 인덱스 1의 문자 "u", "e", "a"로 strings를 정렬합니다.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/12915

    private static int _standardIndex;

    private static Dictionary<char, int> _alphabetIndex = new Dictionary<char, int>()
    {
        {'a', 1},
        {'b', 2},
        {'c', 3},
        {'d', 4},
        {'e', 5},
        {'f', 6},
        {'g', 7},
        {'h', 8},
        {'i', 9},
        {'j', 10},
        {'k', 11},
        {'l', 12},
        {'m', 13},
        {'n', 14},
        {'o', 15},
        {'p', 16},
        {'q', 17},
        {'r', 18},
        {'s', 19},
        {'t', 20},
        {'u', 21},
        {'v', 22},
        {'w', 23},
        {'x', 24},
        {'y', 25},
        {'z', 26}
    };
    
    public static string[] Solution(string[] strings, int n)
    {
        _standardIndex = n;
        
        Stack<string> sortedStrings = new Stack<string>();
        Stack<string> stashedStrings = new Stack<string>();

        foreach (var word in strings)
        {
            if (sortedStrings.Count == 0)
            {
                sortedStrings.Push(word);
                continue;
            }
            
            while (TryPush(sortedStrings.Peek(), word))
            {
                stashedStrings.Push(sortedStrings.Pop());

                if (sortedStrings.Count == 0)
                {
                    break;
                }
                    
            }
            
            sortedStrings.Push(word);

            while (stashedStrings.Count > 0)
            {
                sortedStrings.Push(stashedStrings.Pop());
            }
        }
        
        string[] answer = sortedStrings.Reverse().ToArray();
        return answer;
    }

    private static bool TryPush(string topWord, string inputWord)
    {
        //현재 스택의 가장 위에 있는 문자와 비교해 해당 문자의 기준문자가 추가하고자하는 문자의 기준문자보다
        //뒤에 있다면 기존 문자를 제거해야함
        if (_alphabetIndex[topWord[_standardIndex]] > _alphabetIndex[inputWord[_standardIndex]])
            return true;
        
        //만약 둘이 같다면 사전 순서로 정렬
        if(_alphabetIndex[topWord[_standardIndex]] == _alphabetIndex[inputWord[_standardIndex]])
        {
            //더 짧은 문자를 기준으로 비교
            int length = topWord.Length >= inputWord.Length ? inputWord.Length : topWord.Length;
            
            for (int i = 0; i < length; i++)
            {
                //기존 문자가 추가하고자 하는 문자보다 사전상에 뒤에 있다면 제거
                if(_alphabetIndex[topWord[i]] > _alphabetIndex[inputWord[i]])
                    return true;
                //만약 같다면 다음 문자를 검사
                if(_alphabetIndex[topWord[i]] == _alphabetIndex[inputWord[i]])
                    continue;
                //사전상 앞에 있다면 
                if (_alphabetIndex[topWord[i]] < _alphabetIndex[inputWord[i]])
                    return false;
            }
        }
        
        return false;
    }
}