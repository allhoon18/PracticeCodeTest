namespace PracticeCodeTest;

public class QuickSort
{
    public static int[] Sort(int[] array)
    {
        if (array == null || array.Length <= 1)
        {
            return array;
        }

        QuickSortRecursive(array, 0, array.Length - 1);
        
        return array;
    }

    private static void QuickSortRecursive(int[] array, int low, int high)
    {
        // 재귀 호출의 종료 조건: 부분 배열의 크기가 1 이하인 경우
        if (low >= high)
        {
            return;
        }

        // 1. 피벗 선택 및 분할 (Partition)
        // Partition 함수는 피벗을 선택하고 배열을 분할한 후, 피벗의 최종 인덱스를 반환합니다.
        int pivotIndex = Partition(array, low, high);

        // 2. 정복 (재귀 호출) - 다음 단계에서 구현
        // 피벗의 왼쪽 부분 배열 정렬
        QuickSortRecursive(array, low, pivotIndex - 1);
        // 피벗의 오른쪽 부분 배열 정렬
        QuickSortRecursive(array, pivotIndex + 1, high);
    }

    /// <summary>
    /// 배열의 특정 부분을 분할하고 피벗의 최종 위치를 반환합니다.
    /// </summary>
    /// <param name="array">정렬할 배열</param>
    /// <param name="low">현재 부분 배열의 시작 인덱스</param>
    /// <param name="high">현재 부분 배열의 끝 인덱스</param>
    /// <returns>피벗의 최종 인덱스</returns>
    private static int Partition(int[] array, int low, int high)
    {
        // 간단하게 배열의 마지막 요소를 피벗으로 선택합니다.
        int pivot = array[high];

        // i는 피벗보다 작은 요소들의 경계를 나타냅니다.
        // low-1로 초기화하여 아직 작은 요소가 없음을 나타냅니다.
        int i = (low - 1);

        // j는 low부터 high-1까지 배열을 순회합니다.
        for (int j = low; j < high; j++)
        {
            // 현재 요소(array[j])가 피벗보다 작거나 같으면
            if (array[j] <= pivot)
            {
                i++; // 작은 요소의 경계를 한 칸 늘리고
                // array[i]와 array[j]를 교환하여 작은 요소들을 왼쪽으로 모읍니다.
                Swap(array, i, j);
            }
        }

        // 루프가 끝나면 i+1 위치에 피벗을 놓습니다.
        // array[i+1]과 array[high] (피벗)를 교환합니다.
        Swap(array, i + 1, high);

        // 피벗의 최종 인덱스를 반환합니다.
        return i + 1;
    }

    /// <summary>
    /// 배열 내 두 요소의 위치를 교환하는 헬퍼 함수입니다.
    /// </summary>
    private static void Swap(int[] array, int idx1, int idx2)
    {
        int temp = array[idx1];
        array[idx1] = array[idx2];
        array[idx2] = temp;
    }
}