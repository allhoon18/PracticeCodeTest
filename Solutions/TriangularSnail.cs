namespace PracticeCodeTest.Solutions;

public class TriangularSnail
{
    /*
     * 정수 n이 매개변수로 주어집니다.
     * 다음 그림과 같이 밑변의 길이와 높이가 n인 삼각형에서
     * 맨 위 꼭짓점부터 반시계 방향으로 달팽이 채우기를 진행한 후,
     * 첫 행부터 마지막 행까지 모두 순서대로 합친 새로운 배열을 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/68645

    enum Direction
    {
        Down,
        Right,
        Up,
    }

    public static int[] Solution(int n)
    {
        int totalCellSize = n * (n + 1) / 2;

        int[] answer = new int[totalCellSize];
        

        int[][] triangle = new int[n][];
        for (int i = 0; i < n; i++)
        {
            triangle[i] = new int[i + 1];
        }

        int row = -1; //현재 행
        int col = 0; //현재 열
        int num = 1; //이번에 칸에 넣을 숫자

        Direction currentDirection = Direction.Down;

        while (num <= totalCellSize)
        {
            currentDirection = ChooseDirection(row, col, triangle, currentDirection);

            switch (currentDirection)
            {
                case Direction.Down:
                    row++;
                    break;
                case Direction.Right:
                    col++;
                    break;
                case Direction.Up:
                    row--;
                    col--;
                    break;
            }

            triangle[row][col] = num;
            
            num++;
        }

        int idx = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < triangle[i].Length ; j++)
            {
                answer[idx] = triangle[i][j];
                idx++;
            }
        }

        return answer;
    }

    private static Direction ChooseDirection(int row, int col, int[][] triangle, Direction lastDirection)
    {
        if (lastDirection == Direction.Up && triangle[row - 1][col - 1] == 0)
            return Direction.Up;
        if (row + 1 < triangle.Length && triangle[row + 1][col] == 0)
            return Direction.Down;
        if (col + 1 < triangle[row].Length && triangle[row][col + 1] == 0)
            return Direction.Right;
        else
            return Direction.Up;
    }
}