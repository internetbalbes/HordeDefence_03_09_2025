using UnityEngine;
using UnityEngine.Events;

public class CrateHealth : Crate
{
    public UnityAction<int> CrateDamaged;
    public static UnityAction<Gun> CrateDestroyed;

    public int Health { get; set; }

    private void Start()
    {
        Health = RoundDuration._roundDuration;
        CrateDamaged?.Invoke(Health);
    }

    public void SetHealthPoints(int health)
    {
        Health = health;
        CrateDamaged?.Invoke(Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        CrateDamaged?.Invoke(Health);

        if (Health <= 0)
        {
            CrateDestroyed?.Invoke(_gun);
            Destroy(gameObject);
        }
    }
}
