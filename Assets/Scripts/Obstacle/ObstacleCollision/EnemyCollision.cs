using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Soldier>(out Soldier soldier))
        {
            soldier.Kill();
            GetComponent<Poolable>().GetPool().Return(gameObject);
        }
    }
}
