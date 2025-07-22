namespace PracticeCodeTest.Solutions;

public class CollisionChecker
{
    /*
     * 어떤 물류 센터는 로봇을 이용한 자동 운송 시스템을 운영합니다. 운송 시스템이 작동하는 규칙은 다음과 같습니다.
     * 1. 물류 센터에는 (r, c)와 같이 2차원 좌표로 나타낼 수 있는 n개의 포인트가 존재합니다. 각 포인트는 1~n까지의 서로 다른 번호를 가집니다.
     * 2. 로봇마다 정해진 운송 경로가 존재합니다. 운송 경로는 m개의 포인트로 구성되고 로봇은 첫 포인트에서 시작해 할당된 포인트를 순서대로 방문합니다.
     * 3. 운송 시스템에 사용되는 로봇은 x대이고, 모든 로봇은 0초에 동시에 출발합니다.
     * 로봇은 1초마다 r 좌표와 c 좌표 중 하나가 1만큼 감소하거나 증가한 좌표로 이동할 수 있습니다.
     * 4. 다음 포인트로 이동할 때는 항상 최단 경로로 이동하며 최단 경로가 여러 가지일 경우, r 좌표가 변하는 이동을 c 좌표가 변하는 이동보다 먼저 합니다.
     * 5. 마지막 포인트에 도착한 로봇은 운송을 마치고 물류 센터를 벗어납니다. 로봇이 물류 센터를 벗어나는 경로는 고려하지 않습니다.
     *
     * 이동 중 같은 좌표에 로봇이 2대 이상 모인다면 충돌할 가능성이 있는 위험 상황으로 판단합니다.
     *  관리자인 당신은 현재 설정대로 로봇이 움직일 때 위험한 상황이 총 몇 번 일어나는지 알고 싶습니다.
     * 만약 어떤 시간에 여러 좌표에서 위험 상황이 발생한다면 그 횟수를 모두 더합니다.
     *
     * 운송 포인트 n개의 좌표를 담은 2차원 정수 배열 points와 로봇 x대의 운송 경로를 담은 2차원 정수 배열 routes가 매개변수로 주어집니다.
     * 이때 모든 로봇이 운송을 마칠 때까지 발생하는 위험한 상황의 횟수를 return 하도록 solution 함수를 완성해 주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/340211

    private static int arriveCount = 0;
    private static int collsionCount = 0;
    private static List<Robot> robots = new List<Robot>();
    private static Dictionary<Tuple<int,int>, int> map = new Dictionary<Tuple<int,int>, int>();
    private static Action onMove = () => { };

    public static int Solution(int[,] points, int[,] routes)
    {
        int robotCount = routes.GetLength(0);

        //이동할 로봇을 생성
        for (int i = 0; i < robotCount; i++)
        {
            int[] robotRoute = new int[routes.GetLength(1)];

            for (int j = 0; j < robotRoute.Length; j++)
            {
                robotRoute[j] = routes[i, j];
            }

            Robot tempRobot = new Robot(i, points, robotRoute, Arrive, map);
            onMove += tempRobot.Move;
            robots.Add(tempRobot);
        }
        
        CheckRobotCollision();

        while (arriveCount < robotCount)
        {
            //로봇 이동 처리
            onMove.Invoke();

            CheckRobotCollision();
        }

        return collsionCount;
    }

    private static void Arrive(int index)
    {
        arriveCount++;
        onMove -= robots[index].Move;
    }

    private static void CheckRobotCollision()
    {
        foreach (var count in map.Values)
        {
            if (count > 1)
            {
                collsionCount++;
            }
        }
    }
}

class Robot
{
    private int _index;
    private int[,] _points;
    private int[] _routes;
    private int _routeIndex = 0;
    private Tuple<int, int> _nextPos;

    private bool _isArrived = false;

    private static Dictionary<Tuple<int, int>, int> _map;

    public Tuple<int, int> CurrentPos { get; private set; }

    private Action<int> _onArrived;

    public Robot(int index, int[,] points, int[] routes, Action<int> onArrived, Dictionary<Tuple<int, int>, int> map)
    {
        _index = index;
        _points = points;
        _routes = routes;
        CurrentPos = new Tuple<int, int>(points[routes[_routeIndex] - 1, 0], points[routes[_routeIndex] - 1, 1]);
        SetNextPos();
        _onArrived = onArrived;
        _map = map;
        
        if (_map.ContainsKey(CurrentPos))
        {
            _map[CurrentPos]++;
        }
        else
        {
            _map.Add(CurrentPos, 1);
        }
    }

    private void SetNextPos()
    {
        _routeIndex++;

        if (_routeIndex == _routes.Length)
        {
            //마지막 지점에 도착한 것이므로 맵에서 제거
            if (_map.ContainsKey(CurrentPos))
            {
                _map[CurrentPos]--;
            }
            
            _isArrived = true;
            _onArrived.Invoke(_index);
            return;
        }

        _nextPos = new Tuple<int, int>(_points[_routes[_routeIndex] - 1, 0], _points[_routes[_routeIndex] - 1, 1]);
    }

    public void Move()
    {
        //기존에 있던 위치에서 벗어났으므로 제거
        if (_map.ContainsKey(CurrentPos))
        {
            _map[CurrentPos]--;
        }
        
        //r값을 먼저 이동
        if (CurrentPos.Item1 != _nextPos.Item1)
        {
            if (CurrentPos.Item1 < _nextPos.Item1)
                CurrentPos = new Tuple<int, int>(CurrentPos.Item1 + 1, CurrentPos.Item2);
            else
                CurrentPos = new Tuple<int, int>(CurrentPos.Item1 - 1, CurrentPos.Item2);
        }
        //r값이 맞춰진 후 c 값을 이동
        else if (CurrentPos.Item2 != _nextPos.Item2)
        {
            if (CurrentPos.Item2 < _nextPos.Item2)
                CurrentPos = new Tuple<int, int>(CurrentPos.Item1, CurrentPos.Item2 + 1);
            else
                CurrentPos = new Tuple<int, int>(CurrentPos.Item1, CurrentPos.Item2 - 1);
        }
        
        
        //새로운 위치에 위치했다는 것을 map에 전달
        if (_map.ContainsKey(CurrentPos))
        {
            _map[CurrentPos]++;
        }
        else
        {
            _map.Add(CurrentPos, 1);
        }
        
        //목적지에 도착했다면 다음 목적지를 탐색
        if (CurrentPos.Equals(_nextPos))
        {
            SetNextPos();
        }
        
    }
}