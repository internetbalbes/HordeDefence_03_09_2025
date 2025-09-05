using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityAction HealthPointsChanged;

    private int _healthPoints = 0;

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
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return _healthPoints;
    }
}
