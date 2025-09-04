using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<LootCrate>(out LootCrate lootCrate))
        {
            lootCrate.gameObject.SetActive(false);
        }
    }
}
