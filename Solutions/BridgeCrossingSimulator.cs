namespace PracticeCodeTest.Solutions;

public class BridgeCrossingSimulator
{
    /*
     * 트럭 여러 대가 강을 가로지르는 일차선 다리를 정해진 순으로 건너려 합니다.
     * 모든 트럭이 다리를 건너려면 최소 몇 초가 걸리는지 알아내야 합니다.
     * 다리에는 트럭이 최대 bridge_length대 올라갈 수 있으며,
     * 다리는 weight 이하까지의 무게를 견딜 수 있습니다.
     * 단, 다리에 완전히 오르지 않은 트럭의 무게는 무시합니다.
     *
     * solution 함수의 매개변수로 다리에 올라갈 수 있는 트럭 수 bridge_length,
     * 다리가 견딜 수 있는 무게 weight, 트럭 별 무게 truck_weights가 주어집니다.
     * 이때 모든 트럭이 다리를 건너려면 최소 몇 초가 걸리는지 return 하도록 solution 함수를 완성하세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42583

    static int totalWeight = 0;
    static int truckCount = 0;

    public static int Solution(int bridge_length, int weight, int[] truck_weights)
    {
        Queue<int> waitingTrucks = new Queue<int>();

        foreach (int truck in truck_weights)
        {
            waitingTrucks.Enqueue(truck);
        }

        int waitingTime = 0;
        Queue<Truck> trucksOnBridge = new Queue<Truck>();

        Action onMove = () => { };

        do
        {
            waitingTime++;

            //현재 다리 위에 있는 트럭이 일괄적으로 이동
            onMove.Invoke();
            //트럭 중에서 다리를 벗어난 트럭은 제거
            if (trucksOnBridge.Count > 0 && trucksOnBridge.Peek().IsExit)
            {
                Truck exitTruck = trucksOnBridge.Dequeue();
                onMove -= exitTruck.Move;
            }

            if (waitingTrucks.Count > 0 && totalWeight + waitingTrucks.Peek() <= weight &&
                truckCount + 1 <= bridge_length)
            {
                int truckWeight = waitingTrucks.Dequeue();
                Truck newTruck = new Truck(bridge_length, truckWeight, Exit);
                trucksOnBridge.Enqueue(newTruck);
                
                onMove += newTruck.Move;
                totalWeight += truckWeight;
                truckCount++;
            }
        } while (waitingTrucks.Count > 0 || totalWeight > 0);

        return waitingTime;
    }

    private static void Exit(int weight)
    {
        totalWeight -= weight;
        truckCount--;
    }
}

class Truck
{
    int bridgeLength;
    int weight;
    private Action<int> onExit;
    public bool IsExit;

    public Truck(int bridge_length, int weight, Action<int> onExit)
    {
        this.bridgeLength = bridge_length;
        this.weight = weight;
        this.onExit = onExit;
    }

    public void Move()
    {
        bridgeLength--;

        if (bridgeLength == 0)
        {
            onExit(weight);
            IsExit = true;
        }
    }
}