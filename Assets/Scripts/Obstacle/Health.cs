using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityAction HealthPointsChanged;
    public static UnityAction<GameObject> OnDied;

    private int _healthPoints = 3;

    public void HealthInit(int healthPoints)
    {
        _healthPoints = healthPoints;
    }

    public void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        HealthPointsChanged?.Invoke();

        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke(gameObject);
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return _healthPoints;
    }
}
