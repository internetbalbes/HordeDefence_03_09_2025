using UnityEngine;

public class GatesCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Soldier>(out Soldier soldier))
        {
            
        }
    }
}
