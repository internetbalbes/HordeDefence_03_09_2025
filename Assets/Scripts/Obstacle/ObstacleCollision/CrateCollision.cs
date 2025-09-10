using UnityEngine;

public class CrateCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EndZone>(out _))
        {
            GetComponent<Poolable>().GetPool().Return(gameObject);
        }

        if (other.TryGetComponent<Soldier>(out Soldier soldier))
        {
            soldier.GetPlayer().RemoveSoldier(gameObject);
        }
    }
}