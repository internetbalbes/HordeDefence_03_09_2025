using UnityEngine;

public interface IDamageable
{
    public int Health { get; set; }

    public void TakeDamage(int damage);

    public void InitializeHealth(int health);
}
