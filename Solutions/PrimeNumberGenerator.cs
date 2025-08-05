namespace PracticeCodeTest.Solutions.Section2;

public class PrimeNumberGenerator
{
    /*
     * 한자리 숫자가 적힌 종이 조각이 흩어져있습니다.
     * 흩어진 종이 조각을 붙여 소수를 몇 개 만들 수 있는지 알아내려 합니다.
     * 각 종이 조각에 적힌 숫자가 적힌 문자열 numbers가 주어졌을 때,
     * 종이 조각으로 만들 수 있는 소수가 몇 개인지 return 하도록 solution 함수를 완성해주세요.
     */
    
    //https://school.programmers.co.kr/learn/courses/30/lessons/42839
    
    private static List<int> _numbersList = new List<int>();
    private static List<int> _primeNumberList = new List<int>();
    
    public static int Solution(string numbers) 
    {
        InitNumbersList(numbers);
        
        int maxNum = _numbersList.Max();
        
        InitPrimeNumberList(maxNum);
        
        return _numbersList.Intersect(_primeNumberList).Count();
    }

    private static void InitNumbersList(string numbers)
    {
        //순열을 구성할 숫자 전체 세트를 구성
        int[] numberSet = new int [numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numberSet[i] = int.Parse(numbers[i].ToString());
        }
        
        //이전에 조합에 사용된 숫자를 저장
        List<int> prevDigitNumbers = numberSet.ToList();
        
        //전체 자리수에 해당하는 숫자까지 전부 생성하도록 반복
        for (int i = 0; i < numbers.Length; i++)
        {
            //이번에 새로 조합될 숫자를 저장
            List<int> currentDigitNumbers = new List<int>();
            
            //이전에 조합된 숫자를 사용
            foreach (int number in prevDigitNumbers)
            {
                //새로운 숫자를 이어붙일 때 현재 이미 사용 중인 숫자를 포함하지 않도록 함
                string numStr = number.ToString();
            
                List<int> usingNumbers = numberSet.ToList();
                
                //기존 숫자에서 사용하던 숫자를 제외하고 추가
                foreach (char c in numStr)
                {
                    usingNumbers.Remove(int.Parse(c.ToString()));
                }
                
                //사용하기로 결정된 숫자만 기존 숫자 뒤에 이어붙힘
                foreach (int n in usingNumbers)
                {
                    int tempNum = int.Parse(numStr + n);
                    
                    //중복되는 숫자는 포함하지 않음
                    if(!currentDigitNumbers.Contains(tempNum))
                        currentDigitNumbers.Add(tempNum);
                }
            }
            
            _numbersList.AddRange(prevDigitNumbers);
            prevDigitNumbers = currentDigitNumbers;
        }
        
        _numbersList.AddRange(prevDigitNumbers);
    }

    private static void InitPrimeNumberList(int maxNum)
    {
        
        for (var i = 2; i <= maxNum; i++)
        {
            if(IsPrime(i))
                _primeNumberList.Add(i);
        }
    }

    private static bool IsPrime(int number)
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        
        return true;
    }
}