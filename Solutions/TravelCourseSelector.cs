namespace PracticeCodeTest.Solutions;

public class TravelCourseSelector
{
    /*
     * 주어진 항공권을 모두 이용하여 여행경로를 짜려고 합니다. 항상 "ICN" 공항에서 출발합니다.
     * 항공권 정보가 담긴 2차원 배열 tickets가 매개변수로 주어질 때,
     * 방문하는 공항 경로를 배열에 담아 return 하도록 solution 함수를 작성해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/43164

    private static List<string> _travelCourse = new List<string>();
    private static List<Ticket> _ticketList = new List<Ticket>();
    private const string DEFAULT_START_POS = "ICN";

    public static string[] Solution(string[,] tickets)
    {
        for (int i = 0; i < tickets.GetLength(0); i++)
        {
            _ticketList.Add(new Ticket(tickets[i, 0], tickets[i, 1]));
        }
        
        Travel(DEFAULT_START_POS, new List<string>());
        
        return _travelCourse.ToArray();
    }

    private static bool Travel(string currentPos, List<string> travelCourses)
    {
        //최종 목적지를 입력하기 전에는 여행 경로와 전체 티켓의 길이가 동일하므로 종료 조건으로 사용
        if (travelCourses.Count >= _ticketList.Count)
        {
            //최종 위치를 추가
            travelCourses.Add(currentPos);
            _travelCourse = new List<string>(travelCourses);
            return true;
        }
        
        //이동한 장소 목록에 추가
        travelCourses.Add(currentPos);
        
        //현재 위치와 같은 시작 지점을 가진 티켓 리스트를 확보 = 사용 가능한 티켓 리스트를 확보
        List<Ticket> possibleTicketList = _ticketList.Where( t 
            => t.StartPos == currentPos
            && !t.IsUsed).ToList();
        
        //사용 가능한 티켓이 없을 경우 탐색을 종료
        if (possibleTicketList.Count == 0)
            //잘못된 탐색으로 처리하기 위해 false 반환
            return false;
        
        //사용 가능한 티켓 리스트를 알파벳 순으로 정렬
        possibleTicketList.Sort((t1,t2) => String.Compare(t1.ArrivalPos, t2.ArrivalPos, StringComparison.Ordinal));
        
        //순차적으로 티켓을 사용하며 경로를 탐색
        foreach (Ticket ticket in possibleTicketList)
        {
            //해당 티켓을 사용한 것으로 처리
            ticket.IsUsed = true;
            //분기 되는 시점에서 새로운 리스트로 분리
            //잘못된 탐색으로 false가 반환 될 경우 초기화를 위해
            List<string> tempCourses = new List<string>(travelCourses);
            
            if(!Travel(ticket.ArrivalPos, tempCourses))
                //백트래킹을 위해 방문 상태를 취소
                ticket.IsUsed = false;
            else
                return true;
        }
        
        return true;
    }
}

class Ticket
{
    public string StartPos { get; private set; }
    public string ArrivalPos { get; private set; }
    
    public bool IsUsed { get; set; }

    public Ticket(string startPos, string arrivalPos)
    {
        StartPos = startPos;
        ArrivalPos = arrivalPos;
    }
}