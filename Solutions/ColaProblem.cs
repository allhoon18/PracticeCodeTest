namespace PracticeCodeTest;

public class ColaProblem
{
    /*
     * 콜라 빈 병 2개를 가져다주면 콜라 1병을 주는 마트가 있다.
     * 빈 병 20개를 가져다주면 몇 병을 받을 수 있는가?
     * 단, 보유 중인 빈 병이 2개 미만이면, 콜라를 받을 수 없다.
     *
     * 해당 문제를 일반화하여
     * 콜라를 받기 위해 마트에 주어야 하는 병 수 a,
     * 빈 병 a개를 가져다 주면 마트가 주는 콜라 병 수 b,
     * 가지고 있는 빈 병의 개수 n이 매개변수로 주어집니다.
     * 받을 수 있는 콜라의 병 수를 return 하도록 solution 함수를 작성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/132267

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">콜라를 받기 위해 마트에 주어야 하는 병 수</param>
    /// <param name="b">빈 병 a개를 가져다 주면 마트가 주는 콜라 병 수</param>
    /// <param name="n">가지고 있는 빈 병의 개수</param>
    /// <returns></returns>
    public static int Solution(int a, int b, int n)
    {
        int answer = 0;

        ExchangeWithCola(a, b, n, ref answer);

        return answer;
    }

    /// <summary>
    /// 정해진 규칙 내에서 콜라를 교환하는 기능을 실행
    /// </summary>
    /// <param name="a">콜라를 받기 위해 마트에 주어야 하는 병 수</param>
    /// <param name="b">빈 병 a개를 가져다 주면 마트가 주는 콜라 병 수</param>
    /// <param name="n">가지고 있는 빈 병의 개수</param>
    /// <param name="answer">최종적으로 누적된 병의 개수</param>
    private static void ExchangeWithCola(int a, int b, int n, ref int answer)
    {
        if (n < a)
        {
            //Console.WriteLine("left : " + n);
            return;
        }
        
        int exchangedCola = n / a * b;

        int remainBottle = n / a * b + n % a;
        
        //정답에는 교환 받은 콜라의 개수의 합을 도출해야 하므로 
        //Console.WriteLine("Add Cola : " + exchangedCola);
        answer += exchangedCola;
        
        //다음 교환을 위한 빈 병의 개수에는 남은 콜라의 개수도 고려
        n = remainBottle;

        ExchangeWithCola(a, b, n, ref answer);
    }
}