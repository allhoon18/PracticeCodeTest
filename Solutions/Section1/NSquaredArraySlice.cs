namespace PracticeCodeTest;

public class NSquaredArraySlice
{
    /*
     * 정수 n, left, right가 주어집니다. 다음 과정을 거쳐서 1차원 배열을 만들고자 합니다.
     * 1. n행 n열 크기의 비어있는 2차원 배열을 만듭니다.
     * 2. i = 1, 2, 3, ..., n에 대해서, 다음 과정을 반복합니다.
     * - 1행 1열부터 i행 i열까지의 영역 내의 모든 빈 칸을 숫자 i로 채웁니다.
     * 3. 1행, 2행, ..., n행을 잘라내어 모두 이어붙인 새로운 1차원 배열을 만듭니다.
     * 4. 새로운 1차원 배열을 arr이라 할 때, arr[left], arr[left+1], ..., arr[right]만 남기고 나머지는 지웁니다.
     *
     * 정수 n, left, right가 매개변수로 주어집니다. 주어진 과정대로 만들어진 1차원 배열을 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/87390

    public static int[] Solution(int n, long left, long right)
    {
        // int[] board = new int[n * n];
        //  for (int i = 0; i < n; i++)
        //  {
        //      for (int j = 0; j < n; j++)
        //      {
        //          if (j <= i)
        //          {
        //              board[n * i + j] = i + 1;
        //          }
        //          else
        //          {
        //              board[n * i + j] = j + 1;
        //          }
        //      }
        //  }

        int[] answer = new int[right - left + 1];

        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = FindNumberOnBoard(n, left + i);
        }

        return answer;
    }

    private static int FindNumberOnBoard(int n, long index)
    {
        //행과 열을 구함
        long row = (index / n) + 1;
        long col = (index % n) + 1;

        // 해당 위치의 숫자는 row와 col 중 더 큰 값
        return (int)Math.Max(row, col);
    }
}