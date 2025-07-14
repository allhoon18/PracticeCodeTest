namespace PracticeCodeTest.Solutions.Section1;

public class StockPriceAnalyzer
{
    /*
     * 초 단위로 기록된 주식가격이 담긴 배열 prices가 매개변수로 주어질 때,
     * 가격이 떨어지지 않은 기간은 몇 초인지를 return 하도록 solution 함수를 완성하세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42584

    public static int[] Solution(int[] prices)
    {
        int[] answer = new int[prices.Length];

        for (int i = 0; i < prices.Length; i++)
        {
            int price = prices[i];
            int count = 0;

            for (int j = i + 1; j < prices.Length; j++)
            {
                count++;

                if (prices[j] < price)
                    break;
            }

            answer[i] = count;
        }

        return answer;
    }
}