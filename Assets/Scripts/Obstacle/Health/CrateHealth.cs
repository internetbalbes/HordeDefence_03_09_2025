using UnityEngine;
using UnityEngine.Events;

public class CrateHealth : Crate, IDamageable
{
    [SerializeField] private UnityEvent<int> CrateDamaged;
    public static UnityAction<Gun> CrateDestroyed;

    public int Health { get; set; }

    private void OnEnable()
    {
        Health = 20;
        CrateDamaged?.Invoke(Health);
    }

    public void TakeDamage(int damage = 1)
    {
        Health -= damage;

        CrateDamaged?.Invoke(Health);

        if (Health <= 0)
        {
            CrateDestroyed?.Invoke(_gun);
            GetComponent<Poolable>().GetPool().Return(gameObject);
        }
    }
}
