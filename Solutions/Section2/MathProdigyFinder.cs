namespace PracticeCodeTest.Solutions;

public class MathProdigyFinder
{
    /*
     * 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다.
     * 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.
     *
     * 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
     * 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
     * 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...
     *
     * 1번 문제부터 마지막 문제까지의 정답이 순서대로 들은 배열 answers가 주어졌을 때,
     * 가장 많은 문제를 맞힌 사람이 누구인지 배열에 담아 return 하도록 solution 함수를 작성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42840

    public static int[] Solution(int[] answers)
    {
        int[] pattern1 = new int[] { 1, 2, 3, 4, 5};
        int[] pattern2 = new int[] { 2, 1, 2, 3, 2, 4, 2, 5};
        int[] pattern3 = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5};
        
        var scores = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(1, SolveProblem(pattern1, answers)),
            new Tuple<int, int>(2, SolveProblem(pattern2, answers)),
            new Tuple<int, int>(3, SolveProblem(pattern3, answers))
        };

        int maxScore = scores.Max(s => s.Item2);

        return scores.Where(s => s.Item2 == maxScore) // 최고 점수와 같은 수포자들만 선택
            .OrderBy(s => s.Item1) // ID를 기준으로 오름차순 정렬
            .Select(s => s.Item1) // ID만 추출
            .ToArray(); // 배열로 변환
    }

    private static int SolveProblem(int[] method, int[] answers)
    {
        int count = 0;

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == method[i % method.Length])
                count++;
        }

        return count;
    }
}