using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static Action Dead;

    public int Health { get; set; } = 1;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            GetComponent<Poolable>().GetPool().Return(gameObject);
            Dead?.Invoke();
        }   
    }
}
