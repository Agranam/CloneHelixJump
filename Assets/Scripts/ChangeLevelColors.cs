using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelColors : MonoBehaviour
{
    [SerializeField] private Material[] _originalLevelMaterials;
    [SerializeField] private Material[] _newLevelMaterials;
    private List<Material> _currentMaterials = new List<Material>();

    public void ChangeMaterials(int selectedMaterials) /// 0 - Original, 1 - New
    {
        if (selectedMaterials == 0)
        {
            LevelSkin = 0;
            selectMaterial(_originalLevelMaterials);
        }
        if (selectedMaterials == 1)
        {
            LevelSkin = 1;
            selectMaterial(_newLevelMaterials);
        }
        appointMaterial<SectorBad>(_currentMaterials[0]);
        appointMaterial<SectorGood>(_currentMaterials[1]);
        appointMaterial<FinishPlatform>(_currentMaterials[2]);
        appointMaterial<Pillar>(_currentMaterials[3]);
    }

    private void selectMaterial(Material[] selectedMaterials)
    {
        _currentMaterials.Clear();
        for (int i = 0; i < selectedMaterials.Length; i++)
        {
            _currentMaterials.Add(selectedMaterials[i]);
        }
    }

    private void appointMaterial<T>(Material selectedMaterial) where T : Component
    {
        var objects = FindObjectsOfType<T>();

        for (int i = 0; i < objects.Length; i++)
        {
            Renderer renderer = objects[i].GetComponent<Renderer>();
            renderer.material = selectedMaterial;
        }
    }
    static public int LevelSkin
    {
        get => PlayerPrefs.GetInt("LevelSkin", 1);
        set
        {
            PlayerPrefs.SetInt("LevelSkin", value);
            PlayerPrefs.Save();
        }
    }
}
