namespace PracticeCodeTest.Solutions;

public class RaceRankManager
{
    /*
     * 얀에서는 매년 달리기 경주가 열립니다. 해설진들은 선수들이 자기 바로 앞의 선수를 추월할 때 추월한 선수의 이름을 부릅니다.
     * 예를 들어 1등부터 3등까지 "mumu", "soe", "poe" 선수들이 순서대로 달리고 있을 때,
     * 해설진이 "soe"선수를 불렀다면 2등인 "soe" 선수가 1등인 "mumu" 선수를 추월했다는 것입니다.
     * 즉 "soe" 선수가 1등, "mumu" 선수가 2등으로 바뀝니다.
     *
     * 선수들의 이름이 1등부터 현재 등수 순서대로 담긴 문자열 배열 players와
     * 해설진이 부른 이름을 담은 문자열 배열 callings가 매개변수로 주어질 때,
     * 경주가 끝났을 때 선수들의 이름을 1등부터 등수 순서대로 배열에 담아 return 하는 solution 함수를 완성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/178871?language=csharp

    public static string[] Solution(string[] players, string[] callings)
    {
        Dictionary<string, Runner> runners = new Dictionary<string, Runner>();

        Runner? prevRunner = null;

        for (int i = 0; i < players.Length; i++)
        {
            Runner newRunner = new Runner(i, players[i], prevRunner);
            runners.Add(players[i], newRunner);

            if (i > 0)
            {
                prevRunner.SetRunnerBehind(newRunner);
            }
            
            prevRunner = newRunner;
                
        }

        foreach (var runnerName in callings)
        {
            runners[runnerName].SwapPositions();
        }
        
        string[] answer = runners.Values.OrderBy(r => r.Rank).Select(r => r.Name).ToArray();
        return answer;
    }
}

class Runner
{
    public int Rank;
    public readonly string Name;
    public Runner? RunnerAhead;
    public Runner? RunnerBehind;

    public Runner(int rank, string name, Runner? runnerAhead)
    {
        Rank = rank;
        Name = name;
        RunnerAhead = runnerAhead;
    }

    public void SetRunnerBehind(Runner? runner)
    {
        RunnerBehind = runner;
    }

    public void SwapPositions()
    {
        //자신의 랭크를 자신의 앞에 있던 주자의 랭크와 교체
        int tempRank = Rank;
        Rank = RunnerAhead.Rank;
        RunnerAhead.Rank = tempRank;
        
        //tempRunner = 원래 내 앞에 있던 주자
        Runner secondRunnerAhead = RunnerAhead.RunnerAhead;
        //원래 내 앞에 있던 주자의 앞에는 내가 있음
        RunnerAhead.RunnerAhead = this;
        //바로 뒤에 있던 주자의 앞에는 기존에 내 앞에 있던 주자가 위치
        if (RunnerBehind != null) 
            RunnerBehind.RunnerAhead = RunnerAhead;
        //원래 내 앞에 있던 주자가 내 바로 뒤에 있게 됨
        RunnerBehind = RunnerAhead;
        //앞에 앞에 있던 주자로 앞에 있는 주자를 갱신
        RunnerAhead = secondRunnerAhead;
    }
}