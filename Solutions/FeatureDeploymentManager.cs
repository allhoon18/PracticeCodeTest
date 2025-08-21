namespace PracticeCodeTest.Solutions;

public class FeatureDeploymentManager
{
    /*
     * 프로그래머스 팀에서는 기능 개선 작업을 수행 중입니다. 각 기능은 진도가 100%일 때 서비스에 반영할 수 있습니다.
     * 또, 각 기능의 개발속도는 모두 다르기 때문에 뒤에 있는 기능이 앞에 있는 기능보다 먼저 개발될 수 있고,
     * 이때 뒤에 있는 기능은 앞에 있는 기능이 배포될 때 함께 배포됩니다.
     *
     * 먼저 배포되어야 하는 순서대로 작업의 진도가 적힌 정수 배열 progresses와
     * 각 작업의 개발 속도가 적힌 정수 배열 speeds가 주어질 때
     * 각 배포마다 몇 개의 기능이 배포되는지를 return 하도록 solution 함수를 완성하세요.
     */

    //https://school.programmers.co.kr/learn/courses/30/lessons/42586

    private static int _featuresCount = 0;
    private static int _completeCount = 0;
    private static int _targetFeatureIndex = 0;
    
    public static int[] Solution(int[] progresses, int[] speeds)
    {
        int featureNum = progresses.Length;
        
        Feature[] features = new Feature[featureNum];

        for (int i = 0; i < featureNum; i++)
        {
            features[i] = new Feature(i,progresses[i], speeds[i], ReleaseFeature);
        }
        
        List<int> releases = new List<int>();
        
        while (_completeCount != featureNum)
        {
            foreach (var feature in features)
            {
                if(!feature.IsCompleted)
                    feature.UpdateProgress(_targetFeatureIndex);
            }
            
            if(_featuresCount > 0)
                releases.Add(_featuresCount);
            
            _featuresCount = 0;
        }
        
        return releases.ToArray();
    }

    private static void ReleaseFeature()
    {
        _featuresCount++;
        _completeCount++;
        _targetFeatureIndex++;
    }
}

class Feature
{
    private readonly int _index;
    private readonly int _speed;
    private readonly Action _onComplete;
    
    private int _progress;
    
    public bool IsCompleted = false;

    public Feature(int index, int progress, int speed, Action onComplete)
    {
        _index = index;
        _progress = progress;
        _speed = speed;
        _onComplete = onComplete;
    }
    
    public void UpdateProgress(int targetFeatureIndex)
    {
        _progress += _speed;

        if (_progress >= 100 && targetFeatureIndex == _index)
        {
            IsCompleted = true;
            _onComplete?.Invoke();
        }
    }
}