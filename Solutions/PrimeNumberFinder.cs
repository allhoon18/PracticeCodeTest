namespace PracticeCodeTest;

public class PrimeNumberFinder
{
    /*
     * 1부터 입력받은 숫자 n 사이에 있는 소수의 개수를 반환하는 함수, solution을 만들어 보세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/12921
    
    public static int Solution(int n) {
        bool[] isPrime = new bool[n];
        
        for (var i = 2; i <= Math.Sqrt(n) + 1; i++)
        {
            CheckPrimeNumber(n,i, ref isPrime);
        }
        
        int answer = 0;

        foreach (var result in isPrime)
        {
            answer = result ? answer : answer+1;
        }
        
        return answer-1;
    }
    
    //성능적으로 소수를 찾는 과정에 대한 개선이 필요
    //2부터 n 범위의 모든 숫자를 추가한 리스트
    //첫번째 인덱스의 숫자에서부터 2 범위까지 전부 반복문을 돌며 해당 숫자를 나눌 수 있는 최소약수를 확인
    //해당 숫자부터 n 범위에서 해당 약수를 통해 나누어 떨어지는 모든 숫자를 리스트에서 제거
    //다음 인덱스의 숫자에 대해서 실행
    //해당 인덱스가 리스트의 마지막 숫자라면 검사를 종료
    private static bool IsPrime(int n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0) return false;
        }
        
        return true;
    }

    private static void CheckPrimeNumber(int n, int checkNumber, ref bool[] isPrime)
    {
        for (var i = 2; i <= n / checkNumber; i++)
        {
            int targetNumber = checkNumber * i;
            
            if (checkNumber * i <= isPrime.Length && !isPrime[targetNumber-1])
            {
                isPrime[targetNumber-1] = true;
                Console.WriteLine(targetNumber);
            }
                
        }
        
    }
    
    // private void LeavePrimeNumber(int n, int index, ref List<int> numbers)
    // {
    //
    //     int checkNumber = numbers[index];
    //     
    //     if(checkNumber >= Math.Sqrt(n))
    //         return;
    //     
    //     
    //     for (var i = 2; i <= n / checkNumber; i++)
    //     {            
    //         if(numbers.Contains(i * checkNumber))
    //             numbers.Remove(i * checkNumber);
    //     }
    //     
    //     int nextIndex = index + 1;
    //     
    //     LeavePrimeNumber(n, nextIndex, ref numbers);
    // }
    
    
}