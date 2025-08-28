namespace PracticeCodeTest.Solutions;

public class MissileInterceptor
{
    /*
     * A 나라와 B 나라가 싸우고 있는 이 세계는 2 차원 공간으로 이루어져 있습니다.
     * A 나라가 발사한 폭격 미사일은 x 축에 평행한 직선 형태의 모양이며 개구간을 나타내는 정수 쌍 (s, e) 형태로 표현됩니다.
     * B 나라는 특정 x 좌표에서 y 축에 수평이 되도록 미사일을 발사하며,
     * 발사된 미사일은 해당 x 좌표에 걸쳐있는 모든 폭격 미사일을 관통하여 한 번에 요격할 수 있습니다.
     * 단, 개구간 (s, e)로 표현되는 폭격 미사일은 s와 e에서 발사하는 요격 미사일로는 요격할 수 없습니다.
     * 요격 미사일은 실수인 x 좌표에서도 발사할 수 있습니다.
     * 각 폭격 미사일의 x 좌표 범위 목록 targets이 매개변수로 주어질 때,
     * 모든 폭격 미사일을 요격하기 위해 필요한 요격 미사일 수의 최솟값을 return 하도록 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/181188

    public static int Solution(int[,] targets)
    {
        List<Missile> missiles = new List<Missile>();
        
        //입력된 미사일 제원 초기화
        for (int i = 0; i < targets.GetLength(0); i++)
        {
            Missile newMissile = new Missile(targets[i, 0], targets[i, 1]);
            missiles.Add(newMissile);
        }
        
        //요격 시도 횟수를 카운팅
        int tryCount = 0;
        //미사일을 끝나는 지점이 빠른 순서로 정렬
        missiles = missiles.OrderBy(m => m.End).ThenBy(m => m.Start).ToList();
        //이전에 요격을 시도한 지점을 저장
        int lastShootPoint = int.MinValue;

        foreach (var missile in missiles)
        {
            //현재 미사일의 시작 위치가 이전에 요격을 시도한 지점보다 크거나 같다면
            // = 이전 요격 위치로는 현재 미사일의 구간을 커버할 수 없음
            if (missile.Start >= lastShootPoint)
            {
                tryCount++; // 새로운 요격기 필요
                lastShootPoint = missile.End;
            }
        }

        return tryCount;
    }
}

class Missile
{
    public readonly int Start;
    public readonly int End;

    public Missile(int start, int end)
    {
        Start = start;
        End = end;
    }
}