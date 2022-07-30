using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _minPlatforms;
    [SerializeField] private int _maxPlatforms;
    [SerializeField] private float _distaceBetweenPlatforms;
    [SerializeField] private GameObject _startPlatformPrefab;
    [SerializeField] private GameObject _finishPlatformPrefab;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _centralPillarPrefab;
    
    private void Awake()
    {
        Instantiate(_startPlatformPrefab, transform);

        int platformCount = Random.Range(_minPlatforms, _maxPlatforms + 1);

        for (int i = 0; i < platformCount; i++)
        {
            instantiatePrefab(_platformPrefab, calculatePlatformPosition(i + 1),
                Quaternion.Euler(0, Random.Range(0, 360f), 0), Vector3.one);
        }

        instantiatePrefab(_centralPillarPrefab, new Vector3(0, 15, 0),  
            Quaternion.identity, new Vector3(1, ((platformCount + 1) * _distaceBetweenPlatforms) + 15, 1));

        instantiatePrefab(_finishPlatformPrefab, calculatePlatformPosition(platformCount + 1),  
            Quaternion.identity, Vector3.one);
    }

    private void instantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        GameObject gameObject = Instantiate(prefab, transform);
        gameObject.transform.localPosition = position;
        gameObject.transform.rotation = rotation;
        gameObject.transform.localScale = scale;
    }

    private Vector3 calculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -_distaceBetweenPlatforms * platformIndex, 0);
    }
}
