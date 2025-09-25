using UnityEngine;
using System;

public class BossHealth : MonoBehaviour, IDamageable
{
    public static event Action Dead;

    public int Health { get; set;}

    private void Start()
    {
        InitializeHealth(RoundDuration.Instance.Duration);
    }

    public void InitializeHealth(int health)
    {
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
        }
        else
        {
            Debug.LogWarning("Damage variable is positive");
        }

        if (Health <= 0)
        {
            Dead?.Invoke();
            Destroy(gameObject);
        }
    }
}
