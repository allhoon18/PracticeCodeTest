namespace PracticeCodeTest.Solutions;

enum Direction
{
    Right,
    Left,
    Up,
    Down
}

public class ShortestPathFinder
{
    /*
     * ROR 게임은 두 팀으로 나누어서 진행하며, 상대 팀 진영을 먼저 파괴하면 이기는 게임입니다.
     * 따라서, 각 팀은 상대 팀 진영에 최대한 빨리 도착하는 것이 유리합니다.
     *
     * 게임 맵의 상태 maps가 매개변수로 주어질 때, 캐릭터가 상대 팀 진영에 도착하기 위해서
     * 지나가야 하는 칸의 개수의 최솟값을 return 하도록 solution 함수를 완성해주세요.
     * 단, 상대 팀 진영에 도착할 수 없을 때는 -1을 return 해주세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/1844

    public static int Solution(int[,] maps)
    {
        int answer = -1;

        const int way = 1;

        int maxX = maps.GetLength(0);
        int maxY = maps.GetLength(1);

        Tuple<int, int> endPoint = new Tuple<int, int>(maxX - 1, maxY - 1);
        int posX = 0;
        int posY = 0;
        //여러 방향이 진행가능할 때, 해당 위치를 Queue에 저장
        Queue<Crossroad> queue = new Queue<Crossroad>();
        Dictionary<Direction, Tuple<int, int>> dirDict =
            new()
            {
                { Direction.Right, new Tuple<int, int>(1, 0) },
                { Direction.Left, new Tuple<int, int>(-1, 0) },
                { Direction.Up, new Tuple<int, int>(0, 1) },
                { Direction.Down, new Tuple<int, int>(0, -1) }
            };

        Direction prevDir = Direction.Up;

        while (true)
        {
            if (posX == endPoint.Item1 && posY == endPoint.Item2)
                break;
            Queue<Direction> possibleDirections = new Queue<Direction>();

            if (posX + 1 < maxX && maps[posX + 1, posY] == way && prevDir != Direction.Left)
                possibleDirections.Enqueue(Direction.Right);
            if (posX - 1 > 0 && maps[posX - 1, posY] == way && prevDir != Direction.Right)
                possibleDirections.Enqueue(Direction.Left);
            if (posY + 1 < maxY && maps[posX, posY + 1] == way && prevDir != Direction.Down)
                possibleDirections.Enqueue(Direction.Up);
            if (posY - 1 > 0 && maps[posX, posY - 1] == way && prevDir != Direction.Left)
                possibleDirections.Enqueue(Direction.Down);

            Direction choosedDir = possibleDirections.Dequeue();

            if (possibleDirections.Count > 0)
            {
                queue.Enqueue(new Crossroad(posX, posY, prevDir, possibleDirections));
            }
            else
            {
                //갈 수 있는 방향이 없음을 의미
                if (queue.Count == 0)
                    break;
                else
                {
                    Crossroad crossroad = queue.Dequeue();
                    posX = crossroad.Position.Item1;
                    posY = crossroad.Position.Item2;
                }
            }

            posX = posX + dirDict[choosedDir].Item1;
            posY = posY + dirDict[choosedDir].Item2;
            prevDir = choosedDir;
        }

        return answer;
    }
}

class Crossroad
{
    public Tuple<int, int> Position;
    public Direction PrevDirection;
    public Queue<Direction> PossibleDirections;

    public Crossroad(int x, int y, Direction prevDirection, Queue<Direction> directions)
    {
        Position = new Tuple<int, int>(x, y);
        PrevDirection = prevDirection;
        PossibleDirections = directions;
    }
}