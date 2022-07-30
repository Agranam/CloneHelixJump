using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private Slider _setRotationSpeedSlider;
    private Transform _level;
    private Vector3 _previousMousePosition;
    private float _rotationSpeedValue;
    private float preservedRotationSpeedValue
    {
        get => PlayerPrefs.GetFloat("SensityValue", 0.5f);
        set
        {
            PlayerPrefs.SetFloat("SensityValue", value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        SetSpeedRotation(preservedRotationSpeedValue);
        _setRotationSpeedSlider.value = preservedRotationSpeedValue;
    }

    void Update()
    {
        if (!_level) return;

        androidControl();
    }

    public void SetSpeedRotation(float value)
    {
        preservedRotationSpeedValue = value;
        _rotationSpeedValue = Mathf.Lerp(0.1f, 0.4f, value);
    }

    private void androidControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Quaternion rotationY = Quaternion.Euler(0, - touch.deltaPosition.x * _rotationSpeedValue, 0);
                _level.rotation = rotationY * _level.rotation;
            }
        }
    }

    private void pcControl()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _level.Rotate(0, -delta.x * _rotationSpeedValue, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }

    public void FindLevel()
    {
        _level = FindObjectOfType<LevelGenerator>().transform;
    }
}
