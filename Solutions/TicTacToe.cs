namespace PracticeCodeTest;

public class TicTacToe
{
    //틱택토 게임판의 정보를 담고 있는 문자열 배열 board가 매개변수로 주어질 때,
    //이 게임판이 규칙을 지켜서 틱택토를 진행했을 때
    //나올 수 있는 게임 상황이면 1을 아니라면 0을 return 하는 solution 함수를 작성해 주세요.
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/160585

    public static int Solution(string[] board)
    {
        int countO = 0;
        int countX = 0;

        bool winO = false;
        bool winX = false;
        
        //OX의 개수가 O가 더 많거나 같은지 체크
        CountOX(board, out countO, out countX);
        
        CheckGameEnd(board, out winO, out winX);
        
        if (countO < countX)
            return 0;
        
        if(countO > countX +1)
            return 0;
        
        if(winO && winX)
            return 0;

        if (winO && countO == countX)
            return 0;

        if (winX && countO > countX)
            return 0;
        
        return 1;
    }

    private static void CountOX(string[] board, out int countO, out int countX)
    {
        countO = 0;
        countX = 0;
        
        foreach (string s in board)
        {
            foreach (char c in s)
            {
                switch (c)
                {
                    case 'O':
                        countO++;
                        break;
                    case 'X':
                        countX++;
                        break;
                }
            }
        }

        Console.WriteLine(countO);
        Console.WriteLine(countX);
    }

    private static void CheckGameEnd(string[] board, out bool winO,  out bool winX)
    {
        winO = false;
        winX = false;

        // 승리 조건 검사 함수 (헬퍼 함수)
        bool CheckLine(char player, char c1, char c2, char c3)
        {
            return c1 == player && c2 == player && c3 == player;
        }

        // 1. 가로줄 검사 (3줄)
        for (int i = 0; i < 3; i++)
        {
            if (CheckLine('O', board[i][0], board[i][1], board[i][2])) winO = true;
            if (CheckLine('X', board[i][0], board[i][1], board[i][2])) winX = true;
        }

        // 2. 세로줄 검사 (3줄)
        for (int j = 0; j < 3; j++)
        {
            if (CheckLine('O', board[0][j], board[1][j], board[2][j])) winO = true;
            if (CheckLine('X', board[0][j], board[1][j], board[2][j])) winX = true;
        }

        // 3. 대각선 검사 (2줄)
        // 왼쪽 위 -> 오른쪽 아래
        if (CheckLine('O', board[0][0], board[1][1], board[2][2])) winO = true;
        if (CheckLine('X', board[0][0], board[1][1], board[2][2])) winX = true;

        // 오른쪽 위 -> 왼쪽 아래
        if (CheckLine('O', board[0][2], board[1][1], board[2][0])) winO = true;
        if (CheckLine('X', board[0][2], board[1][1], board[2][0])) winX = true;
    
        Console.WriteLine(winO); // 디버깅용
        Console.WriteLine(winX); // 디버깅용
    }
}