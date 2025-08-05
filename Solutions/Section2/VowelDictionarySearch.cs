namespace PracticeCodeTest.Solutions;

public class VowelDictionarySearch
{
    /*
     * 사전에 알파벳 모음 'A', 'E', 'I', 'O', 'U'만을 사용하여 만들 수 있는, 길이 5 이하의 모든 단어가 수록되어 있습니다.
     * 사전에서 첫 번째 단어는 "A"이고, 그다음은 "AA"이며, 마지막 단어는 "UUUUU"입니다.
     *
     * 단어 하나 word가 매개변수로 주어질 때, 이 단어가 사전에서 몇 번째 단어인지 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/84512

    private static Dictionary<char, int> _vowelIndex = new Dictionary<char, int>()
    {
        { 'A', 0 },
        { 'E', 1 },
        { 'I', 2 },
        { 'O', 3 },
        { 'U', 4 },
    };

    private static int _length;

    public static int Solution(string word)
    {
        _length =  word.Length;
        
        int index = 0;

        for (int i = 0; i < _length; i++)
            index += AddCalculatedIndexContribution(word[i], i);
        
        return index;
    }

    private static int AddCalculatedIndexContribution(char c, int index)
    {
        int contribution = 0;
        
        index = _length - index - 1;

        for (int i = index; i >= 0; i--)
        {
            contribution += (int)Math.Pow(5, i);
        }
        
        contribution *= _vowelIndex[c];

        contribution++;
        
        return contribution;
    }
}