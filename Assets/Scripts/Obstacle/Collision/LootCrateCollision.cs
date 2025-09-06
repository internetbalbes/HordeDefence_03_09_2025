using UnityEngine;

public class LootCrateCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Soldier>(out Soldier soldier))
        {
            Player player = FindFirstObjectByType<Player>();
            player.RemoveSoldier(soldier.gameObject);
        }

        if (other.TryGetComponent<EndZone>(out EndZone endZone))
        {

        }
    }
}
