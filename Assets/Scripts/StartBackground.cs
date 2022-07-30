using UnityEngine;

public class StartBackground : MonoBehaviour
{
    [SerializeField] private int _platformCount;
    [SerializeField] private float _distaceBetweenPlatforms;
    [SerializeField] private float _speedRotation = 30;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _centralPillarPrefab;
    [SerializeField] private ChangeLevelColors _changeLevelColors;

    private void Start()
    {
        GenerateBackground();
    }

    private void Update()
    {
        transform.Rotate(0, _speedRotation * Time.deltaTime, 0);
    }

    private void GenerateBackground()
    {
        for (int i = 0; i < _platformCount; i++)
        {
            GameObject platform = Instantiate(_platformPrefab, transform);
            platform.transform.localPosition = new Vector3(0, -_distaceBetweenPlatforms * i, 0);
            platform.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        GameObject centralPillar = Instantiate(_centralPillarPrefab, transform);
        centralPillar.transform.localScale = new Vector3(1, _distaceBetweenPlatforms * _platformCount, 1);
        
        _changeLevelColors.ChangeMaterials(ChangeLevelColors.LevelSkin);
    }
    public void destroyObjects()
    {
        Destroy(gameObject);
    }
}
