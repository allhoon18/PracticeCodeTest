namespace PracticeCodeTest.Solutions;

public class DungeonExplorationOptimizer
{
    /*
     * XX게임에는 피로도 시스템(0 이상의 정수로 표현합니다)이 있으며,
     * 일정 피로도를 사용해서 던전을 탐험할 수 있습니다.
     * 이때, 각 던전마다 탐험을 시작하기 위해 필요한 "최소 필요 피로도"와
     * 던전 탐험을 마쳤을 때 소모되는 "소모 피로도"가 있습니다.
     * "최소 필요 피로도"는 해당 던전을 탐험하기 위해 가지고 있어야 하는 최소한의 피로도를 나타내며,
     * "소모 피로도"는 던전을 탐험한 후 소모되는 피로도를 나타냅니다.
     * 예를 들어 "최소 필요 피로도"가 80, "소모 피로도"가 20인 던전을 탐험하기 위해서는
     * 유저의 현재 남은 피로도는 80 이상 이어야 하며, 던전을 탐험한 후에는 피로도 20이 소모됩니다.
     *
     * 이 게임에는 하루에 한 번씩 탐험할 수 있는 던전이 여러 개 있는데,
     * 한 유저가 오늘 이 던전들을 최대한 많이 탐험하려 합니다.
     * 유저의 현재 피로도 k와 각 던전별 "최소 필요 피로도", "소모 피로도"가 담긴
     * 2차원 배열 dungeons 가 매개변수로 주어질 때,
     * 유저가 탐험할수 있는 최대 던전 수를 return 하도록 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/87946

    public static int Solution(int k, int[,] dungeons)
    {
        int length = dungeons.GetLength(0);
        int[][] orders = new int[][CalculateFactorial(length)];
        
        
        
        
        
        return 0;
    }

    private static int CalculateFactorial(int n)
    {
        int answer = 0;
        
        for (int i = 1; i <= n; i++)
        {
            answer += i;
        }
        
        return answer;
    }

    public static int Solution2(int k, int[,] dungeons)
    {
        List<Dungeon> dungeonList = new List<Dungeon>();

        for (int i = 0; i < dungeons.GetLength(0); i++)
        {
            dungeonList.Add(new Dungeon(dungeons[i, 0], dungeons[i, 1]));
        }
        
        List<Dungeon> sortedByRequired = dungeonList
            .OrderBy(d => d.RequiredFatigue)
            .Reverse()
            .ToList();

        for (int i = 0; i < sortedByRequired.Count; i++)
        {
            sortedByRequired[i].Priority += i;
        }
        
        List<Dungeon> sortedByConsumed = dungeonList
            .OrderBy(d => d.ConsumedFatigue)
            .ToList();
        
        for (int i = 0; i < sortedByConsumed.Count; i++)
        {
            sortedByConsumed[i].Priority += i;
        }
        
        List<Dungeon> sortedByPriority = dungeonList
            .OrderBy(d => d.Priority)
            .ThenBy(d => d.ConsumedFatigue)
            .ToList();

        int dungeonClearCount = 0;
        int currentFatigue = k;
        
        foreach (Dungeon d in sortedByPriority)
        {
            if (currentFatigue < d.RequiredFatigue)
                return dungeonClearCount;
            
            currentFatigue -= d.ConsumedFatigue;
            dungeonClearCount++;

        }
        
        return dungeonClearCount;
    }
}

class Dungeon
{
    public int RequiredFatigue;
    public int ConsumedFatigue;
    public int Priority;

    public Dungeon(int requiredFatigue, int consumedFatigue)
    {
        this.RequiredFatigue = requiredFatigue;
        this.ConsumedFatigue = consumedFatigue;
    }
}