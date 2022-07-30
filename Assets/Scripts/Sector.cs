using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private float _actionPossibility = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < _actionPossibility) return;

        action(player);
    }
    public virtual void action(Player player)
    {

    }
}
