namespace PracticeCodeTest.Solutions.Section1;

public class VideoPlayer
{
    /*
     * 당신은 동영상 재생기를 만들고 있습니다.
     * 당신의 동영상 재생기는 10초 전으로 이동, 10초 후로 이동, 오프닝 건너뛰기 3가지 기능을 지원합니다.
     * 각 기능이 수행하는 작업은 다음과 같습니다.
     * - 10초 전으로 이동: 사용자가 "prev" 명령을 입력할 경우 동영상의 재생 위치를 현재 위치에서 10초 전으로 이동합니다.
     *   현재 위치가 10초 미만인 경우 영상의 처음 위치로 이동합니다. 영상의 처음 위치는 0분 0초입니다.
     * - 10초 후로 이동: 사용자가 "next" 명령을 입력할 경우 동영상의 재생 위치를 현재 위치에서 10초 후로 이동합니다.
     *   동영상의 남은 시간이 10초 미만일 경우 영상의 마지막 위치로 이동합니다. 영상의 마지막 위치는 동영상의 길이와 같습니다.
     * - 오프닝 건너뛰기: 현재 재생 위치가 오프닝 구간(op_start ≤ 현재 재생 위치 ≤ op_end)인 경우 자동으로 오프닝이 끝나는 위치로 이동합니다.
     *
     * 동영상의 길이를 나타내는 문자열 video_len,
     * 기능이 수행되기 직전의 재생위치를 나타내는 문자열 pos,
     * 오프닝 시작 시각을 나타내는 문자열 op_start,
     * 오프닝이 끝나는 시각을 나타내는 문자열 op_end,
     * 사용자의 입력을 나타내는 1차원 문자열 배열 commands가 매개변수로 주어집니다.
     * 이때 사용자의 입력이 모두 끝난 후 동영상의 위치를 "mm:ss" 형식으로 return 하도록 solution 함수를 완성해 주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/340213
    
    /// <summary>
    /// 동영상 재생기 조작 함수
    /// </summary>
    /// <param name="video_len">전체 영상의 길이</param>
    /// <param name="pos">영상 재생 지점</param>
    /// <param name="op_start">오프닝 시작 지점</param>
    /// <param name="op_end">오프닝 종료 지점</param>
    /// <param name="commands">입력된 명령어</param>
    /// <returns>모든 명령을 처리한 후 동영상 재생 지점 반환</returns>
    public static string Solution(string video_len, string pos, string op_start, string op_end, string[] commands) {
        string answer = "";
        
        int videoTime = StrToTime(video_len);
        int currentTime = StrToTime(pos);
        int opStartTime = StrToTime(op_start);
        int opEndTime = StrToTime(op_end);

        foreach (string command in commands)
        {
            switch (command)
            {
                case "prev":
                    currentTime = CommandPrev(currentTime);
                    break;
                case "next":
                    currentTime = CommandNext(currentTime, videoTime);
                    break;
            }
            
            currentTime = currentTime <= opEndTime && currentTime >= opStartTime ?  opEndTime : currentTime;
        }

        return TimeToStr(currentTime);
    }

    private static int StrToTime(string str)
    {
        int min = int.Parse(str.Split(":")[0]);
        int sec = int.Parse(str.Split(":")[1]);
        
        return min * 60 + sec;
    }

    private static string TimeToStr(int time)
    {
        int min = time / 60;
        int sec = time % 60;
        return $"{min:D2}:{sec:D2}";
    }

    private static int CommandPrev(int currentTime)
    {
        currentTime = currentTime - 10 > 0 ? currentTime - 10 : 0;
        
        return currentTime;
    }

    private static int CommandNext(int currentTime, int videoLen)
    {
        currentTime = currentTime + 10 < videoLen ? currentTime + 10 : videoLen;
        return currentTime;
    } 
    
}