using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public event Action<EnemyHealth> Dead;

    public int Health { get; set; } = 1;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Dead?.Invoke(this);
            Destroy(gameObject);
        }   
    }
}