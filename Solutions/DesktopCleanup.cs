namespace PracticeCodeTest;

public class DesktopCleanup
{
    /*
     * 컴퓨터 바탕화면의 상태를 나타낸 문자열 배열 wallpaper가 주어집니다.
     * 파일들은 바탕화면의 격자칸에 위치하고 바탕화면의 격자점들은
     *바탕화면의 가장 왼쪽 위를 (0, 0)으로 시작해 (세로 좌표, 가로 좌표)로 표현합니다.
     * 빈칸은 ".", 파일이 있는 칸은 "#"의 값을 가집니다.
     *
     * 드래그는 바탕화면의 격자점 S(lux, luy)를 마우스 왼쪽 버튼으로 클릭한 상태로 격자점 E(rdx, rdy)로 이동한 뒤 마우스 왼쪽 버튼을 떼는 행동입니다.
     * 이때, "점 S에서 점 E로 드래그한다"고 표현하고 점 S와 점 E를 각각 드래그의 시작점, 끝점이라고 표현합니다.
     * 점 S(lux, luy)에서 점 E(rdx, rdy)로 드래그를 할 때, "드래그 한 거리"는 |rdx - lux| + |rdy - luy|로 정의합니다.
     * 바탕화면의 파일들을 한 번에 삭제하기 위해 최소한의 이동거리를 갖는 드래그의 시작점과 끝점을 담은 정수 배열을 return 하는 Solution 함수 작성
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/161990

    public static int[] Solution(string[] wallpaper)
    {
        const int initialValue = -1;
        
        int smallestX = initialValue;
        int smallestY = initialValue;
        int largestX = initialValue;
        int largestY = initialValue;

        for (int i = 0; i < wallpaper.Length; i++)
        {
            for (int j = 0; j < wallpaper[i].Length; j++)
            {
                if (wallpaper[i][j] == '#')
                {
                    if (smallestX == initialValue || smallestX > j)
                        smallestX = j;
                    if(smallestY == initialValue || smallestY > i)
                        smallestY = i;
                    if(largestX == initialValue || largestX < j)
                        largestX = j;
                    if (largestY == initialValue || largestY < i)
                        largestY = i;
                }
            }
        }
        
        int[] answer = [smallestY, smallestX, largestY+1, largestX+1];
        return answer;
    }
}