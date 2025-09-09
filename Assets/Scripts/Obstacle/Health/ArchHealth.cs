using UnityEngine;
using UnityEngine.Events;

public class ArchHealth : MonoBehaviour, IDamageable
{
    public UnityEvent<int> ArchDamaged; // for visual displaying health

    public int Health { get; set; } = 1;

    public void TakeDamage(int damage)
    {
        Health += damage;
        ArchDamaged?.Invoke(Health);
    }
}
