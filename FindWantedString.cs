namespace PracticeCodeTest;

public class FindWantedString
{
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