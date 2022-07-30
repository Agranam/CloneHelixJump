using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : Platform
{
    [Range(0, 100)]
    [SerializeField] private int _percentOfBadSectors, _percentOfGoodSectors, _percentOfNullSectors;
    [SerializeField] private GameObject _badSectorPrefab;
    [SerializeField] private GameObject _goodSectorPrefab;
    [SerializeField] private List<GameObject> _createdPlatform = new List<GameObject>();

    private int _badSectors, _nullSectors, _goodSectors;

    private int _minBad, _maxBad;

    private void Awake()
    {
        Swither(Game.CurrentLevel);
        for (int i = 0; i < 11; i++)
        {
            GameObject sector = SectorRandom(i * 30);
            _createdPlatform.Add(sector);
        }
    }
    internal override void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _scoreCalculation.SetLevelScore(_badSectors, _goodSectors);
        }
    }
    private void Swither(int selectedLevel)
    {
        switch (selectedLevel)
        {
            case <= 10:
                _minBad = 0;
                _maxBad = 2;
                break;
            case <= 20:
                _minBad = 1;
                _maxBad = 2;
                break;
            case <= 30:
                _minBad = 1;
                _maxBad = 3;
                break;
            case <= 40:
                _minBad = 2;
                _maxBad = 3;
                break;
            case <= 50:
                _minBad = 1;
                _maxBad = 4;
                break;
            case <= 60:
                _minBad = 2;
                _maxBad = 4;
                break;
            case <= 70:
                _minBad = 1;
                _maxBad = 5;
                break;
            case <= 80:
                _minBad = 2;
                _maxBad = 5;
                break;
            case <= 90:
                _minBad = 3;
                _maxBad = 5;
                break;
            case <= 99:
                _minBad = 4;
                _maxBad = 5;
                break;
            default:
                _minBad = 5;
                _maxBad = 5;
                break;
        }
    }


    private GameObject SectorRandom(float angle)
    {
        GameObject sector = null;
        int random = Random.Range(0, 101);

        if (random > 80 && _nullSectors < 1)
        {
            sector = null;
            _nullSectors++;
        }
        else if (random < 20 && _badSectors < Random.Range(_minBad, _maxBad))
        {
            createSector(_badSectorPrefab, out sector);
            _badSectors++;
        }
        else 
        {
            createSector(_goodSectorPrefab, out sector);
            _goodSectors++;
        }
        if (sector != null)
            sector.transform.rotation = Quaternion.Euler(0, angle, 0);

        return sector;
    }

    private void createSector(GameObject sectorPrefab, out GameObject createdSector)
    {
        createdSector = Instantiate(sectorPrefab, transform);
    }
}
