using UnityEngine;
using UnityEngine.Events;

public class LootCrateCollisionHandler : MonoBehaviour
{
    static public UnityAction PlayerCollidedLootCrate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Player>(out _))
        {
            PlayerCollidedLootCrate?.Invoke();
        }
    }
}
