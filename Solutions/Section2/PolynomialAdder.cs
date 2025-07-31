namespace PracticeCodeTest.Solutions;

public class PolynomialAdder
{
    /*
     * 한 개 이상의 항의 합으로 이루어진 식을 다항식이라고 합니다.
     * 다항식을 계산할 때는 동류항끼리 계산해 정리합니다.
     * 덧셈으로 이루어진 다항식 polynomial이 매개변수로 주어질 때,
     * 동류항끼리 더한 결괏값을 문자열로 return 하도록 solution 함수를 완성해보세요.
     * 같은 식이라면 가장 짧은 수식을 return 합니다.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/120863

    const char X = 'x';
    const char PLUS = '+';

    static int _xCoefficient = 0;
    static int _constant = 0;

    public static string Solution(string polynomial)
    {
        _xCoefficient = 0;
        _constant = 0;
        
        var terms = polynomial.Split(PLUS);

        foreach (var term in terms)
        {
            ParseTerm(term);
        }

        string answer = "";

        if (_xCoefficient != 0)
        {
            answer = _xCoefficient == 1 ? "x" : $"{_xCoefficient}x";
            if (_constant != 0)
                answer += $" + {_constant}";
        }
        else
        {
            if (_constant != 0)
                answer += $"{_constant}";
        }
        
        return answer;
    }

    private static void ParseTerm(string term)
    {
        term = term.Replace(" ", "");

        if (term.Contains(X))
        {
            term = term.Replace(X.ToString(), "");
            if (term == "")
                _xCoefficient += 1;
            else
                _xCoefficient += int.Parse(term);
        }
        else
            _constant += int.Parse(term);
    }
}