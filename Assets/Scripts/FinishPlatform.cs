using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        player.Finished();
    }
}
