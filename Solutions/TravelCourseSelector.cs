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
    private const string _defaultStartPos = "ICN";

    public static string[] Solution(string[,] tickets)
    {
        for (int i = 0; i < tickets.GetLength(0); i++)
        {
            _ticketList.Add(new Ticket(tickets[i, 0], tickets[i, 1]));
        }
        
        Travel(_defaultStartPos, new List<string>());
        
        return _travelCourse.ToArray();
    }

    private static bool Travel(string currentPos, List<string> travelCourses)
    {
        if (travelCourses.Count >= _ticketList.Count)
        {
            travelCourses.Add(currentPos);
            _travelCourse = new List<string>(travelCourses);
            return true;
        }
        
        //이동한 장소 목록에 추가
        travelCourses.Add(currentPos);
        
        //현재 위치와 같은 시작 지점을 가진 티켓 리스트를 확보
        List<Ticket> possibleTicketList = _ticketList.Where( t 
            => t.StartPos == currentPos
            && !t.IsVisited).ToList();
        
        //길을 찾지 못했을 경우에 벗어남
        if (possibleTicketList.Count == 0)
            return false;
        
        //해당 리스트를 정렬
        possibleTicketList.Sort((t1,t2) => String.Compare(t1.ArrivalPos, t2.ArrivalPos, StringComparison.Ordinal));

        foreach (Ticket ticket in possibleTicketList)
        {
            ticket.IsVisited = true;
            //분기 되는 시점에서 새로운 리스트로 분리
            List<string> tempCourses = new List<string>(travelCourses);
            
            if(!Travel(ticket.ArrivalPos, tempCourses))
                ticket.IsVisited = false;
            else
                break;
        }
        
        return false;
    }
}

class Ticket
{
    public string StartPos { get; private set; }
    public string ArrivalPos { get; private set; }
    
    public bool IsVisited { get; set; }

    public Ticket(string startPos, string arrivalPos)
    {
        StartPos = startPos;
        ArrivalPos = arrivalPos;
    }
}