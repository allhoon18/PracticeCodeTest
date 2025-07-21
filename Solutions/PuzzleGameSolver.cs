namespace PracticeCodeTest.Solutions;

public class PuzzleGameSolver
{
    /*
     * 당신은 순서대로 n개의 퍼즐을 제한 시간 내에 풀어야 하는 퍼즐 게임을 하고 있습니다.
     * 각 퍼즐은 난이도와 소요 시간이 정해져 있습니다.
     * 당신의 숙련도에 따라 퍼즐을 풀 때 틀리는 횟수가 바뀌게 됩니다.
     * 현재 퍼즐의 난이도를 diff, 현재 퍼즐의 소요 시간을 time_cur, 이전 퍼즐의 소요 시간을 time_prev, 당신의 숙련도를 level이라 하면,
     * 게임은 다음과 같이 진행됩니다.
     * 1. diff ≤ level이면 퍼즐을 틀리지 않고 time_cur만큼의 시간을 사용하여 해결합니다.
     * 2. diff > level이면, 퍼즐을 총 diff - level번 틀립니다.
     * 퍼즐을 틀릴 때마다, time_cur만큼의 시간을 사용하며,
     * 추가로 time_prev만큼의 시간을 사용해 이전 퍼즐을 다시 풀고 와야 합니다.
     * 이전 퍼즐을 다시 풀 때는 이전 퍼즐의 난이도에 상관없이 틀리지 않습니다.
     * diff - level번 틀린 이후에 다시 퍼즐을 풀면 time_cur만큼의 시간을 사용하여 퍼즐을 해결합니다.
     *
     * 퍼즐 게임에는 전체 제한 시간 limit가 정해져 있습니다.
     * 제한 시간 내에 퍼즐을 모두 해결하기 위한 숙련도의 최솟값을 구하려고 합니다.
     * (난이도, 소요 시간은 모두 양의 정수며, 숙련도도 양의 정수여야 합니다.)
     *
     * 퍼즐의 난이도를 순서대로 담은 1차원 정수 배열 diffs,
     * 퍼즐의 소요 시간을 순서대로 담은 1차원 정수 배열 times,
     * 전체 제한 시간 limit이 매개변수로 주어집니다.
     * 제한 시간 내에 퍼즐을 모두 해결하기 위한 숙련도의 최솟값을 정수로 return 하도록 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/340212

    public static int Solution(int[] diffs, int[] times, long limit)
    {
        long sumOfTimes;
        int puzzleCount = diffs.Length;
        List<int> levels = diffs.ToList();
        levels.Sort();
        
        int lastSuccessLevelIndex = levels.Count - 1;
        int firstFailLevelIndex = 0;
        
        int startLevel = levels[lastSuccessLevelIndex];
        
        int prevTime = 0;
        bool isInLimit = false;

        do
        {
            sumOfTimes = 0;
            startLevel = levels[lastSuccessLevelIndex];
            
            for (int i = 0; i < puzzleCount; i++)
            {
                sumOfTimes += SolvePuzzle(startLevel, diffs[i], times[i], prevTime);
                prevTime = times[i];
            }
            
            isInLimit = prevTime <= limit;
            //문제의 난이도를 정렬
            //난이도 중에서 최초로 실패하는 구간을 찾기
            //실패하는 구간을 반으로 나눠 해당 값으로 시간 측정
            //실패한다면 해당 값과 마지막 성공 값 사이의 반을 나눠 해당 연산 반복
            //성공한다면 해당 값과 최초 실패 값 사이 반을 나눠 해당 연산 반복

        } while (isInLimit);
        
        return startLevel + 1;
    }

    private static long SolvePuzzle(int level, int diff, int time, long prevTime)
    {
        long solveTime = 0;

        if (diff <= level)
        {
            return time;
        }

        solveTime += (diff - level) * (prevTime + time) + time;
        
        return solveTime;
    }
}