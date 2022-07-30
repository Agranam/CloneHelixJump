using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _platformCameraOffset;
    [SerializeField] private float _MoveSpeed;

    void Update()
    {
        if (_player.CurrentPlatform == null) return;

        Vector3 targetPosition = _player.CurrentPlatform.transform.position + _platformCameraOffset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, _MoveSpeed * Time.deltaTime);

    }
}
