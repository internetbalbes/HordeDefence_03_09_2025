using UnityEngine;

public class CrateCollision : MonoBehaviour
{
    private static SoldierSpawner _soldierSpawner;

    private void Start()
    {
        _soldierSpawner = FindAnyObjectByType<SoldierSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierCollision>(out SoldierCollision soldier))
        {
            _soldierSpawner.RemoveAtSoldier(soldier.gameObject);
        }
    }
}