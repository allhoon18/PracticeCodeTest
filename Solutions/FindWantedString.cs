namespace PracticeCodeTest;

public class FindWantedString
{
    /*
     * 알파벳으로 이루어진 문자열 myString과 pat이 주어집니다.
     * myString의 연속된 부분 문자열 중 pat이 존재하면 1을 그렇지 않으면 0을 return 하는
     * solution 함수를 완성해 주세요.
     * (알파벳 대문자와 소문자는 구분하지 않습니다.)
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/181878
    
    public static int Solution1(string myString, string pat)
    {
        string lowMyString = myString.ToLower();
        string lowPat = pat.ToLower();
        int answer = 0;
        
        if (lowMyString.Contains(lowPat))
        {
            answer = 1;
        }
        
        return answer;
    }

    public static int Solution2(string myString, string pat)
    {
        string lowMyString = myString.ToLower();
        string lowPat = pat.ToLower();
        int answer = 0;
        bool isUnmatch = false;
        
        for (int i = 0; i < lowMyString.Length; i++)
        {
            for (int j = 0; j < lowPat.Length; j++)
            {
                if (myString.Length <= j + i)
                {
                    isUnmatch = true;
                    break;
                }
                
                if (lowMyString[i + j] != lowPat[j])
                {
                    isUnmatch = true;
                    break;
                }
            }
            
            if(!isUnmatch)
                return 1;
            
            isUnmatch = false;
        }
        
        return answer;
    }
    
    
}