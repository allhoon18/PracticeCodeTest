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
    
    static int[] _diffs; // static으로 선언하여 SolvePuzzle 및 Check에서 직접 접근
    static int[] _times;
    static long _limit;
    static int _puzzleCount;

    public static int Solution(int[] diffs, int[] times, long limit)
    {
        _diffs = diffs;
        _times = times;
        _limit = limit;
        _puzzleCount = diffs.Length;

        const int maxvalue = 100000;
        
        int highLevel = maxvalue;
        int lowLevel = 0;
        int resultLevel = 0;

        while (lowLevel <= highLevel)
        {
            //가장 큰 숫자와 가장 작은 숫자의 평균을 레벨로 입력
            int level = lowLevel + (highLevel - lowLevel) / 2;
            //int level = (int)Math.Abs((highLevel + lowLevel) / 2f) ;
            
            bool isInLimit = Check(level);

            if (isInLimit)
            {
                resultLevel = level;
                highLevel = level - 1;
            }
            else
            {
                lowLevel = level + 1;
            }
        }

        return resultLevel;
    }
    
    private static bool Check(int level)
    {
        long totalTime = 0;
        long prevTime = 0; // SolvePuzzle 함수에서 필요

        for (int i = 0; i < _puzzleCount; i++)
        {
            totalTime += SolvePuzzle(level, _diffs[i], _times[i], prevTime);
            // 총 시간이 limit을 초과하면 더 이상 계산할 필요 없음 (성능 최적화)
            if (totalTime > _limit) 
            {
                return false;
            }
            prevTime = _times[i];
        }
        return totalTime <= _limit;
    }

    private static long SolvePuzzle(int level, int diff, int time, long prevTime)
    {
        if (diff <= level)
        {
            return time;
        }

        long solveTime = (diff - level) * (prevTime + time) + time;
        
        return solveTime;
    }
}